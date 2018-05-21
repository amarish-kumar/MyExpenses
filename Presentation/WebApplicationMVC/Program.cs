/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.WebApplicationMVC
{
    using System.Globalization;
    using System.IO;
    using System.Threading;

    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;

    public class Program
    {
        public static void Main(string[] args)
        {
            CultureInfo cultureInfo = CultureInfo.CreateSpecificCulture("en-US");
            Thread.CurrentThread.CurrentCulture = cultureInfo;
            Thread.CurrentThread.CurrentUICulture = cultureInfo;

            if (args.Length > 0)
            {
                // use this to allow command line parameters in the config
                var configuration = new ConfigurationBuilder()
                    .AddCommandLine(args)
                    .Build();

                var hostUrl = configuration["hosturl"];
                if (string.IsNullOrEmpty(hostUrl))
                    hostUrl = "http://0.0.0.0:6000";

                var host = new WebHostBuilder()
                    .UseKestrel()
                    .UseUrls(hostUrl)   // <!-- this 
                    .UseContentRoot(Directory.GetCurrentDirectory())
                    .UseIISIntegration()
                    .UseStartup<Startup>()
                    .UseConfiguration(configuration)
                    .Build();

                host.Run();
            }
            else
            {
                BuildWebHost(args).Run();
            }
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
