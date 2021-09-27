using System;
using NApi.Exception;
using NApi.Utils;

namespace NApi.Types
{
  public sealed class JsScope : Disposable
  {
    private JsEnv _env;
    private IntPtr? _scopePtr;

    internal JsEnv Env
    {
      get
      {
        EnsureNotDisposed();
        return _env;
      }
    }

    internal IntPtr? ScopePtr
    {
      get
      {
        EnsureNotDisposed();
        return _scopePtr;
      }
    }

    internal JsScope(JsEnv env, IntPtr? scopePtr = null)
    {
      _env = env;
      _scopePtr = scopePtr;
    }

    public static JsScope FromPointer(JsEnv env, IntPtr? scopePtr)
    {
      return new(env, scopePtr);
    }

    public void EnsureNotDisposed()
    {
      if (Disposed)
      {
        throw new NApiException("Out of scope!");
      }
    }
  }
}