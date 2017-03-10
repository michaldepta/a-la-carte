using System.Collections.Generic;
using System.Linq;
using ALaCarte.IisAdministration.Models;
using Microsoft.Extensions.Options;
using Microsoft.Web.Administration;

namespace ALaCarte.IisAdministration
{
    public class WebServer
    {
        private readonly string _hostName;
        private readonly ServerManager _serverManager = new ServerManager();

        public WebServer(IOptions<WebServerOptions> optionsAccessor)
        {
            _hostName = optionsAccessor.Value.HostName;
        }

        public IEnumerable<WebSite> GetSites()
            => _serverManager.Sites.Select(x => new WebSite(x.Id, x.Name, x.State.ToString()));

        public IEnumerable<WebApplication> GetSiteApplications(long siteId)
        {
            var site = _serverManager.Sites
                .FirstOrDefault(x => x.Id == siteId);

            return site?
                .Applications?
                .Select(app => new WebApplication(app.Path, app.EnabledProtocols, site.Bindings.Select(x => BuildApplicationLink(x, app.Path))));
        }

        private string BuildApplicationLink(Binding binding, string appPath)
            => $"{binding.Protocol}://{_hostName}:{binding.EndPoint.Port}{appPath}";
    }
}
