using Autofac;

namespace MainMenu.IisAdministration
{
    public class IisAdministrationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<WebServer>().AsSelf().SingleInstance();
        }
    }
}