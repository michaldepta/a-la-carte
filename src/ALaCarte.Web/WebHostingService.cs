using System.Threading;
using Microsoft.AspNetCore.Hosting;

namespace ALaCarte.Web
{
    public class WebHostingService
    {
        private readonly CancellationTokenSource _shutdownTokenSource = new CancellationTokenSource();

        public void Start() => new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(@"C:\Projects\github\ALaCarte\src\ALaCarte.Web")
                //.UseContentRoot(Directory.GetCurrentDirectory()) // Changed by topshelf...
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build()
                .Run(_shutdownTokenSource.Token);

        public void Stop() => _shutdownTokenSource.Cancel();
    }
}