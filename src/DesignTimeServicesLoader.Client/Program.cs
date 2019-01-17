using System;
using System.Diagnostics;
using DesignTimeServicesLoader.Net47;
using Microsoft.Extensions.DependencyInjection;

namespace DesignTimeServicesLoader.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();
            var assemblyPath = @"..\..\..\..\sample\LoaderSample.DesignTime\bin\Debug\netstandard2.0\LoaderSample.DesignTime.dll";
            ServicesLoader.ConfigureDesignTimeServices(assemblyPath, services);
            Debug.Assert(services.Count > 0);
            Console.WriteLine("Design Time services loaded!");
        }
    }
}
