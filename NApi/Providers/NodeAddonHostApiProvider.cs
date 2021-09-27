using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security;

namespace NApi.Providers
{
    public unsafe class NodeAddonHostApiProvider : INApiProvider
    {
        public static void SetupDllImportResolver(Assembly assembly)
        {
            NativeLibrary.SetDllImportResolver(assembly, (name, _, _) =>
            {
                if (name == "NodeJS")
                {
                    if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                    {
                        return GetModuleHandle(null);
                    }
                    else
                    {
                        return dlopen(null, 1);
                    }
                }

                return IntPtr.Zero;
            });
        }

        [DllImport("kernel32.dll")]
        private static extern IntPtr GetModuleHandle(string? moduleName);

        [DllImport("dl")]
        private static extern IntPtr dlopen(string? moduleName, int flags);

        public class DllImportJsNativeApiProvider : INApiProvider.IJsNativeApiProvider
        {
            public INApiProvider.IJsNativeApiProvider.napi_get_last_error_info_delegate napi_get_last_error_info => Native.napi_get_last_error_info;
            public INApiProvider.IJsNativeApiProvider.napi_get_undefined_delegate napi_get_undefined => Native.napi_get_undefined;
            public INApiProvider.IJsNativeApiProvider.napi_get_null_delegate napi_get_null => Native.napi_get_null;
            public INApiProvider.IJsNativeApiProvider.napi_get_global_delegate napi_get_global => Native.napi_get_global;
            public INApiProvider.IJsNativeApiProvider.napi_get_boolean_delegate napi_get_boolean => Native.napi_get_boolean;
            public INApiProvider.IJsNativeApiProvider.napi_create_object_delegate napi_create_object => Native.napi_create_object;
            public INApiProvider.IJsNativeApiProvider.napi_create_array_delegate napi_create_array => Native.napi_create_array;
            public INApiProvider.IJsNativeApiProvider.napi_create_array_with_length_delegate napi_create_array_with_length => Native.napi_create_array_with_length;
            public INApiProvider.IJsNativeApiProvider.napi_create_double_delegate napi_create_double => Native.napi_create_double;
            public INApiProvider.IJsNativeApiProvider.napi_create_int32_delegate napi_create_int32 => Native.napi_create_int32;
            public INApiProvider.IJsNativeApiProvider.napi_create_uint32_delegate napi_create_uint32 => Native.napi_create_uint32;
            public INApiProvider.IJsNativeApiProvider.napi_create_int64_delegate napi_create_int64 => Native.napi_create_int64;
            public INApiProvider.IJsNativeApiProvider.napi_create_string_latin1_delegate napi_create_string_latin1 => Native.napi_create_string_latin1;
            public INApiProvider.IJsNativeApiProvider.napi_create_string_utf8_delegate napi_create_string_utf8 => Native.napi_create_string_utf8;
            public INApiProvider.IJsNativeApiProvider.napi_create_string_utf16_delegate napi_create_string_utf16 => Native.napi_create_string_utf16;
            public INApiProvider.IJsNativeApiProvider.napi_create_symbol_delegate napi_create_symbol => Native.napi_create_symbol;
            public INApiProvider.IJsNativeApiProvider.napi_create_function_delegate napi_create_function => Native.napi_create_function;
            public INApiProvider.IJsNativeApiProvider.napi_create_error_delegate napi_create_error => Native.napi_create_error;
            public INApiProvider.IJsNativeApiProvider.napi_create_type_error_delegate napi_create_type_error => Native.napi_create_type_error;
            public INApiProvider.IJsNativeApiProvider.napi_create_range_error_delegate napi_create_range_error => Native.napi_create_range_error;
            public INApiProvider.IJsNativeApiProvider.napi_typeof_delegate napi_typeof => Native.napi_typeof;
            public INApiProvider.IJsNativeApiProvider.napi_get_value_double_delegate napi_get_value_double => Native.napi_get_value_double;
            public INApiProvider.IJsNativeApiProvider.napi_get_value_int32_delegate napi_get_value_int32 => Native.napi_get_value_int32;
            public INApiProvider.IJsNativeApiProvider.napi_get_value_uint32_delegate napi_get_value_uint32 => Native.napi_get_value_uint32;
            public INApiProvider.IJsNativeApiProvider.napi_get_value_int64_delegate napi_get_value_int64 => Native.napi_get_value_int64;
            public INApiProvider.IJsNativeApiProvider.napi_get_value_bool_delegate napi_get_value_bool => Native.napi_get_value_bool;
            public INApiProvider.IJsNativeApiProvider.napi_get_value_string_latin1_delegate napi_get_value_string_latin1 => Native.napi_get_value_string_latin1;
            public INApiProvider.IJsNativeApiProvider.napi_get_value_string_utf8_delegate napi_get_value_string_utf8 => Native.napi_get_value_string_utf8;
            public INApiProvider.IJsNativeApiProvider.napi_get_value_string_utf16_delegate napi_get_value_string_utf16 => Native.napi_get_value_string_utf16;
            public INApiProvider.IJsNativeApiProvider.napi_coerce_to_bool_delegate napi_coerce_to_bool => Native.napi_coerce_to_bool;
            public INApiProvider.IJsNativeApiProvider.napi_coerce_to_number_delegate napi_coerce_to_number => Native.napi_coerce_to_number;
            public INApiProvider.IJsNativeApiProvider.napi_coerce_to_object_delegate napi_coerce_to_object => Native.napi_coerce_to_object;
            public INApiProvider.IJsNativeApiProvider.napi_coerce_to_string_delegate napi_coerce_to_string => Native.napi_coerce_to_string;
            public INApiProvider.IJsNativeApiProvider.napi_get_prototype_delegate napi_get_prototype => Native.napi_get_prototype;
            public INApiProvider.IJsNativeApiProvider.napi_get_property_names_delegate napi_get_property_names => Native.napi_get_property_names;
            public INApiProvider.IJsNativeApiProvider.napi_set_property_delegate napi_set_property => Native.napi_set_property;
            public INApiProvider.IJsNativeApiProvider.napi_has_property_delegate napi_has_property => Native.napi_has_property;
            public INApiProvider.IJsNativeApiProvider.napi_get_property_delegate napi_get_property => Native.napi_get_property;
            public INApiProvider.IJsNativeApiProvider.napi_delete_property_delegate napi_delete_property => Native.napi_delete_property;
            public INApiProvider.IJsNativeApiProvider.napi_has_own_property_delegate napi_has_own_property => Native.napi_has_own_property;
            public INApiProvider.IJsNativeApiProvider.napi_set_named_property_delegate napi_set_named_property => Native.napi_set_named_property;
            public INApiProvider.IJsNativeApiProvider.napi_has_named_property_delegate napi_has_named_property => Native.napi_has_named_property;
            public INApiProvider.IJsNativeApiProvider.napi_get_named_property_delegate napi_get_named_property => Native.napi_get_named_property;
            public INApiProvider.IJsNativeApiProvider.napi_set_element_delegate napi_set_element => Native.napi_set_element;
            public INApiProvider.IJsNativeApiProvider.napi_has_element_delegate napi_has_element => Native.napi_has_element;
            public INApiProvider.IJsNativeApiProvider.napi_get_element_delegate napi_get_element => Native.napi_get_element;
            public INApiProvider.IJsNativeApiProvider.napi_delete_element_delegate napi_delete_element => Native.napi_delete_element;
            public INApiProvider.IJsNativeApiProvider.napi_define_properties_delegate napi_define_properties => Native.napi_define_properties;
            public INApiProvider.IJsNativeApiProvider.napi_is_array_delegate napi_is_array => Native.napi_is_array;
            public INApiProvider.IJsNativeApiProvider.napi_get_array_length_delegate napi_get_array_length => Native.napi_get_array_length;
            public INApiProvider.IJsNativeApiProvider.napi_strict_equals_delegate napi_strict_equals => Native.napi_strict_equals;
            public INApiProvider.IJsNativeApiProvider.napi_call_function_delegate napi_call_function => Native.napi_call_function;
            public INApiProvider.IJsNativeApiProvider.napi_new_instance_delegate napi_new_instance => Native.napi_new_instance;
            public INApiProvider.IJsNativeApiProvider.napi_instanceof_delegate napi_instanceof => Native.napi_instanceof;
            public INApiProvider.IJsNativeApiProvider.napi_get_cb_info_delegate napi_get_cb_info => Native.napi_get_cb_info;
            public INApiProvider.IJsNativeApiProvider.napi_get_new_target_delegate napi_get_new_target => Native.napi_get_new_target;
            public INApiProvider.IJsNativeApiProvider.napi_define_class_delegate napi_define_class => Native.napi_define_class;
            public INApiProvider.IJsNativeApiProvider.napi_wrap_delegate napi_wrap => Native.napi_wrap;
            public INApiProvider.IJsNativeApiProvider.napi_unwrap_delegate napi_unwrap => Native.napi_unwrap;
            public INApiProvider.IJsNativeApiProvider.napi_remove_wrap_delegate napi_remove_wrap => Native.napi_remove_wrap;
            public INApiProvider.IJsNativeApiProvider.napi_create_external_delegate napi_create_external => Native.napi_create_external;
            public INApiProvider.IJsNativeApiProvider.napi_get_value_external_delegate napi_get_value_external => Native.napi_get_value_external;
            public INApiProvider.IJsNativeApiProvider.napi_create_reference_delegate napi_create_reference => Native.napi_create_reference;
            public INApiProvider.IJsNativeApiProvider.napi_delete_reference_delegate napi_delete_reference => Native.napi_delete_reference;
            public INApiProvider.IJsNativeApiProvider.napi_reference_ref_delegate napi_reference_ref => Native.napi_reference_ref;
            public INApiProvider.IJsNativeApiProvider.napi_reference_unref_delegate napi_reference_unref => Native.napi_reference_unref;
            public INApiProvider.IJsNativeApiProvider.napi_get_reference_value_delegate napi_get_reference_value => Native.napi_get_reference_value;
            public INApiProvider.IJsNativeApiProvider.napi_open_handle_scope_delegate napi_open_handle_scope => Native.napi_open_handle_scope;
            public INApiProvider.IJsNativeApiProvider.napi_close_handle_scope_delegate napi_close_handle_scope => Native.napi_close_handle_scope;
            public INApiProvider.IJsNativeApiProvider.napi_open_escapable_handle_scope_delegate napi_open_escapable_handle_scope => Native.napi_open_escapable_handle_scope;
            public INApiProvider.IJsNativeApiProvider.napi_close_escapable_handle_scope_delegate napi_close_escapable_handle_scope => Native.napi_close_escapable_handle_scope;
            public INApiProvider.IJsNativeApiProvider.napi_escape_handle_delegate napi_escape_handle => Native.napi_escape_handle;
            public INApiProvider.IJsNativeApiProvider.napi_throw_delegate napi_throw => Native.napi_throw;
            public INApiProvider.IJsNativeApiProvider.napi_throw_error_delegate napi_throw_error => Native.napi_throw_error;
            public INApiProvider.IJsNativeApiProvider.napi_throw_type_error_delegate napi_throw_type_error => Native.napi_throw_type_error;
            public INApiProvider.IJsNativeApiProvider.napi_throw_range_error_delegate napi_throw_range_error => Native.napi_throw_range_error;
            public INApiProvider.IJsNativeApiProvider.napi_is_error_delegate napi_is_error => Native.napi_is_error;
            public INApiProvider.IJsNativeApiProvider.napi_is_exception_pending_delegate napi_is_exception_pending => Native.napi_is_exception_pending;
            public INApiProvider.IJsNativeApiProvider.napi_get_and_clear_last_exception_delegate napi_get_and_clear_last_exception => Native.napi_get_and_clear_last_exception;
            public INApiProvider.IJsNativeApiProvider.napi_is_arraybuffer_delegate napi_is_arraybuffer => Native.napi_is_arraybuffer;
            public INApiProvider.IJsNativeApiProvider.napi_create_arraybuffer_delegate napi_create_arraybuffer => Native.napi_create_arraybuffer;
            public INApiProvider.IJsNativeApiProvider.napi_create_external_arraybuffer_delegate napi_create_external_arraybuffer => Native.napi_create_external_arraybuffer;
            public INApiProvider.IJsNativeApiProvider.napi_get_arraybuffer_info_delegate napi_get_arraybuffer_info => Native.napi_get_arraybuffer_info;
            public INApiProvider.IJsNativeApiProvider.napi_is_typedarray_delegate napi_is_typedarray => Native.napi_is_typedarray;
            public INApiProvider.IJsNativeApiProvider.napi_create_typedarray_delegate napi_create_typedarray => Native.napi_create_typedarray;
            public INApiProvider.IJsNativeApiProvider.napi_get_typedarray_info_delegate napi_get_typedarray_info => Native.napi_get_typedarray_info;
            public INApiProvider.IJsNativeApiProvider.napi_create_dataview_delegate napi_create_dataview => Native.napi_create_dataview;
            public INApiProvider.IJsNativeApiProvider.napi_is_dataview_delegate napi_is_dataview => Native.napi_is_dataview;
            public INApiProvider.IJsNativeApiProvider.napi_get_dataview_info_delegate napi_get_dataview_info => Native.napi_get_dataview_info;
            public INApiProvider.IJsNativeApiProvider.napi_get_version_delegate napi_get_version => Native.napi_get_version;
            public INApiProvider.IJsNativeApiProvider.napi_create_promise_delegate napi_create_promise => Native.napi_create_promise;
            public INApiProvider.IJsNativeApiProvider.napi_resolve_deferred_delegate napi_resolve_deferred => Native.napi_resolve_deferred;
            public INApiProvider.IJsNativeApiProvider.napi_reject_deferred_delegate napi_reject_deferred => Native.napi_reject_deferred;
            public INApiProvider.IJsNativeApiProvider.napi_is_promise_delegate napi_is_promise => Native.napi_is_promise;
            public INApiProvider.IJsNativeApiProvider.napi_run_script_delegate napi_run_script => Native.napi_run_script;
            public INApiProvider.IJsNativeApiProvider.napi_adjust_external_memory_delegate napi_adjust_external_memory => Native.napi_adjust_external_memory;
            public INApiProvider.IJsNativeApiProvider.napi_create_date_delegate napi_create_date => Native.napi_create_date;
            public INApiProvider.IJsNativeApiProvider.napi_is_date_delegate napi_is_date => Native.napi_is_date;
            public INApiProvider.IJsNativeApiProvider.napi_get_date_value_delegate napi_get_date_value => Native.napi_get_date_value;
            public INApiProvider.IJsNativeApiProvider.napi_add_finalizer_delegate napi_add_finalizer => Native.napi_add_finalizer;
            public INApiProvider.IJsNativeApiProvider.napi_create_bigint_int64_delegate napi_create_bigint_int64 => Native.napi_create_bigint_int64;
            public INApiProvider.IJsNativeApiProvider.napi_create_bigint_uint64_delegate napi_create_bigint_uint64 => Native.napi_create_bigint_uint64;
            public INApiProvider.IJsNativeApiProvider.napi_create_bigint_words_delegate napi_create_bigint_words => Native.napi_create_bigint_words;
            public INApiProvider.IJsNativeApiProvider.napi_get_value_bigint_int64_delegate napi_get_value_bigint_int64 => Native.napi_get_value_bigint_int64;
            public INApiProvider.IJsNativeApiProvider.napi_get_value_bigint_uint64_delegate napi_get_value_bigint_uint64 => Native.napi_get_value_bigint_uint64;
            public INApiProvider.IJsNativeApiProvider.napi_get_value_bigint_words_delegate napi_get_value_bigint_words => Native.napi_get_value_bigint_words;
            public INApiProvider.IJsNativeApiProvider.napi_get_all_property_names_delegate napi_get_all_property_names => Native.napi_get_all_property_names;
            public INApiProvider.IJsNativeApiProvider.napi_set_instance_data_delegate napi_set_instance_data => Native.napi_set_instance_data;
            public INApiProvider.IJsNativeApiProvider.napi_get_instance_data_delegate napi_get_instance_data => Native.napi_get_instance_data;
            public INApiProvider.IJsNativeApiProvider.napi_detach_arraybuffer_delegate napi_detach_arraybuffer => Native.napi_detach_arraybuffer;
            public INApiProvider.IJsNativeApiProvider.napi_is_detached_arraybuffer_delegate napi_is_detached_arraybuffer => Native.napi_is_detached_arraybuffer;
            public INApiProvider.IJsNativeApiProvider.napi_type_tag_object_delegate napi_type_tag_object => Native.napi_type_tag_object;
            public INApiProvider.IJsNativeApiProvider.napi_check_object_type_tag_delegate napi_check_object_type_tag => Native.napi_check_object_type_tag;
            public INApiProvider.IJsNativeApiProvider.napi_object_freeze_delegate napi_object_freeze => Native.napi_object_freeze;
            public INApiProvider.IJsNativeApiProvider.napi_object_seal_delegate napi_object_seal => Native.napi_object_seal;

