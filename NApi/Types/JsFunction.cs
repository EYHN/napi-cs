using System;
using System.Runtime.InteropServices;

namespace NApi.Types
{
  public sealed class JsFunction : JsValue
  {
    private static IntPtr? NApiCallbackPtr;
    private static GCHandle? NApiCallbackHandle;

    internal JsFunction(JsScope scope, IntPtr valuePtr) : base(scope, valuePtr)
    {
    }

    public static unsafe JsFunction Create(JsScope scope, string name, user_callback callback)
    {
      IntPtr valuePtr = new IntPtr();

      if (NApiCallbackHandle == null || NApiCallbackPtr == null)
      {
        var napiCallback = (napi_callback)NapiCallback;
        NApiCallbackHandle = GCHandle.Alloc(napiCallback);
        NApiCallbackPtr = Marshal.GetFunctionPointerForDelegate(napiCallback);
      }

      var userCallbackHandle = GCHandle.Alloc(callback);
      NApi.ApiProvider.JsNativeApi.napi_create_function(scope.Env.EnvPtr, name, Defined.NAPI_AUTO_LENGTH, NApiCallbackPtr.Value, GCHandle.ToIntPtr(userCallbackHandle), new IntPtr(&valuePtr)).ThrowIfFailed(scope);
      var jsFunction = new JsFunction(scope, valuePtr);
      jsFunction.AttachGCHandle(userCallbackHandle);

      return jsFunction;
    }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate IntPtr napi_callback(IntPtr envPtr, IntPtr infoPtr);

    public delegate JsValue user_callback(JsScope scope, JsValue @this, JsValue[] args);

    private static unsafe IntPtr NapiCallback(IntPtr envPtr, IntPtr infoPtr)
    {
      try
      {
        using (var scope = new JsScope(new JsEnv(envPtr)))
        {
          ulong length = 0;
          IntPtr thisPtr = new IntPtr();
          IntPtr cbPtr = new IntPtr();
          NApi.ApiProvider.JsNativeApi.napi_get_cb_info(scope.Env.EnvPtr, infoPtr, &length, IntPtr.Zero, new IntPtr(&thisPtr), new IntPtr(&cbPtr)).ThrowIfFailed(scope);

          IntPtr[] argsPtr = new IntPtr[length];
          if (length != 0)
          {
            fixed (IntPtr* argsStart = &argsPtr[0])
            {
              NApi.ApiProvider.JsNativeApi.napi_get_cb_info(scope.Env.EnvPtr, infoPtr, &length, new IntPtr(argsStart), IntPtr.Zero, IntPtr.Zero).ThrowIfFailed(scope);
            }
          }

          JsValue[] args = new JsValue[length];
          for (ulong i = 0; i < length; i++)
          {
            args[i] = JsValue.Create(scope, argsPtr[i]);
          }

          JsValue @this = JsValue.Create(scope, thisPtr);
          var cb = (user_callback)GCHandle.FromIntPtr(cbPtr).Target!;
          var result = cb(scope, @this, args).ValuePtr;
          return result;
        }
      }
      catch (System.Exception e)
      {
        Console.Error.WriteLine(e);
        throw;
      }
    }
  }
}