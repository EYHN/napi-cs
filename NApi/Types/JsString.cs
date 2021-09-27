using System;
using System.Text;

namespace NApi.Types
{
  public sealed class JsString : JsValue
  {
    internal JsString(JsScope scope, IntPtr valuePtr) : base(scope, valuePtr)
    {
    }

    public static unsafe JsString Create(JsScope scope, string value)
    {
      IntPtr valuePtr = new IntPtr();
      NApi.ApiProvider.JsNativeApi.napi_create_string_utf8(scope.Env.EnvPtr, value, Defined.NAPI_AUTO_LENGTH, new IntPtr(&valuePtr)).ThrowIfFailed(scope);
      return new JsString(scope, valuePtr);
    }

    public override unsafe string ToString()
    {
      ulong length;
      NApi.ApiProvider.JsNativeApi.napi_get_value_string_utf8(Scope.Env.EnvPtr, ValuePtr, null, 0, &length).ThrowIfFailed(Scope);

      sbyte[] buf = new sbyte[length + 1];
      fixed (sbyte* bufStart = &buf[0])
      {
        NApi.ApiProvider.JsNativeApi.napi_get_value_string_utf8(Scope.Env.EnvPtr, ValuePtr, bufStart, (ulong)buf.Length, null).ThrowIfFailed(Scope);
        return new string(bufStart, 0, buf.Length - 1, Encoding.UTF8);
      }
    }
  }
}