            private static class Native
            {
                [SuppressUnmanagedCodeSecurity,
                 DllImport("NodeJS", EntryPoint = "napi_get_last_error_info", CallingConvention = CallingConvention.Cdecl)]
                internal static extern napi_status napi_get_last_error_info(IntPtr env, IntPtr result);

                [SuppressUnmanagedCodeSecurity,
                 DllImport("NodeJS", EntryPoint = "napi_get_undefined", CallingConvention = CallingConvention.Cdecl)]
                internal static extern napi_status napi_get_undefined(IntPtr env, IntPtr result);

                [SuppressUnmanagedCodeSecurity,
                 DllImport("NodeJS", EntryPoint = "napi_get_null", CallingConvention = CallingConvention.Cdecl)]
                internal static extern napi_status napi_get_null(IntPtr env, IntPtr result);

                [SuppressUnmanagedCodeSecurity,
                 DllImport("NodeJS", EntryPoint = "napi_get_global", CallingConvention = CallingConvention.Cdecl)]
                internal static extern napi_status napi_get_global(IntPtr env, IntPtr result);

                [SuppressUnmanagedCodeSecurity,
                 DllImport("NodeJS", EntryPoint = "napi_get_boolean", CallingConvention = CallingConvention.Cdecl)]
                internal static extern napi_status napi_get_boolean(IntPtr env, bool value, IntPtr result);

