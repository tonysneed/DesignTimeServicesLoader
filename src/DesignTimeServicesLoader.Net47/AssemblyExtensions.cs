using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DesignTimeServicesLoader.Net47
{
    public static class AssemblyExtensions
    {
        public static IEnumerable<TypeInfo> GetLoadableTypes(this Assembly assembly)
        {
            if (assembly == null) throw new ArgumentNullException(nameof(assembly));
            try
            {
                return assembly.DefinedTypes;
            }
            catch (ReflectionTypeLoadException e)
            {
                return e.Types.Where(t => t != null).Cast<TypeInfo>();
            }
        }
    }
}