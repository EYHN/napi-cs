using System;

namespace NApi.SourceGenerators.AOT
{
    [AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
    sealed class ModuleExportsAttribute : Attribute
    {
        public ModuleExportsAttribute()
        {
        }
    }
}