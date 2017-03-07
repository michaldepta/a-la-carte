using System.Collections.Generic;
using System.Linq;
using MainMenu.IisAdministration.Models;
using Microsoft.Web.Administration;

namespace MainMenu.IisAdministration
{
    public class WebServer
    {
        private readonly ServerManager _serverManager = new ServerManager();

        public IEnumerable<WebSite> GetSites()
            => _serverManager.Sites.Select(x => new WebSite(x.Id, x.Name, x.State.ToString()));

        public IEnumerable<WebApplication> GetSiteApplications(long siteId) => _serverManager.Sites
            .FirstOrDefault(x => x.Id == siteId)?
            .Applications?
            .Select(app => new WebApplication(app.Path, app.EnabledProtocols));
        
    }
}