                [SuppressUnmanagedCodeSecurity,
                 DllImport("NodeJS", EntryPoint = "napi_create_object", CallingConvention = CallingConvention.Cdecl)]
                internal static extern napi_status napi_create_object(IntPtr env, IntPtr result);

                [SuppressUnmanagedCodeSecurity,
                 DllImport("NodeJS", EntryPoint = "napi_create_array", CallingConvention = CallingConvention.Cdecl)]
                internal static extern napi_status napi_create_array(IntPtr env, IntPtr result);

                [SuppressUnmanagedCodeSecurity,
                 DllImport("NodeJS", EntryPoint = "napi_create_array_with_length", CallingConvention = CallingConvention.Cdecl)]
                internal static extern napi_status napi_create_array_with_length(IntPtr env, ulong length,
                    IntPtr result);

                [SuppressUnmanagedCodeSecurity,
                 DllImport("NodeJS", EntryPoint = "napi_create_double", CallingConvention = CallingConvention.Cdecl)]
                internal static extern napi_status napi_create_double(IntPtr env, double value, IntPtr result);

                [SuppressUnmanagedCodeSecurity,
                 DllImport("NodeJS", EntryPoint = "napi_create_int32", CallingConvention = CallingConvention.Cdecl)]
                internal static extern napi_status napi_create_int32(IntPtr env, int value, IntPtr result);

