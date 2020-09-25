using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using RebusAzureFunction;
using RebusAzureFunction.Config;
using System;
using System.Globalization;
using System.IO;
using System.Reflection;

[assembly: FunctionsStartup(typeof(Startup))]
namespace RebusAzureFunction
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            CultureInfo.CurrentCulture = new CultureInfo("pt-BR");

            var fileInfo = new FileInfo(Assembly.GetExecutingAssembly().Location);
            string path = fileInfo.Directory.Parent.FullName;

            var configuration = new ConfigurationBuilder()
                 .SetBasePath(Environment.CurrentDirectory)
                 .SetBasePath(path)
                 .AddJsonFile("local.settings.json", optional: true, reloadOnChange: false)
                 .AddEnvironmentVariables()
                 .Build();

            builder.Services.AddRebusConfiguration();
        }
    }
}
