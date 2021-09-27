using NApi.Types;
using NApi.Attributes;
using System;
using System.Threading.Tasks;
using System.Linq;

namespace Example
{
  public class Example
  {
    [ModuleExports]
    public static void ModuleExports(JsScope scope, JsObject exports)
    {
      exports.Set(JsString.Create(scope, "sum"), JsFunction.Create(scope, "sum", (scope, @this, args) => JsNumber.Create(scope, ((JsNumber)args[0]).ToDouble() + ((JsNumber)args[1]).ToDouble())));
      exports.Set(JsString.Create(scope, "helloPlusWorld"), JsFunction.Create(scope, "helloPlusWorld", (scope, @this, args) => JsString.Create(scope, ((JsString)args[0]).ToString() + " world")));
      exports.Set(JsString.Create(scope, "add"), JsFunction.Create(scope, "add", (scope, @this, args) =>
      {
        var arg1 = ((JsString)args[0]).ToString();
        return JsFunction.Create(scope, "hoc", (scope, @this, args) =>
        {
          var arg2 = ((JsString)args[0]).ToString();
          return JsString.Create(scope, arg1 + arg2);
        });
      }));
    }
  }
}