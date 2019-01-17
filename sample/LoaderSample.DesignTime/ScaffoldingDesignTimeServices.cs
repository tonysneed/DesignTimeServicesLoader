using System;
using System.Collections.Generic;
using System.IO;
using LoaderSample.Abstractions;
using LoaderSample.Services;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;

namespace LoaderSample.DesignTime
{
    public class ScaffoldingDesignTimeServices : IDesignTimeServices
    {
        public void ConfigureDesignTimeServices(IServiceCollection serviceCollection)
        {
            var myHelper = (helperName: "my-helper", helperFunction: (Action<TextWriter, Dictionary<string, object>, object[]>)MyHbsHelper);

            // Add optional Handlebars helpers
            serviceCollection.AddHandlebarsHelpers(myHelper);
            serviceCollection.AddTransient<IFoo, Foo>();
        }

        // Sample Handlebars helper
        void MyHbsHelper(TextWriter writer, Dictionary<string, object> context, object[] parameters)
        {
            writer.Write("// My Handlebars Helper");
        }
    }
}