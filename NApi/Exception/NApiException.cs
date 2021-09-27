using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using NApi.Types;

namespace NApi.Exception
{
  public class NApiException : System.Exception
  {
    public override string Message { get; }

    public unsafe NApiException(napi_status status)
    {
      Message = status.ToString();
    }

    public unsafe NApiException(string message)
    {
      Message = message;
    }
  }
}