using System;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;

namespace DesignTimeServicesLoader.Net47
{
    public static class ServicesLoader
    {
        public static void ConfigureDesignTimeServices(string assemblyPath, IServiceCollection services)
        {
            var assembly = Assembly.LoadFrom(assemblyPath);
            var types = assembly.GetLoadableTypes();
            var designTimeServicesType = types
                .Where(t => typeof(IDesignTimeServices).GetTypeInfo().IsAssignableFrom(t)).Select(t => t.AsType())
                .FirstOrDefault();
            if (designTimeServicesType == null) return;
            var designTimeServices = (IDesignTimeServices)Activator.CreateInstance(designTimeServicesType);
            designTimeServices.ConfigureDesignTimeServices(services);
        }
    }
}