                [SuppressUnmanagedCodeSecurity,
                 DllImport("NodeJS", EntryPoint = "napi_create_uint32", CallingConvention = CallingConvention.Cdecl)]
                internal static extern napi_status napi_create_uint32(IntPtr env, uint value, IntPtr result);

                [SuppressUnmanagedCodeSecurity,
                 DllImport("NodeJS", EntryPoint = "napi_create_int64", CallingConvention = CallingConvention.Cdecl)]
                internal static extern napi_status napi_create_int64(IntPtr env, long value, IntPtr result);

                [SuppressUnmanagedCodeSecurity,
                 DllImport("NodeJS", EntryPoint = "napi_create_string_latin1", CallingConvention = CallingConvention.Cdecl)]
                internal static extern napi_status napi_create_string_latin1(IntPtr env,
                    [MarshalAs(UnmanagedType.LPUTF8Str)] string str, ulong length, IntPtr result);

                [SuppressUnmanagedCodeSecurity,
                 DllImport("NodeJS", EntryPoint = "napi_create_string_utf8", CallingConvention = CallingConvention.Cdecl)]
                internal static extern napi_status napi_create_string_utf8(IntPtr env,
                    [MarshalAs(UnmanagedType.LPUTF8Str)] string str, ulong length, IntPtr result);

                [SuppressUnmanagedCodeSecurity,
                 DllImport("NodeJS", EntryPoint = "napi_create_string_utf16", CallingConvention = CallingConvention.Cdecl)]
                internal static extern napi_status napi_create_string_utf16(IntPtr env,
                    [MarshalAs(UnmanagedType.LPWStr)] string str, ulong length, IntPtr result);

                [SuppressUnmanagedCodeSecurity,
                 DllImport("NodeJS", EntryPoint = "napi_create_symbol", CallingConvention = CallingConvention.Cdecl)]
                internal static extern napi_status napi_create_symbol(IntPtr env, IntPtr description,
                    IntPtr result);

                [SuppressUnmanagedCodeSecurity,
                 DllImport("NodeJS", EntryPoint = "napi_create_function", CallingConvention = CallingConvention.Cdecl)]
                internal static extern napi_status napi_create_function(IntPtr env,
                    [MarshalAs(UnmanagedType.LPUTF8Str)] string utf8name, ulong length, IntPtr cb, IntPtr data, IntPtr result);

                [SuppressUnmanagedCodeSecurity,
                 DllImport("NodeJS", EntryPoint = "napi_create_error", CallingConvention = CallingConvention.Cdecl)]
                internal static extern napi_status napi_create_error(IntPtr env, IntPtr code, IntPtr msg,
                    IntPtr result);

                [SuppressUnmanagedCodeSecurity,
                 DllImport("NodeJS", EntryPoint = "napi_create_type_error", CallingConvention = CallingConvention.Cdecl)]
                internal static extern napi_status napi_create_type_error(IntPtr env, IntPtr code, IntPtr msg,
                    IntPtr result);

                [SuppressUnmanagedCodeSecurity,
                 DllImport("NodeJS", EntryPoint = "napi_create_range_error", CallingConvention = CallingConvention.Cdecl)]
                internal static extern napi_status napi_create_range_error(IntPtr env, IntPtr code,
                    IntPtr msg, IntPtr result);

                [SuppressUnmanagedCodeSecurity,
                 DllImport("NodeJS", EntryPoint = "napi_typeof", CallingConvention = CallingConvention.Cdecl)]
                internal static extern napi_status napi_typeof(IntPtr env, IntPtr value,
                    napi_valuetype* result);

                [SuppressUnmanagedCodeSecurity,
                 DllImport("NodeJS", EntryPoint = "napi_get_value_double", CallingConvention = CallingConvention.Cdecl)]
                internal static extern napi_status napi_get_value_double(IntPtr env, IntPtr value,
                    double* result);

                [SuppressUnmanagedCodeSecurity,
                 DllImport("NodeJS", EntryPoint = "napi_get_value_int32", CallingConvention = CallingConvention.Cdecl)]
                internal static extern napi_status napi_get_value_int32(IntPtr env, IntPtr value, int* result);

                [SuppressUnmanagedCodeSecurity,
                 DllImport("NodeJS", EntryPoint = "napi_get_value_uint32", CallingConvention = CallingConvention.Cdecl)]
                internal static extern napi_status
                    napi_get_value_uint32(IntPtr env, IntPtr value, uint* result);

                [SuppressUnmanagedCodeSecurity,
                 DllImport("NodeJS", EntryPoint = "napi_get_value_int64", CallingConvention = CallingConvention.Cdecl)]
                internal static extern napi_status napi_get_value_int64(IntPtr env, IntPtr value, long* result);

                [SuppressUnmanagedCodeSecurity,
                 DllImport("NodeJS", EntryPoint = "napi_get_value_bool", CallingConvention = CallingConvention.Cdecl)]
                internal static extern napi_status napi_get_value_bool(IntPtr env, IntPtr value, bool* result);

                [SuppressUnmanagedCodeSecurity,
                 DllImport("NodeJS", EntryPoint = "napi_get_value_string_latin1", CallingConvention = CallingConvention.Cdecl)]
                internal static extern napi_status napi_get_value_string_latin1(IntPtr env, IntPtr value,
                    sbyte* buf, ulong bufsize, ulong* result);

                [SuppressUnmanagedCodeSecurity,
                 DllImport("NodeJS", EntryPoint = "napi_get_value_string_utf8", CallingConvention = CallingConvention.Cdecl)]
                internal static extern napi_status napi_get_value_string_utf8(IntPtr env, IntPtr value,
                    sbyte* buf, ulong bufsize, ulong* result);

                [SuppressUnmanagedCodeSecurity,
                 DllImport("NodeJS", EntryPoint = "napi_get_value_string_utf16", CallingConvention = CallingConvention.Cdecl)]
                internal static extern napi_status napi_get_value_string_utf16(IntPtr env, IntPtr value,
                    char* buf, ulong bufsize, ulong* result);

                [SuppressUnmanagedCodeSecurity,
                 DllImport("NodeJS", EntryPoint = "napi_coerce_to_bool", CallingConvention = CallingConvention.Cdecl)]
                internal static extern napi_status napi_coerce_to_bool(IntPtr env, IntPtr value,
                    IntPtr result);

                [SuppressUnmanagedCodeSecurity,
                 DllImport("NodeJS", EntryPoint = "napi_coerce_to_number", CallingConvention = CallingConvention.Cdecl)]
                internal static extern napi_status napi_coerce_to_number(IntPtr env, IntPtr value,
                    IntPtr result);

