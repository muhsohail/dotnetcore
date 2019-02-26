using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(ERP.Areas.Identity.IdentityHostingStartup))]
namespace ERP.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}