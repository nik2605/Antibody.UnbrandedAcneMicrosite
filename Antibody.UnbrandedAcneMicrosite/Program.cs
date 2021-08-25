using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Web.Administration;
using ConfigurationSection = Microsoft.Web.Administration.ConfigurationSection;

namespace Antibody.UnbrandedAcneMicrosite
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                using (ServerManager serverManager = new ServerManager())
                {
                    Configuration config = serverManager.GetApplicationHostConfiguration();
                    ConfigurationSection sitesSection = config.GetSection("system.applicationHost/sites");
                    ConfigurationElement siteDefaultsElement = sitesSection.GetChildElement("siteDefaults");

                    ConfigurationElement limitsElement = siteDefaultsElement.GetChildElement("limits");
                    limitsElement["connectionTimeout"] = TimeSpan.Parse("00:00:30");
                    limitsElement["maxBandwidth"] = 3000000;
                    limitsElement["maxConnections"] = 1024;
                    limitsElement["maxUrlSegments"] = 32;


                    ConfigurationSection webLimits = config.GetSection("system.applicationHost/webLimits");
                  //  ConfigurationElement webLimits = sitesSection1.GetChildElement("webLimits");

                    webLimits["connectionTimeout"] = TimeSpan.Parse("00:00:30");
                    webLimits["headerWaitTimeout"] = TimeSpan.Parse("00:00:00");
                    webLimits["minBytesPerSecond"] = 500;
                    webLimits["dynamicIdleThreshold"] = 0;
                    webLimits["maxGlobalBandwidth"] = 3000000;

                    serverManager.CommitChanges();
                }
            }
            catch (Exception ex)
            {
                //ignore
            }
            

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
