using System.Threading;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace ALaCarte.Web
{
    public class WebHostingService
    {
        private readonly string _contentRoot;
        private readonly CancellationTokenSource _shutdownTokenSource = new CancellationTokenSource();

        public WebHostingService(string contentRoot)
        {
            _contentRoot = contentRoot;
        }

        public void Start() => new WebHostBuilder()
            .UseKestrel()
            .UseContentRoot(_contentRoot)
            .UseIISIntegration()
            .UseStartup<Startup>()
            .UseConfiguration(
                new ConfigurationBuilder().SetBasePath(_contentRoot).AddJsonFile("hosting.json", true).Build())
            .Build()
            .Run(_shutdownTokenSource.Token);

        public void Stop() => _shutdownTokenSource.Cancel();
    }
}