using Funq;
using ServiceStack;
using HotFaceCity.ServiceInterface;
using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(HotFaceCity.AppHost))]

namespace HotFaceCity
{

    public class AppHost : AppHostBase, IHostingStartup
    {
        public void Configure(IWebHostBuilder builder) => builder
            .ConfigureServices(services =>
            {
                // Configure ASP.NET Core IOC Dependencies
            })
            .Configure(app =>
            {
                // Configure ASP.NET Core App
                if (!HasInit)
                    app.UseServiceStack(new AppHost());
            });

        public AppHost() : base("HotFaceCity", typeof(MyServices).Assembly)
        {
        }

        public override void Configure(Container container)
        {
            // enable server-side rendering, see: https://sharpscript.net/docs/sharp-pages
            Plugins.Add(new SharpPagesFeature
            {
                EnableSpaFallback = true
            });

            SetConfig(new HostConfig
            {
                AddRedirectParamsToQueryString = true,
            });
        }
    }
}