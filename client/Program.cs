using Microsoft.Extensions.Logging;
using Orleans;
using Orleans.Configuration;
using Orleans.Hosting;
using Orleans.Runtime;
using System;
using System.Net;
using System.Threading.Tasks;
using TInterface;

namespace client
{
    class Program
    {

        public static IClusterClient client;
        static void Main(string[] args)
        {
            client = StartClientWithRetries().Result;

            var info = client.GetGrain<ITest>(Guid.NewGuid());
            var result = info.GetName();
            Console.WriteLine(result.Result);
            Console.ReadKey();
        }

        private static async Task<IClusterClient> StartClientWithRetries(int initializeAttemptsBeforeFailing = 5)
        {
            int attempt = 0;
            IClusterClient client;
            while (true)
            {
                try
                {

                    var siloAddress = IPAddress.Loopback; // IPAddress.Parse("192.168.1.250"); //IPAddress.Loopback
                    var gatewayPort = 30020;
                    var uri = (new IPEndPoint(siloAddress, gatewayPort)).ToGatewayUri();

                    client = new ClientBuilder()
                        .Configure<ClusterOptions>(opt =>
                        {
                            opt.ClusterId = "test1";
                            opt.ServiceId = "test1";
                        })
                        .ConfigureLogging(logging =>
                        {
                            logging.AddConsole();
                            logging.SetMinimumLevel(LogLevel.Information);
                        })
                         ////集群
                         .UseStaticClustering(options => options.Gateways.Add(uri))//集群  
                        .ConfigureApplicationParts(parts => parts.AddApplicationPart(typeof(ITest).Assembly).WithReferences())
                        .Build();

                    await client.Connect();
                    Console.WriteLine("Client successfully connect to silo host");
                    break;
                }
                catch (SiloUnavailableException ex)
                {
                    attempt++;
                    Console.WriteLine($"Attempt {attempt} of {initializeAttemptsBeforeFailing} failed to initialize the Orleans client.");
                    if (attempt > initializeAttemptsBeforeFailing)
                    {
                        throw;
                    }
                    await Task.Delay(TimeSpan.FromSeconds(4));
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return client;
        }

        private static async Task<IClusterClient> StartClientWithRetries2(int initializeAttemptsBeforeFailing = 5)
        {
            Uri u = (new IPEndPoint(IPAddress.Parse("127.0.0.1"), 30000)).ToGatewayUri();
            int attempt = 0;
            IClusterClient client;
            while (true)
            {
                try
                {
                    client = new ClientBuilder()

                        .Configure<ClusterOptions>(options =>
                        {
                            options.ClusterId = "dev";
                            options.ServiceId = "HelloWorldAppClient";
                        })
                        .ConfigureApplicationParts(parts => parts.AddApplicationPart(typeof(ITest).Assembly).WithReferences())

                        .UseStaticClustering(configureOptions => configureOptions.Gateways.Add(u))
                         .ConfigureLogging(logging =>
                         {
                             logging.AddConsole();
                             logging.SetMinimumLevel(LogLevel.Information);
                         })

                        .Build();

                    await client.Connect();
                    Console.WriteLine("Client successfully connect to silo host");
                    break;
                }
                catch (SiloUnavailableException)
                {
                    attempt++;
                    Console.WriteLine($"Attempt {attempt} of {initializeAttemptsBeforeFailing} failed to initialize the Orleans client.");
                    if (attempt > initializeAttemptsBeforeFailing)
                    {
                        throw;
                    }
                    await Task.Delay(TimeSpan.FromSeconds(4));
                }
            }

            return client;

        }
    }
}
