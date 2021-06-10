using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Web.Layui
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string localIp = NetworkInterface.GetAllNetworkInterfaces()
               .Select(p => p.GetIPProperties())
               .SelectMany(p => p.UnicastAddresses)
               .FirstOrDefault(p => p.Address.AddressFamily == AddressFamily.InterNetwork && !IPAddress.IsLoopback(p.Address))?.Address.ToString();
            var time = DateTime.Now.ToString("HH:mm:ss");
            Console.WriteLine($"[{time}]:{localIp}");

            CreateHostBuilder(args).Build().Run();
           
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    
                });
    }
}
