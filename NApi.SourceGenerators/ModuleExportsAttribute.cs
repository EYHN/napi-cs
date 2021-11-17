using System;

namespace NApi.SourceGenerators
{
    [AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
    sealed class ModuleExportsAttribute : Attribute
    {
        public ModuleExportsAttribute()
        {
        }
    }
}