                [SuppressUnmanagedCodeSecurity,
                 DllImport("NodeJS", EntryPoint = "napi_coerce_to_object", CallingConvention = CallingConvention.Cdecl)]
                internal static extern napi_status napi_coerce_to_object(IntPtr env, IntPtr value,
                    IntPtr result);

                [SuppressUnmanagedCodeSecurity,
                 DllImport("NodeJS", EntryPoint = "napi_coerce_to_string", CallingConvention = CallingConvention.Cdecl)]
                internal static extern napi_status napi_coerce_to_string(IntPtr env, IntPtr value,
                    IntPtr result);

                [SuppressUnmanagedCodeSecurity,
                 DllImport("NodeJS", EntryPoint = "napi_get_prototype", CallingConvention = CallingConvention.Cdecl)]
                internal static extern napi_status napi_get_prototype(IntPtr env, IntPtr @object,
                    IntPtr result);

                [SuppressUnmanagedCodeSecurity,
                 DllImport("NodeJS", EntryPoint = "napi_get_property_names", CallingConvention = CallingConvention.Cdecl)]
                internal static extern napi_status napi_get_property_names(IntPtr env, IntPtr @object,
                    IntPtr result);

                [SuppressUnmanagedCodeSecurity,
                 DllImport("NodeJS", EntryPoint = "napi_set_property", CallingConvention = CallingConvention.Cdecl)]
                internal static extern napi_status napi_set_property(IntPtr env, IntPtr @object, IntPtr key,
                    IntPtr value);

                [SuppressUnmanagedCodeSecurity,
                 DllImport("NodeJS", EntryPoint = "napi_has_property", CallingConvention = CallingConvention.Cdecl)]
                internal static extern napi_status napi_has_property(IntPtr env, IntPtr @object, IntPtr key,
                    bool* result);

                [SuppressUnmanagedCodeSecurity,
                 DllImport("NodeJS", EntryPoint = "napi_get_property", CallingConvention = CallingConvention.Cdecl)]
                internal static extern napi_status napi_get_property(IntPtr env, IntPtr @object, IntPtr key,
                    IntPtr result);

                [SuppressUnmanagedCodeSecurity,
                 DllImport("NodeJS", EntryPoint = "napi_delete_property", CallingConvention = CallingConvention.Cdecl)]
                internal static extern napi_status napi_delete_property(IntPtr env, IntPtr @object,
                    IntPtr key, bool* result);

                [SuppressUnmanagedCodeSecurity,
                 DllImport("NodeJS", EntryPoint = "napi_has_own_property", CallingConvention = CallingConvention.Cdecl)]
                internal static extern napi_status napi_has_own_property(IntPtr env, IntPtr @object,
                    IntPtr key, bool* result);

                [SuppressUnmanagedCodeSecurity,
                 DllImport("NodeJS", EntryPoint = "napi_set_named_property", CallingConvention = CallingConvention.Cdecl)]
                internal static extern napi_status napi_set_named_property(IntPtr env, IntPtr @object,
                    [MarshalAs(UnmanagedType.LPUTF8Str)] string utf8name, IntPtr value);

                [SuppressUnmanagedCodeSecurity,
                 DllImport("NodeJS", EntryPoint = "napi_has_named_property", CallingConvention = CallingConvention.Cdecl)]
                internal static extern napi_status napi_has_named_property(IntPtr env, IntPtr @object,
                    [MarshalAs(UnmanagedType.LPUTF8Str)] string utf8name, bool* result);

                [SuppressUnmanagedCodeSecurity,
                 DllImport("NodeJS", EntryPoint = "napi_get_named_property", CallingConvention = CallingConvention.Cdecl)]
                internal static extern napi_status napi_get_named_property(IntPtr env, IntPtr @object,
                    [MarshalAs(UnmanagedType.LPUTF8Str)] string utf8name, IntPtr result);

                [SuppressUnmanagedCodeSecurity,
                 DllImport("NodeJS", EntryPoint = "napi_set_element", CallingConvention = CallingConvention.Cdecl)]
                internal static extern napi_status napi_set_element(IntPtr env, IntPtr @object, uint index,
                    IntPtr value);

                [SuppressUnmanagedCodeSecurity,
                 DllImport("NodeJS", EntryPoint = "napi_has_element", CallingConvention = CallingConvention.Cdecl)]
                internal static extern napi_status napi_has_element(IntPtr env, IntPtr @object, uint index,
                    bool* result);

                [SuppressUnmanagedCodeSecurity,
                 DllImport("NodeJS", EntryPoint = "napi_get_element", CallingConvention = CallingConvention.Cdecl)]
                internal static extern napi_status napi_get_element(IntPtr env, IntPtr @object, uint index,
                    IntPtr result);

                [SuppressUnmanagedCodeSecurity,
                 DllImport("NodeJS", EntryPoint = "napi_delete_element", CallingConvention = CallingConvention.Cdecl)]
                internal static extern napi_status napi_delete_element(IntPtr env, IntPtr @object, uint index,
                    bool* result);

                [SuppressUnmanagedCodeSecurity,
                 DllImport("NodeJS", EntryPoint = "napi_define_properties", CallingConvention = CallingConvention.Cdecl)]
                internal static extern napi_status napi_define_properties(IntPtr env, IntPtr @object,
                    ulong property_count, IntPtr properties);

                [SuppressUnmanagedCodeSecurity,
                 DllImport("NodeJS", EntryPoint = "napi_is_array", CallingConvention = CallingConvention.Cdecl)]
                internal static extern napi_status napi_is_array(IntPtr env, IntPtr value, bool* result);

                [SuppressUnmanagedCodeSecurity,
                 DllImport("NodeJS", EntryPoint = "napi_get_array_length", CallingConvention = CallingConvention.Cdecl)]
                internal static extern napi_status
                    napi_get_array_length(IntPtr env, IntPtr value, uint* result);

                [SuppressUnmanagedCodeSecurity,
                 DllImport("NodeJS", EntryPoint = "napi_strict_equals", CallingConvention = CallingConvention.Cdecl)]
                internal static extern napi_status napi_strict_equals(IntPtr env, IntPtr lhs, IntPtr rhs,
                    bool* result);

                [SuppressUnmanagedCodeSecurity,
                 DllImport("NodeJS", EntryPoint = "napi_call_function", CallingConvention = CallingConvention.Cdecl)]
                internal static extern napi_status napi_call_function(IntPtr env, IntPtr recv, IntPtr func,
                    ulong argc, IntPtr argv, IntPtr result);

                [SuppressUnmanagedCodeSecurity,
                 DllImport("NodeJS", EntryPoint = "napi_new_instance", CallingConvention = CallingConvention.Cdecl)]
                internal static extern napi_status napi_new_instance(IntPtr env, IntPtr constructor,
                    ulong argc, IntPtr argv, IntPtr result);

