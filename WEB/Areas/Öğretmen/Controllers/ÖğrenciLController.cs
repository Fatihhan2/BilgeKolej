using DataAccess.Context;
using DataAccess.Entity;
using Services.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Security;
using System.Web;
using System.Web.Mvc;
using Services;
using WEB.Areas.Öğretmen.Models;

namespace WEB.Areas.Öğretmen.Controllers
{
    public class ÖğrenciLController : Controller
    {
        ÖğrenciService ÖğrenciService = new ÖğrenciService();
        AppDbContext db = Singelton.Context;
        SınıfService SınıfService = new SınıfService();
        DevamsızlıkService DevamsızlıkService = new DevamsızlıkService();
        // GET: Öğretmen/ÖğrenciL
        public ActionResult Index()
        {
     
            return View(SınıfService.GetList());
        }
        public ActionResult SınıfListesi(Guid id)
        {
          var Sınıff= SınıfService.GetDefault(x => x.SınıfID == id).FirstOrDefault();
            MultiModel3 multiModel3 = new MultiModel3();
            multiModel3.Öğrencis = db.Öğrenciler.ToList();
            multiModel3.Sınıf = Sınıff;
           
            return View(multiModel3);
        }
        public ActionResult ÖğrenciDeğerGiriş(Guid id)
        {
            var öğrenci = ÖğrenciService.GetDefault(x => x.ID == id).FirstOrDefault();
            return View(öğrenci);
        }

        public ActionResult Devamsızlık(Guid id)
        {
          var devamsızlık= DevamsızlıkService.GetDefault(x => x.ID == id).FirstOrDefault();
            return View(devamsızlık);
        }
        [HttpPost]
        public ActionResult Devamsızlık(Devamsızlık devamsızlık)
        {
           var değişiklik= db.Devamsızlıklar.Find(devamsızlık.ID);
            değişiklik.Nöbetçi = devamsızlık.Nöbetçi;
            değişiklik.Raporsuz = devamsızlık.Raporsuz;
            değişiklik.Raprolu = devamsızlık.Raprolu;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult NotGirişi(Guid id)
        {
            //Todo: Gelen id li öğrenci için eğer varsa notun üstünde değişiklik not yok ise yeni bir not oluşturulacak! 
            return View();
        }
        public ActionResult ÖğrenciİlişkiKesilmesi(Guid id)
        {
            var öğrenci = ÖğrenciService.GetDefault(x => x.ID == id).FirstOrDefault();
          
            

            return View(öğrenci);
        }
        [HttpPost]
        public ActionResult ÖğrenciİlişkiKesilmesi(Guid id,CoreTier.Enum.Status status)
        {
            var öğrenci = ÖğrenciService.GetDefault(x => x.ID == id).FirstOrDefault();
            öğrenci.Status = status;


            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}