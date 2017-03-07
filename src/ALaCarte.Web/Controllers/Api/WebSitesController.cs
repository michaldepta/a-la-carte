using System.Collections.Generic;
using MainMenu.IisAdministration;
using MainMenu.IisAdministration.Models;
using Microsoft.AspNetCore.Mvc;

namespace MainMenu.Web.Controllers
{
    [Route("api/[controller]")]
    public class WebSitesController : Controller
    {
        private readonly WebServer _server;

        public WebSitesController(WebServer server)
        {
            _server = server;
        }

        [HttpGet("")]
        public IEnumerable<WebSite> Get() => _server.GetSites();

        [HttpGet("{siteId}/applications")]
        public IActionResult GetSiteApplications(long siteId)
        {
            var apps = _server.GetSiteApplications(siteId);
            return apps == null
                ? (IActionResult)NotFound()
                : Ok(apps);
        }
    }
}