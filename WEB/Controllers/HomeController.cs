using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Services;
using System.Web.Mvc;
using WEB.Models.Wievs;
using DataAccess.Entity;
using System.Web.Security;

namespace WEB.Controllers
{
    public class HomeController : Controller
    {
        ÖğrenciService öğrenciService = new ÖğrenciService();
        ÖnKayıtService ÖnKayıtService = new ÖnKayıtService();
       
        public ActionResult Index()
        {
            return View(öğrenciService.GetList());
        }

     

        public ActionResult ÖnKayıt()
        {
            

            return View();
        }
        [HttpPost]
        public ActionResult ÖnKayıt(Önkayıt öğrenci)
        {
            ÖnKayıtService.Create(öğrenci);

            
            return View("Index");
        }

        


        //[HttpPost]
        //public ActionResult ÖğretmenGiriş(ÖğretmenGirişVM öğretmenad)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var user = ÖğretmenService.GetDefault(x => x.Ad == öğretmenad.Ad).FirstOrDefault();
        //        if (user != null)
        //        {
        //            //FormsAuthentication.SetAuthCookie(user.Username, true);
        //            FormsAuthentication.SetAuthCookie(user.Ad, true);
        //            return RedirectToAction("Home", "Öğrenci");
        //        }
        //        else
        //        {
        //            return View(öğretmenad);
        //        }
        //    }
        //    else
        //    {
        //        return View(öğretmenad);
        //    }

        //}

    }
}