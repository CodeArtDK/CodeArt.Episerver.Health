using CodeArt.Episerver.Health.Models;
using EpiHealthCheck.modules._protected.HealthCheck;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CodeArt.Episerver.Health.Controllers
{
    public class MainController : Controller
    {

        private readonly HealthService healthService;

        public MainController(HealthService service)
        {
            healthService = service;
        }

        public ActionResult Index()
        {
            //Run All, All in Group, or individual

            //Also, load last runs from DDS and show

            MainModel mm = new MainModel();
            mm.HealthChecks = healthService.HealthChecks;

            //Details view shows when a check has been run, and what it has returned.
            return View(mm);
        }
    }
}
