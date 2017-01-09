using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace WebApplicationMVCCore注入16
{
    // var builder = new ConfigurationBuilder()
    //          .SetBasePath(Directory.GetCurrentDirectory())
    //          .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
    //public IConfigurationRoot Configurationn =builder.Build();  



    //    }
    //}
    //public class GetConfiguration
    //{
    //    static public IConfigurationRoot Configuration;        
    //}
    public class Program
    {      
        public static void Main(string[] args)
        {
           
          var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();

            host.Run();
           
        }
       
    }
}
