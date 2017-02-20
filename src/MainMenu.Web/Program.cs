using Topshelf;

namespace MainMenu.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            HostFactory.Run(config =>
            {
                config.Service<WebHostingService>(service =>
                {
                    service.ConstructUsing(() => new WebHostingService());
                    service.WhenStarted(x => x.Start());
                    service.WhenStopped(x => x.Stop());
                });
            });
        }
    }
}
