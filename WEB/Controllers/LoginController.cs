using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WEB.Models.Wievs;

namespace WEB.Controllers
{
    public class LoginController : Controller
    {
        ÖğretmenService ÖğretmenService = new ÖğretmenService();
        ÖğrenciService ÖğrenciService = new ÖğrenciService();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ÖğretmenGiriş()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ÖğretmenGiriş(ÖğretmenGirişVM öğretmenad)
        {
            if (ModelState.IsValid)
            {
                var user = ÖğretmenService.GetDefault(x => x.Ad == öğretmenad.Ad).FirstOrDefault();
                if (user != null)
                {
                    //FormsAuthentication.SetAuthCookie(user.Username, true);
                    FormsAuthentication.SetAuthCookie(user.Ad, true);
                    return RedirectToAction("Home", "Öğretmen");
                }
                else
                {
                    return View(öğretmenad);
                }
            }
            else
            {
                return View(öğretmenad);
            }

        }

        public ActionResult ÖğrenciGiriş()
        {


            return View();
        }
        [HttpPost]
        public ActionResult ÖğrenciGiriş(ÖğrenciGirişVM öğrencino)
        {

            if (ModelState.IsValid)
            {
                var user = ÖğrenciService.GetDefault(x => x.OkulNo == öğrencino.OkulNo).FirstOrDefault();
                if (user != null)
                {
                    //FormsAuthentication.SetAuthCookie(user.Username, true);
                    FormsAuthentication.SetAuthCookie(user.Ad, true);
                    return RedirectToAction("Home", "Öğrenci");
                }
                else
                {
                    return View(öğrencino);
                }
            }
            else
            {
                return View(öğrencino);
            }



        }
    }
}