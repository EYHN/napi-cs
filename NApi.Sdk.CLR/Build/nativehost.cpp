// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

// Standard headers
#include <stdio.h>
#include <stdint.h>
#include <stdlib.h>
#include <string.h>
#include <assert.h>
#include <iostream>

#include <napi.h>

// Provided by the AppHost NuGet package and installed as an SDK pack
#include <nethost.h>

// Header files copied from https://github.com/dotnet/core-setup
#include <coreclr_delegates.h>
#include <hostfxr.h>

#ifdef WINDOWS
#include <Windows.h>

#define STR(s) L ## s
#define CH(c) L ## c
#define DIR_SEPARATOR L'\\'

#else
#include <dlfcn.h>
#include <limits.h>

#define STR(s) s
#define CH(c) c
#define DIR_SEPARATOR '/'
#define MAX_PATH PATH_MAX

#endif

using string_t = std::basic_string<char_t>;

typedef napi_value (CORECLR_DELEGATE_CALLTYPE *entry_point_fn)(napi_env env, napi_value exports);

namespace
{
    // Globals to hold hostfxr exports
    hostfxr_initialize_for_runtime_config_fn init_fptr;
    hostfxr_get_runtime_delegate_fn get_delegate_fptr;
    hostfxr_close_fn close_fptr;

    entry_point_fn entry_point = nullptr;

    // Forward declarations
    bool load_hostfxr();
    load_assembly_and_get_function_pointer_fn get_dotnet_load_assembly(const char_t *assembly);
}

// initialize("<dotnet_assembly_path>", "<dotnet_runtimeconfigjson_path>", "<assembly>")
Napi::Value Initialize(const Napi::CallbackInfo& info) {
  Napi::Env env = info.Env();

  if (entry_point == nullptr) {
    if (info.Length() != 3) {
        Napi::TypeError::New(env, "Wrong number of arguments")
            .ThrowAsJavaScriptException();
        return env.Null();
    }

    if (!info[0].IsString() || !info[1].IsString() || !info[2].IsString()) {
        Napi::TypeError::New(env, "Wrong arguments").ThrowAsJavaScriptException();
        return env.Null();
    }
    
    const string_t dotnetlib_path = info[0].As<Napi::String>().Utf8Value();
    const string_t config_path = info[1].As<Napi::String>().Utf8Value();
    const string_t dotnet_type = STR("NApi.ModuleExports_AutoGen, ") + info[2].As<Napi::String>().Utf8Value();
    const string_t dotnet_type_method = STR("napi_register_module_v1");

    string_t root_path = dotnetlib_path;
    auto pos = root_path.find_last_of(DIR_SEPARATOR);
    if (pos == string_t::npos) {
        Napi::TypeError::New(env, "Wrong path").ThrowAsJavaScriptException();
        return env.Null();
    }
    root_path = root_path.substr(0, pos + 1);

    load_assembly_and_get_function_pointer_fn load_assembly_and_get_function_pointer = nullptr;
    load_assembly_and_get_function_pointer = get_dotnet_load_assembly(config_path.c_str());
    if (load_assembly_and_get_function_pointer == nullptr) {
        Napi::TypeError::New(env, "Failure: get_dotnet_load_assembly()").ThrowAsJavaScriptException();
        return env.Null();
    }

    
    entry_point = nullptr;
    int rc = load_assembly_and_get_function_pointer(
        dotnetlib_path.c_str(),
        dotnet_type.c_str(),
        dotnet_type_method.c_str(),
        UNMANAGEDCALLERSONLY_METHOD,
        nullptr,
        (void**)&entry_point);
    if (!(rc == 0 && entry_point != nullptr)) {
        Napi::TypeError::New(env, "Failure: load_assembly_and_get_function_pointer()").ThrowAsJavaScriptException();
        return env.Null();
    }
  }

  Napi::Object obj = Napi::Object::New(env);
  napi_value ret = entry_point(env, obj);

  return Napi::Value(env, ret);
}

Napi::Object Init(Napi::Env env, Napi::Object exports) {
  if (!load_hostfxr())
  {
    Napi::TypeError::New(env, "Failure: load_hostfxr()").ThrowAsJavaScriptException();
    return exports;
  }

  exports.Set(Napi::String::New(env, "initialize"), Napi::Function::New(env, Initialize));
  return exports;
}

NODE_API_MODULE(addon, Init)

/********************************************************************************************
 * Function used to load and activate .NET Core
 ********************************************************************************************/

namespace
{
    // Forward declarations
    void *load_library(const char_t *);
    void *get_export(void *, const char *);

#ifdef WINDOWS
    void *load_library(const char_t *path)
    {
        HMODULE h = ::LoadLibraryW(path);
        assert(h != nullptr);
        return (void*)h;
    }
    void *get_export(void *h, const char *name)
    {
        void *f = ::GetProcAddress((HMODULE)h, name);
        assert(f != nullptr);
        return f;
    }
#else
    void *load_library(const char_t *path)
    {
        void *h = dlopen(path, RTLD_LAZY | RTLD_LOCAL);
        assert(h != nullptr);
        return h;
    }
    void *get_export(void *h, const char *name)
    {
        void *f = dlsym(h, name);
        assert(f != nullptr);
        return f;
    }
#endif

    // <SnippetLoadHostFxr>
    // Using the nethost library, discover the location of hostfxr and get exports
    bool load_hostfxr()
    {
        // Pre-allocate a large buffer for the path to hostfxr
        char_t buffer[MAX_PATH];
        size_t buffer_size = sizeof(buffer) / sizeof(char_t);
        int rc = get_hostfxr_path(buffer, &buffer_size, nullptr);
        if (rc != 0)
            return false;

        // Load hostfxr and get desired exports
        void *lib = load_library(buffer);
        init_fptr = (hostfxr_initialize_for_runtime_config_fn)get_export(lib, "hostfxr_initialize_for_runtime_config");
        get_delegate_fptr = (hostfxr_get_runtime_delegate_fn)get_export(lib, "hostfxr_get_runtime_delegate");
        close_fptr = (hostfxr_close_fn)get_export(lib, "hostfxr_close");

        return (init_fptr && get_delegate_fptr && close_fptr);
    }
    // </SnippetLoadHostFxr>

    // <SnippetInitialize>
    // Load and initialize .NET Core and get desired function pointer for scenario
    load_assembly_and_get_function_pointer_fn get_dotnet_load_assembly(const char_t *config_path)
    {
        // Load .NET Core
        void *load_assembly_and_get_function_pointer = nullptr;
        hostfxr_handle cxt = nullptr;
        int rc = init_fptr(config_path, nullptr, &cxt);
        if (rc != 0 || cxt == nullptr)
        {
            std::cerr << "Init failed: " << std::hex << std::showbase << rc << std::endl;
            close_fptr(cxt);
            return nullptr;
        }

        // Get the load assembly function pointer
        rc = get_delegate_fptr(
            cxt,
            hdt_load_assembly_and_get_function_pointer,
            &load_assembly_and_get_function_pointer);
        if (rc != 0 || load_assembly_and_get_function_pointer == nullptr)
            std::cerr << "Get delegate failed: " << std::hex << std::showbase << rc << std::endl;

        close_fptr(cxt);
        return (load_assembly_and_get_function_pointer_fn)load_assembly_and_get_function_pointer;
    }
    // </SnippetInitialize>
}