                [SuppressUnmanagedCodeSecurity,
                 DllImport("NodeJS", EntryPoint = "napi_instanceof", CallingConvention = CallingConvention.Cdecl)]
                internal static extern napi_status napi_instanceof(IntPtr env, IntPtr @object,
                    IntPtr constructor, bool* result);

                [SuppressUnmanagedCodeSecurity,
                 DllImport("NodeJS", EntryPoint = "napi_get_cb_info", CallingConvention = CallingConvention.Cdecl)]
                internal static extern napi_status napi_get_cb_info(IntPtr env, IntPtr cbinfo, ulong* argc,
                    IntPtr argv, IntPtr this_arg, IntPtr data);

                [SuppressUnmanagedCodeSecurity,
                 DllImport("NodeJS", EntryPoint = "napi_get_new_target", CallingConvention = CallingConvention.Cdecl)]
                internal static extern napi_status napi_get_new_target(IntPtr env, IntPtr cbinfo,
                    IntPtr result);

                [SuppressUnmanagedCodeSecurity,
                 DllImport("NodeJS", EntryPoint = "napi_define_class", CallingConvention = CallingConvention.Cdecl)]
                internal static extern napi_status napi_define_class(IntPtr env,
                    [MarshalAs(UnmanagedType.LPUTF8Str)] string utf8name, ulong length, IntPtr constructor, void* data,
                    ulong property_count,
                    IntPtr properties, IntPtr result);

                [SuppressUnmanagedCodeSecurity,
                 DllImport("NodeJS", EntryPoint = "napi_wrap", CallingConvention = CallingConvention.Cdecl)]
                internal static extern napi_status napi_wrap(IntPtr env, IntPtr js_object,
                    IntPtr native_object, IntPtr finalize_cb, IntPtr finalize_hint, IntPtr result);

                [SuppressUnmanagedCodeSecurity,
                 DllImport("NodeJS", EntryPoint = "napi_unwrap", CallingConvention = CallingConvention.Cdecl)]
                internal static extern napi_status napi_unwrap(IntPtr env, IntPtr js_object, void** result);

                [SuppressUnmanagedCodeSecurity,
                 DllImport("NodeJS", EntryPoint = "napi_remove_wrap", CallingConvention = CallingConvention.Cdecl)]
                internal static extern napi_status napi_remove_wrap(IntPtr env, IntPtr js_object,
                    void** result);

                [SuppressUnmanagedCodeSecurity,
                 DllImport("NodeJS", EntryPoint = "napi_create_external", CallingConvention = CallingConvention.Cdecl)]
                internal static extern napi_status napi_create_external(IntPtr env, IntPtr data,
                    IntPtr finalize_cb, IntPtr finalize_hint, IntPtr result);

                [SuppressUnmanagedCodeSecurity,
                 DllImport("NodeJS", EntryPoint = "napi_get_value_external", CallingConvention = CallingConvention.Cdecl)]
                internal static extern napi_status napi_get_value_external(IntPtr env, IntPtr value,
                    void** result);

                [SuppressUnmanagedCodeSecurity,
                 DllImport("NodeJS", EntryPoint = "napi_create_reference", CallingConvention = CallingConvention.Cdecl)]
                internal static extern napi_status napi_create_reference(IntPtr env, IntPtr value,
                    uint initial_refcount, IntPtr result);

                [SuppressUnmanagedCodeSecurity,
                 DllImport("NodeJS", EntryPoint = "napi_delete_reference", CallingConvention = CallingConvention.Cdecl)]
                internal static extern napi_status napi_delete_reference(IntPtr env, IntPtr @ref);

                [SuppressUnmanagedCodeSecurity,
                 DllImport("NodeJS", EntryPoint = "napi_reference_ref", CallingConvention = CallingConvention.Cdecl)]
                internal static extern napi_status napi_reference_ref(IntPtr env, IntPtr @ref, uint* result);

                [SuppressUnmanagedCodeSecurity,
                 DllImport("NodeJS", EntryPoint = "napi_reference_unref", CallingConvention = CallingConvention.Cdecl)]
                internal static extern napi_status napi_reference_unref(IntPtr env, IntPtr @ref, uint* result);

                [SuppressUnmanagedCodeSecurity,
                 DllImport("NodeJS", EntryPoint = "napi_get_reference_value", CallingConvention = CallingConvention.Cdecl)]
                internal static extern napi_status napi_get_reference_value(IntPtr env, IntPtr @ref,
                    IntPtr result);

                [SuppressUnmanagedCodeSecurity,
                 DllImport("NodeJS", EntryPoint = "napi_open_handle_scope", CallingConvention = CallingConvention.Cdecl)]
                internal static extern napi_status napi_open_handle_scope(IntPtr env, IntPtr result);

                [SuppressUnmanagedCodeSecurity,
                 DllImport("NodeJS", EntryPoint = "napi_close_handle_scope", CallingConvention = CallingConvention.Cdecl)]
                internal static extern napi_status napi_close_handle_scope(IntPtr env, IntPtr scope);

                [SuppressUnmanagedCodeSecurity,
                 DllImport("NodeJS", EntryPoint = "napi_open_escapable_handle_scope",
                     CallingConvention = CallingConvention.Cdecl)]
                internal static extern napi_status napi_open_escapable_handle_scope(IntPtr env, IntPtr result);

                [SuppressUnmanagedCodeSecurity,
                 DllImport("NodeJS", EntryPoint = "napi_close_escapable_handle_scope",
                     CallingConvention = CallingConvention.Cdecl)]
                internal static extern napi_status napi_close_escapable_handle_scope(IntPtr env, IntPtr scope);

                [SuppressUnmanagedCodeSecurity,
                 DllImport("NodeJS", EntryPoint = "napi_escape_handle", CallingConvention = CallingConvention.Cdecl)]
                internal static extern napi_status napi_escape_handle(IntPtr env, IntPtr scope,
                    IntPtr escapee, IntPtr result);

                [SuppressUnmanagedCodeSecurity,
                 DllImport("NodeJS", EntryPoint = "napi_throw", CallingConvention = CallingConvention.Cdecl)]
                internal static extern napi_status napi_throw(IntPtr env, IntPtr error);

                [SuppressUnmanagedCodeSecurity,
                 DllImport("NodeJS", EntryPoint = "napi_throw_error", CallingConvention = CallingConvention.Cdecl)]
                internal static extern napi_status napi_throw_error(IntPtr env,
                    [MarshalAs(UnmanagedType.LPUTF8Str)] string code, [MarshalAs(UnmanagedType.LPUTF8Str)] string msg);

