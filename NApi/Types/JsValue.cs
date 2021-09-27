using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace NApi.Types
{
  public abstract class JsValue
  {
    internal JsScope Scope { get; }

    internal IntPtr ValuePtr { get; }

    private HashSet<GCHandle> ManagedGCHandles = new();

    private static GCHandle? NApiFinalizeCallbackHandle;
    private static IntPtr? NApiFinalizeCallbackPtr;

    protected internal JsValue(JsScope scope, IntPtr valuePtr)
    {
      scope.EnsureNotDisposed();
      Scope = scope;
      ValuePtr = valuePtr;
    }

    internal static JsValue Create(JsScope scope, IntPtr valuePtr)
    {
      var valueType = Typeof(scope, valuePtr);
      return valueType switch
      {
        napi_valuetype.napi_number => new JsNumber(scope, valuePtr),
        napi_valuetype.napi_undefined => throw new NotImplementedException(),
        napi_valuetype.napi_null => throw new NotImplementedException(),
        napi_valuetype.napi_boolean => throw new NotImplementedException(),
        napi_valuetype.napi_string => new JsString(scope, valuePtr),
        napi_valuetype.napi_symbol => throw new NotImplementedException(),
        napi_valuetype.napi_object => new JsObject(scope, valuePtr),
        napi_valuetype.napi_function => new JsFunction(scope, valuePtr),
        napi_valuetype.napi_external => throw new NotImplementedException(),
        napi_valuetype.napi_bigint => throw new NotImplementedException(),
        _ => throw new ArgumentOutOfRangeException()
      };
    }

    private static unsafe napi_valuetype Typeof(JsScope scope, IntPtr valuePtr)
    {
      napi_valuetype valueType;
      NApi.ApiProvider.JsNativeApi.napi_typeof(scope.Env.EnvPtr, valuePtr, &valueType).ThrowIfFailed(scope);
      return valueType;
    }

    public void AttachGCHandle(GCHandle handle)
    {
      try
      {
        var handlePtr = GCHandle.ToIntPtr(handle);

        if (NApiFinalizeCallbackHandle == null || NApiFinalizeCallbackPtr == null)
        {
          var cb = (napi_finalize)NApiFinalize;
          NApiFinalizeCallbackHandle = GCHandle.Alloc(cb);
          NApiFinalizeCallbackPtr = Marshal.GetFunctionPointerForDelegate(cb);
        }

        NApi.ApiProvider.JsNativeApi.napi_add_finalizer(Scope.Env.EnvPtr, ValuePtr, handlePtr, NApiFinalizeCallbackPtr.Value, IntPtr.Zero, IntPtr.Zero).ThrowIfFailed(Scope);
      }
      catch
      {
        handle.Free();
        throw;
      }

      ManagedGCHandles.Add(handle);
    }

    private delegate void napi_finalize(IntPtr envPtr, IntPtr finalizeDataPtr, IntPtr finalizeHintPtr);

    private void NApiFinalize(IntPtr envPtr, IntPtr finalizeDataPtr, IntPtr finalizeHintPtr)
    {
      var handle = GCHandle.FromIntPtr(finalizeDataPtr);
      handle.Free();
      ManagedGCHandles.Remove(handle);
    }
  }
}