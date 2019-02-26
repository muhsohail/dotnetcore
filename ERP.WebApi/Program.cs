using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace ERP.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                                            .ConfigureAppConfiguration((context, config) =>
                                            {
                                                var builtConfig = config.Build();

                                                config.AddAzureKeyVault(
                                                    $"https://{builtConfig["Vault"]}.vault.azure.net/",
                                                    builtConfig["ClientId"],
                                                    builtConfig["ClientSecret"]);
                                            })
                .UseStartup<Startup>();
    }
}