                [SuppressUnmanagedCodeSecurity,
                 DllImport("NodeJS", EntryPoint = "napi_throw_type_error", CallingConvention = CallingConvention.Cdecl)]
                internal static extern napi_status napi_throw_type_error(IntPtr env,
                    [MarshalAs(UnmanagedType.LPUTF8Str)] string code, [MarshalAs(UnmanagedType.LPUTF8Str)] string msg);

                [SuppressUnmanagedCodeSecurity,
                 DllImport("NodeJS", EntryPoint = "napi_throw_range_error", CallingConvention = CallingConvention.Cdecl)]
                internal static extern napi_status napi_throw_range_error(IntPtr env,
                    [MarshalAs(UnmanagedType.LPUTF8Str)] string code, [MarshalAs(UnmanagedType.LPUTF8Str)] string msg);

                [SuppressUnmanagedCodeSecurity,
                 DllImport("NodeJS", EntryPoint = "napi_is_error", CallingConvention = CallingConvention.Cdecl)]
                internal static extern napi_status napi_is_error(IntPtr env, IntPtr value, bool* result);

                [SuppressUnmanagedCodeSecurity,
                 DllImport("NodeJS", EntryPoint = "napi_is_exception_pending", CallingConvention = CallingConvention.Cdecl)]
                internal static extern napi_status napi_is_exception_pending(IntPtr env, bool* result);

                [SuppressUnmanagedCodeSecurity,
                 DllImport("NodeJS", EntryPoint = "napi_get_and_clear_last_exception",
                     CallingConvention = CallingConvention.Cdecl)]
                internal static extern napi_status napi_get_and_clear_last_exception(IntPtr env, IntPtr result);

                [SuppressUnmanagedCodeSecurity,
                 DllImport("NodeJS", EntryPoint = "napi_is_arraybuffer", CallingConvention = CallingConvention.Cdecl)]
                internal static extern napi_status napi_is_arraybuffer(IntPtr env, IntPtr value, bool* result);

                [SuppressUnmanagedCodeSecurity,
                 DllImport("NodeJS", EntryPoint = "napi_create_arraybuffer", CallingConvention = CallingConvention.Cdecl)]
                internal static extern napi_status napi_create_arraybuffer(IntPtr env, ulong byte_length,
                    void** data, IntPtr result);

                [SuppressUnmanagedCodeSecurity,
                 DllImport("NodeJS", EntryPoint = "napi_create_external_arraybuffer", CallingConvention = CallingConvention.Cdecl)]
                internal static extern napi_status napi_create_external_arraybuffer(IntPtr env,
                    IntPtr external_data, ulong byte_length, IntPtr finalize_cb, IntPtr finalize_hint, IntPtr result);

                [SuppressUnmanagedCodeSecurity,
                 DllImport("NodeJS", EntryPoint = "napi_get_arraybuffer_info", CallingConvention = CallingConvention.Cdecl)]
                internal static extern napi_status napi_get_arraybuffer_info(IntPtr env, IntPtr arraybuffer,
                    void** data, ulong* byte_length);

                [SuppressUnmanagedCodeSecurity,
                 DllImport("NodeJS", EntryPoint = "napi_is_typedarray", CallingConvention = CallingConvention.Cdecl)]
                internal static extern napi_status napi_is_typedarray(IntPtr env, IntPtr value, bool* result);

                [SuppressUnmanagedCodeSecurity, DllImport("NodeJS", EntryPoint = "napi_create_typedarray", CallingConvention = CallingConvention.Cdecl)]
                internal static extern napi_status napi_create_typedarray(IntPtr env,
                    napi_typedarray_type type, ulong length, IntPtr arraybuffer, ulong byte_offset,
                    IntPtr result);

                [SuppressUnmanagedCodeSecurity,
                 DllImport("NodeJS", EntryPoint = "napi_get_typedarray_info", CallingConvention = CallingConvention.Cdecl)]
                internal static extern napi_status napi_get_typedarray_info(IntPtr env, IntPtr typedarray,
                    napi_typedarray_type* type, ulong* length, void** data, IntPtr arraybuffer,
                    ulong* byte_offset);

                [SuppressUnmanagedCodeSecurity,
                 DllImport("NodeJS", EntryPoint = "napi_create_dataview", CallingConvention = CallingConvention.Cdecl)]
                internal static extern napi_status napi_create_dataview(IntPtr env, ulong length,
                    IntPtr arraybuffer, ulong byte_offset, IntPtr result);

                [SuppressUnmanagedCodeSecurity,
                 DllImport("NodeJS", EntryPoint = "napi_is_dataview", CallingConvention = CallingConvention.Cdecl)]
                internal static extern napi_status napi_is_dataview(IntPtr env, IntPtr value, bool* result);

                [SuppressUnmanagedCodeSecurity,
                 DllImport("NodeJS", EntryPoint = "napi_get_dataview_info", CallingConvention = CallingConvention.Cdecl)]
                internal static extern napi_status napi_get_dataview_info(IntPtr env, IntPtr dataview,
                    ulong* bytelength, void** data, IntPtr arraybuffer, ulong* byte_offset);

                [SuppressUnmanagedCodeSecurity,
                 DllImport("NodeJS", EntryPoint = "napi_get_version", CallingConvention = CallingConvention.Cdecl)]
                internal static extern napi_status napi_get_version(IntPtr env, uint* result);

                [SuppressUnmanagedCodeSecurity,
                 DllImport("NodeJS", EntryPoint = "napi_create_promise", CallingConvention = CallingConvention.Cdecl)]
                internal static extern napi_status napi_create_promise(IntPtr env, IntPtr deferred,
                    IntPtr promise);

                [SuppressUnmanagedCodeSecurity,
                 DllImport("NodeJS", EntryPoint = "napi_resolve_deferred", CallingConvention = CallingConvention.Cdecl)]
                internal static extern napi_status napi_resolve_deferred(IntPtr env, IntPtr deferred,
                    IntPtr resolution);

                [SuppressUnmanagedCodeSecurity,
                 DllImport("NodeJS", EntryPoint = "napi_reject_deferred", CallingConvention = CallingConvention.Cdecl)]
                internal static extern napi_status napi_reject_deferred(IntPtr env, IntPtr deferred,
                    IntPtr rejection);

                [SuppressUnmanagedCodeSecurity,
                 DllImport("NodeJS", EntryPoint = "napi_is_promise", CallingConvention = CallingConvention.Cdecl)]
                internal static extern napi_status napi_is_promise(IntPtr env, IntPtr value, bool* is_promise);

