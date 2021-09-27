using System;
using NApi.Exception;
using NApi.Types;

namespace NApi
{
  public static class Extensions
  {
    public static void ThrowIfFailed(this napi_status status, JsScope scope)
    {
      if (status != napi_status.napi_ok)
      {
        throw new NApiException(status);
      }
    }

    public static void ThrowIfFailed(this napi_status status, string message)
    {
      if (status != napi_status.napi_ok)
      {
        throw new NApiException(message);
      }
    }
  }
}