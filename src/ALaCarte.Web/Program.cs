using System.IO;
using System.Reflection;
using Topshelf;

namespace ALaCarte.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var contentRoot = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            HostFactory.Run(config =>
            {
                config.Service<WebHostingService>(service =>
                {
                    service.ConstructUsing(() => new WebHostingService(contentRoot));
                    service.WhenStarted(x => x.Start());
                    service.WhenStopped(x => x.Stop());
                });
            });
        }
    }
}
