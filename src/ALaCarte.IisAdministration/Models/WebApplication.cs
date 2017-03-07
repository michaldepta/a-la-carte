using System.Collections.Generic;

namespace ALaCarte.IisAdministration.Models
{
    public class WebApplication
    {
        public WebApplication(string path, string enabledProtocols, IEnumerable<string> links)
        {
            Path = path;
            EnabledProtocols = enabledProtocols;
            Links = links;
        }

        public string Path { get; }
        public string EnabledProtocols { get; }
        public IEnumerable<string> Links { get; }
    }
}