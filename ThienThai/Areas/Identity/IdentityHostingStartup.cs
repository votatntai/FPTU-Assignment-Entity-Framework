using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(ThienThai.Areas.Identity.IdentityHostingStartup))]
namespace ThienThai.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
            });
        }
    }
}
