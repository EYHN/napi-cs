using System;

namespace NApi.Types
{
  public sealed class JsObject : JsValue
  {
    internal JsObject(JsScope scope, IntPtr valuePtr) : base(scope, valuePtr)
    {
    }

    public JsValue this[JsValue key]
    {
      get => Get(key);
      set => Set(key, value);
    }

    public static unsafe JsObject Create(JsScope scope)
    {
      IntPtr valuePtr = new IntPtr();
      NApi.ApiProvider.JsNativeApi.napi_create_object(scope.Env.EnvPtr, new IntPtr(&valuePtr)).ThrowIfFailed(scope);
      return new JsObject(scope, valuePtr);
    }

    public unsafe JsValue Get(JsValue key)
    {
      IntPtr resultPtr = new IntPtr();
      NApi.ApiProvider.JsNativeApi.napi_get_property(Scope.Env.EnvPtr, ValuePtr, key.ValuePtr, new IntPtr(&resultPtr)).ThrowIfFailed(Scope);
      return JsValue.Create(Scope, resultPtr);
    }

    public void Set(JsValue key, JsValue value)
    {
      NApi.ApiProvider.JsNativeApi.napi_set_property(Scope.Env.EnvPtr, ValuePtr, key.ValuePtr, value.ValuePtr).ThrowIfFailed(Scope);
    }

    public static JsObject FromPointer(JsScope scope, IntPtr valuePtr)
    {
      return new(scope, valuePtr);
    }
  }
}