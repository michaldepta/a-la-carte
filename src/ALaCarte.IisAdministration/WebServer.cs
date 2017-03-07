using System.Collections.Generic;
using System.Linq;
using ALaCarte.IisAdministration.Models;
using Microsoft.Web.Administration;

namespace ALaCarte.IisAdministration
{
    public class WebServer
    {
        private readonly ServerManager _serverManager = new ServerManager();

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

        private static string BuildApplicationLink(Binding binding, string appPath)
            => $"{binding.Protocol}://localhost:{binding.EndPoint.Port}{appPath}";
    }
}
