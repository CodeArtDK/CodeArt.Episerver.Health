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

        public ActionResult Index()
        {
            //Run All, All in Group, or individual

            //Also, load last runs from DDS and show

            //Details view shows when a check has been run, and what it has returned.
            return View();
        }
    }
}
