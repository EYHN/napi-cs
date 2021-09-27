using NApi.Types;
using NApi.Attributes;

namespace Example
{
  public class Example
  {
    [ModuleExports]
    public static void ModuleExports(JsScope scope, JsObject exports)
    {
      exports.Set(JsString.Create(scope, "hello"), JsString.Create(scope, "world"));
    }
  }
}