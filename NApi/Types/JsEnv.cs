using System;

namespace NApi.Types
{
  public sealed class JsEnv
  {
    internal IntPtr EnvPtr { get; }

    internal JsEnv(IntPtr envPtr)
    {
      EnvPtr = envPtr;
    }

    public static JsEnv FromPointer(IntPtr envPtr)
    {
      return new(envPtr);
    }
  }
}