using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Orleans.Hosting;
using System.IO;

namespace host
{
    /// <summary>
    /// 依赖注入
    /// </summary>
    public static class Startup
    {
        public static void ConfigureAppConfiguration(HostBuilderContext builder, IConfigurationBuilder config)
        {
            config.SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .AddJsonFile($"appsettings.{builder.HostingEnvironment.EnvironmentName}.json", optional: true);
        }
        public static void ConfigureServices(HostBuilderContext builder, IServiceCollection services)
        {
            services.AddLogging(logging => logging.AddFile(builder.Configuration.GetSection("Logging:File")));
        }


    }
}
