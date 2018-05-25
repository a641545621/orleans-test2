using Microsoft.Extensions.Logging;
using Orleans;
using Orleans.Configuration;
using Orleans.Hosting;
using System;
using System.Net;
using System.Threading.Tasks;
using TGrains;
using TInterface;

namespace host
{
    class Program
    {
        static int Main(string[] args)
        {
            return RunMainAsync().Result;
        }

        #region sss

        private static async Task<int> RunMainAsync()
        {
            try
            {
                var host = await StartSilo();
                
                Console.WriteLine("Press Enter to terminate...");
                Console.ReadLine();
                
                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.ReadLine();
                return 1;
            }
        }
        private static async Task<ISiloHost> StartSilo()
        {
            var siloPort = 11111;
            int gatewayPort = 30020;
            var siloAddress = IPAddress.Loopback;

            var builder = new SiloHostBuilder()
                 .Configure<ClusterOptions>(options =>
                 {
                     options.ClusterId = "test1";
                     options.ServiceId = "test1";
                 })
                  .ConfigureLogging(logging =>
                  {
                      logging.AddConsole();
                      logging.SetMinimumLevel(LogLevel.Warning);
                  })
                 .Configure<EndpointOptions>(otp =>
                 {
                     otp.AdvertisedIPAddress = siloAddress;
                     otp.GatewayPort = gatewayPort;
                     otp.SiloPort = siloPort;
                 })
                 .UseDevelopmentClustering(options => options.PrimarySiloEndpoint = new IPEndPoint(siloAddress, siloPort))
                 .Configure<ClusterMembershipOptions>(options => options.ExpectedClusterSize = 5)
                 .ConfigureApplicationParts(parts => parts.AddApplicationPart(typeof(Test).Assembly).WithReferences())
                 .ConfigureEndpoints(advertisedIP: siloAddress, siloPort: siloPort, gatewayPort: gatewayPort, listenOnAnyHostAddress: true);

            var host = builder.Build();

            await host.StartAsync();
            return host;
        }
        #endregion
    }
}
