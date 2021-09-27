using System;

namespace NApi.Attributes
{
  [AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
  public sealed class ModuleExportsAttribute : Attribute
  {
    public ModuleExportsAttribute()
    {
    }
  }
}