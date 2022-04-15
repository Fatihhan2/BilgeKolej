using DataAccess.Context;
using Services;
using Services.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEB.Areas.Öğretmen.Models;

namespace WEB.Areas.Öğretmen.Controllers
{
    public class ÖğretmenKController : Controller
    {
        // GET: Öğretmen/ÖğretmenK
        ÖğretmenService ÖğretmenService = new ÖğretmenService();
        AppDbContext db = Singelton.Context;
        // GET: Öğretmen/ÖğretmenK
        public ActionResult Index()
        {
            MultiModel2 multiModel2 = new MultiModel2();
            multiModel2.Öğretmens = ÖğretmenService.GetList();
            multiModel2.Derslers = db.Derslers.ToList();
            
            
            return View(multiModel2);
        }
        public ActionResult Oluştur()
        {
            
            
            
            return View();
        }
        [HttpPost]
        public ActionResult Oluştur(DataAccess.Entity.Öğretmen öğretmen)
        {
            int EnBüyükID = 0;
            foreach (var item in db.Derslers)
            {

                if (item.MasterID > EnBüyükID)
                {
                    EnBüyükID = item.MasterID;
                }
            }
            int Master = EnBüyükID + 1;
            DataAccess.Entity.Öğretmen öğretmen1 = new DataAccess.Entity.Öğretmen()
            {
                Ad = öğretmen.Ad, Görevi = öğretmen.Görevi, ÖğretmenID = Guid.NewGuid(), Soyad = öğretmen.Soyad, Sırası = öğretmen.Sırası, RolID = db.Roller.Where(x => x.Yetki.Contains("Öğretmen")).FirstOrDefault().ID, Status = CoreTier.Enum.Status.DevamEdiyor, MasterID = Master,DerslerID=db.Derslers.Where(x=>x.DersAdı.Contains("Boş")).FirstOrDefault().ID
            };
            ÖğretmenService.Create(öğretmen1);
            return RedirectToAction("Index");
        }
        public ActionResult Düzenle(Guid id)
        {
            var öğret = ÖğretmenService.GetDefault(x => x.ÖğretmenID == id).FirstOrDefault();
            return View(öğret);
        }
        [HttpPost]
        public ActionResult Düzenle(DataAccess.Entity.Öğretmen öğretmen)
        {
            var öğret = ÖğretmenService.GetDefault(x => x.ÖğretmenID == öğretmen.ÖğretmenID).FirstOrDefault();
            öğret.Ad = öğretmen.Ad;
            öğret.Soyad = öğretmen.Soyad;
            öğret.Sırası = öğretmen.Sırası;
            öğret.Görevi = öğretmen.Görevi;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Branş(Guid id)
        {
            var öğret = ÖğretmenService.GetDefault(x => x.ÖğretmenID == id).FirstOrDefault();
            MultiModel2 multiModel = new MultiModel2();
            multiModel.Öğretmen = öğret ;
            multiModel.Derslers = db.Derslers.ToList();
            return View(multiModel);
        }
        public ActionResult BranşDeğişimi(Guid öğretmend,Guid dersd)
        {
            var öğretmen = ÖğretmenService.GetDefault(x => x.ÖğretmenID == öğretmend).FirstOrDefault();
            öğretmen.DerslerID = dersd;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}