using DataAccess.Context;
using DataAccess.Entity;
using Services;
using Services.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WEB.Areas.Öğretmen.Controllers
{
    public class DerslerController : Controller
    {
        DerslerService derslerService = new DerslerService();
        AppDbContext db = Singelton.Context;
        // GET: Öğretmen/Dersler
        public ActionResult Index()
        {
            return View(derslerService.GetList());
        }
        public ActionResult Oluştur()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Oluştur(Dersler ders)
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
            Dersler dersler = new Dersler()
            {
                ID = Guid.NewGuid(), DersAdı = ders.DersAdı, HD = ders.HD, Kod = ders.Kod, Sırası = ders.Sırası, MasterID = Master
           };
            derslerService.Create(dersler);
            return RedirectToAction("Index");
        }
        public ActionResult Değiştir(Guid id)
        {
            var ders = derslerService.GetDefault(x => x.ID == id).FirstOrDefault();
            return View(ders);
        }
        [HttpPost]
        public ActionResult Değiştir(Dersler ders)
        {
            
            derslerService.Update(ders);
            return RedirectToAction("index");
        }

        public ActionResult Sil(Guid id)
        {
            var ders = derslerService.GetDefault(x => x.ID == id).FirstOrDefault();
            derslerService.Delete(ders);
            return RedirectToAction("Index");
        }
    }
}