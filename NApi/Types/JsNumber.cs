using System;

namespace NApi.Types
{
  public sealed class JsNumber : JsValue
  {
    internal JsNumber(JsScope scope, IntPtr valuePtr) : base(scope, valuePtr)
    {
    }

    public static unsafe JsNumber Create(JsScope scope, double value)
    {
      IntPtr valuePtr = new IntPtr();
      NApi.ApiProvider.JsNativeApi.napi_create_double(scope.Env.EnvPtr, value, new IntPtr(&valuePtr)).ThrowIfFailed(scope);
      return new JsNumber(scope, valuePtr);
    }

    public unsafe double ToDouble()
    {
      double result;
      NApi.ApiProvider.JsNativeApi.napi_get_value_double(Scope.Env.EnvPtr, ValuePtr, &result).ThrowIfFailed(Scope);
      return result;
    }
  }
}