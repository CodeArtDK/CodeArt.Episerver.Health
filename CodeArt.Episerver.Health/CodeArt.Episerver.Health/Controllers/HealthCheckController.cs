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
    public class HealthCheckController : Controller
    {

        private readonly HealthService healthService;

        public HealthCheckController(HealthService service)
        {
            healthService = service;
        }

        public ActionResult Index()
        {
            //Run All, All in Group, or individual

            //Also, load last runs from DDS and show

            MainModel mm = new MainModel();
            mm.HealthChecks = new List<HealthCheckAndResult>();
            foreach(var hc in healthService.HealthChecks)
            {
                HealthCheckAndResult hr = new HealthCheckAndResult();
                hr.HealthCheck = hc;
                hr.LastResult = healthService.GetLatestResultFrom(hc);
                mm.HealthChecks.Add(hr);
            }

            //Details view shows when a check has been run, and what it has returned.
            return View(mm);
        }

        public ActionResult RunAll()
        {
            //Runs all checks
            healthService.CheckAll();

            return RedirectToAction("Index");
        }
    }
}
