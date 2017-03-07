using System.Linq;
using ALaCarte.IisAdministration;
using Microsoft.AspNetCore.Mvc;

namespace ALaCarte.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly WebServer _webServer;

        public HomeController(WebServer webServer)
        {
            _webServer = webServer;
        }

        public IActionResult Index()
        {
            var sites = _webServer.GetSites();
            return View(sites);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "a'la carte - your IIS menu with all sites and apps";

            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        public IActionResult Applications(int id)
        {
            ViewData["SiteName"] = _webServer.GetSites().First(x => x.Id == id).Name;
            var applications = _webServer.GetSiteApplications(id);
            return View(applications);
        }

        public IActionResult WebSites() => View();
    }
}
