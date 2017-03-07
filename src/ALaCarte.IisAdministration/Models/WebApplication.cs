namespace MainMenu.IisAdministration.Models
{
    public class WebApplication
    {
        public WebApplication(string path, string enabledProtocols)
        {
            Path = path;
            EnabledProtocols = enabledProtocols;
        }

        public string Path { get; }
        public string EnabledProtocols { get; }
    }
}