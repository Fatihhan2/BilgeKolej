using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WEB.Areas.Öğretmen.Controllers
{
    public class HomeController : Controller
    {
        [Authorize(Roles = "Öğretmen")]
        // GET: Öğretmen/Öğretmen
        public ActionResult Index()
        {
            return View();
        }
    }
}