                [SuppressUnmanagedCodeSecurity,
                 DllImport("NodeJS", EntryPoint = "napi_run_script", CallingConvention = CallingConvention.Cdecl)]
                internal static extern napi_status napi_run_script(IntPtr env, IntPtr script, IntPtr result);

                [SuppressUnmanagedCodeSecurity,
                 DllImport("NodeJS", EntryPoint = "napi_adjust_external_memory", CallingConvention = CallingConvention.Cdecl)]
                internal static extern napi_status napi_adjust_external_memory(IntPtr env, long change_in_bytes,
                    long* adjusted_value);

                [SuppressUnmanagedCodeSecurity,
                 DllImport("NodeJS", EntryPoint = "napi_create_date", CallingConvention = CallingConvention.Cdecl)]
                internal static extern napi_status napi_create_date(IntPtr env, double time, IntPtr result);

                [SuppressUnmanagedCodeSecurity,
                 DllImport("NodeJS", EntryPoint = "napi_is_date", CallingConvention = CallingConvention.Cdecl)]
                internal static extern napi_status napi_is_date(IntPtr env, IntPtr value, bool* is_date);

                [SuppressUnmanagedCodeSecurity,
                 DllImport("NodeJS", EntryPoint = "napi_get_date_value", CallingConvention = CallingConvention.Cdecl)]
                internal static extern napi_status
                    napi_get_date_value(IntPtr env, IntPtr value, double* result);

                [SuppressUnmanagedCodeSecurity,
                 DllImport("NodeJS", EntryPoint = "napi_add_finalizer", CallingConvention = CallingConvention.Cdecl)]
                internal static extern napi_status napi_add_finalizer(IntPtr env, IntPtr js_object,
                    IntPtr native_object, IntPtr finalize_cb, IntPtr finalize_hint, IntPtr result);

                [SuppressUnmanagedCodeSecurity,
                 DllImport("NodeJS", EntryPoint = "napi_create_bigint_int64", CallingConvention = CallingConvention.Cdecl)]
                internal static extern napi_status napi_create_bigint_int64(IntPtr env, long value,
                    IntPtr result);

                [SuppressUnmanagedCodeSecurity,
                 DllImport("NodeJS", EntryPoint = "napi_create_bigint_uint64", CallingConvention = CallingConvention.Cdecl)]
                internal static extern napi_status napi_create_bigint_uint64(IntPtr env, ulong value,
                    IntPtr result);

                [SuppressUnmanagedCodeSecurity,
                 DllImport("NodeJS", EntryPoint = "napi_create_bigint_words", CallingConvention = CallingConvention.Cdecl)]
                internal static extern napi_status napi_create_bigint_words(IntPtr env, int sign_bit,
                    ulong word_count, ulong* words, IntPtr result);

                [SuppressUnmanagedCodeSecurity,
                 DllImport("NodeJS", EntryPoint = "napi_get_value_bigint_int64", CallingConvention = CallingConvention.Cdecl)]
                internal static extern napi_status napi_get_value_bigint_int64(IntPtr env, IntPtr value,
                    long* result, bool* lossless);

                [SuppressUnmanagedCodeSecurity,
                 DllImport("NodeJS", EntryPoint = "napi_get_value_bigint_uint64", CallingConvention = CallingConvention.Cdecl)]
                internal static extern napi_status napi_get_value_bigint_uint64(IntPtr env, IntPtr value,
                    ulong* result, bool* lossless);

                [SuppressUnmanagedCodeSecurity,
                 DllImport("NodeJS", EntryPoint = "napi_get_value_bigint_words", CallingConvention = CallingConvention.Cdecl)]
                internal static extern napi_status napi_get_value_bigint_words(IntPtr env, IntPtr value,
                    int* sign_bit, ulong* word_count, ulong* words);

                [SuppressUnmanagedCodeSecurity,
                 DllImport("NodeJS", EntryPoint = "napi_get_all_property_names", CallingConvention = CallingConvention.Cdecl)]
                internal static extern napi_status napi_get_all_property_names(IntPtr env, IntPtr @object,
                    napi_key_collection_mode key_mode, napi_key_filter key_filter,
                    napi_key_conversion key_conversion, IntPtr result);

                [SuppressUnmanagedCodeSecurity,
                 DllImport("NodeJS", EntryPoint = "napi_set_instance_data", CallingConvention = CallingConvention.Cdecl)]
                internal static extern napi_status napi_set_instance_data(IntPtr env, IntPtr data,
                    IntPtr finalize_cb, IntPtr finalize_hint);

                [SuppressUnmanagedCodeSecurity,
                 DllImport("NodeJS", EntryPoint = "napi_get_instance_data", CallingConvention = CallingConvention.Cdecl)]
                internal static extern napi_status napi_get_instance_data(IntPtr env, void** data);

                [SuppressUnmanagedCodeSecurity,
                 DllImport("NodeJS", EntryPoint = "napi_detach_arraybuffer", CallingConvention = CallingConvention.Cdecl)]
                internal static extern napi_status napi_detach_arraybuffer(IntPtr env, IntPtr arraybuffer);

                [SuppressUnmanagedCodeSecurity,
                 DllImport("NodeJS", EntryPoint = "napi_is_detached_arraybuffer", CallingConvention = CallingConvention.Cdecl)]
                internal static extern napi_status napi_is_detached_arraybuffer(IntPtr env, IntPtr value,
                    bool* result);

                [SuppressUnmanagedCodeSecurity,
                 DllImport("NodeJS", EntryPoint = "napi_type_tag_object", CallingConvention = CallingConvention.Cdecl)]
                internal static extern napi_status napi_type_tag_object(IntPtr env, IntPtr value,
                    IntPtr type_tag);

                [SuppressUnmanagedCodeSecurity,
                 DllImport("NodeJS", EntryPoint = "napi_check_object_type_tag", CallingConvention = CallingConvention.Cdecl)]
                internal static extern napi_status napi_check_object_type_tag(IntPtr env, IntPtr value,
                    IntPtr type_tag, bool* result);

                [SuppressUnmanagedCodeSecurity,
                 DllImport("NodeJS", EntryPoint = "napi_object_freeze", CallingConvention = CallingConvention.Cdecl)]
                internal static extern napi_status napi_object_freeze(IntPtr env, IntPtr @object);

                [SuppressUnmanagedCodeSecurity,
                 DllImport("NodeJS", EntryPoint = "napi_object_seal", CallingConvention = CallingConvention.Cdecl)]
                internal static extern napi_status napi_object_seal(IntPtr env, IntPtr @object);
            }
        }

        public INApiProvider.IJsNativeApiProvider JsNativeApi { get; } = new DllImportJsNativeApiProvider();
    }
}