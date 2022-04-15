using DataAccess.Context;
using DataAccess.Entity;
using Services;
using Services.Tools;
using System;

using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEB.Areas.Öğretmen.Models;

namespace WEB.Areas.Öğretmen.Controllers
{
    
    public class ÖnKController : Controller
    {
        NotlarService notlarService = new NotlarService();
        ÖnKayıtService ÖnKayıtService = new ÖnKayıtService();
        ÖğrenciService ÖğrenciService = new ÖğrenciService();
        SınıfService SınıfService = new SınıfService();
        AppDbContext db = Singelton.Context;
        DevamsızlıkService DevamsızlıkService = new DevamsızlıkService();
        // GET: Öğretmen/ÖnK
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Önkayıt öğrenci)
        {
            int EnBüyükDeğer = 0;
            if (db.Önkayıtlar.Count() > 0)
            {
                foreach (var item in db.Önkayıtlar)
                {

                    if (item.OkulNo > EnBüyükDeğer)
                    {
                        EnBüyükDeğer = item.OkulNo;
                    }
                }
            }
            else
            {
             foreach (var item in db.Öğrenciler)
            {
                
                if (item.OkulNo > EnBüyükDeğer)
                {
                    EnBüyükDeğer = item.OkulNo;
                }
            }
            }
           
            int EnBüyükID = 0;
            foreach (var item in db.Önkayıtlar)
            {

                if (item.MasterID > EnBüyükID)
                {
                    EnBüyükID = item.MasterID;
                }
            }
            int Master = EnBüyükID + 1;
            int OkulN = EnBüyükDeğer + 1000;

            DataAccess.Entity.Önkayıt önkayıt1 = new DataAccess.Entity.Önkayıt()
            {
                Ad = öğrenci.Ad, Soyad = öğrenci.Soyad, BitirdiğiOkul = öğrenci.BitirdiğiOkul, Cinsiyet = öğrenci.Cinsiyet, EvAdresi = öğrenci.EvAdresi, EvTelefonu = öğrenci.EvTelefonu, ID = Guid.NewGuid(), MasterID = Master, NotOrtalaması = öğrenci.NotOrtalaması, Status = CoreTier.Enum.Status.DevamEdiyor, VeliAdSoyad = öğrenci.VeliAdSoyad, İşTelefonu = öğrenci.İşTelefonu, OkulNo = OkulN
            };
            ÖnKayıtService.Create(önkayıt1);
         
            return RedirectToAction("SınıfSeçim");
        }

        public ActionResult SınıfSeçim()
        {
            //MultiModel multiModel = new MultiModel();
            //multiModel.ÖnKayıtListesi = db.Önkayıtlar.ToList();
            //multiModel.SınıfListesi = db.Sınıflar.ToList();
            return View(ÖnKayıtService.GetList());
        }
       
        public ActionResult SınıfAtama(Guid id)
        {
            var student = ÖnKayıtService.GetDefault(x => x.ID == id).FirstOrDefault();
            MultiModel multiModel = new MultiModel();
            multiModel.ÖnKayıt = student;
            multiModel.SınıfListesi = db.Sınıflar.ToList();
            return View(multiModel);
        }

        public ActionResult SınıfYerleştirme(Guid Öğrencid, Guid sınıfd)
        {
            Guid gid = Guid.NewGuid();
            var student = ÖnKayıtService.GetDefault(x => x.ID == Öğrencid).FirstOrDefault();
            DataAccess.Entity.Öğrenci öğrenci = new DataAccess.Entity.Öğrenci()
            {
                Ad = student.Ad,
                OkulNo = student.OkulNo,
                Soyad = student.Soyad,
                BitirdiğiOkul = student.BitirdiğiOkul,
                Cinsiyet = student.Cinsiyet,
                EvAdresi = student.EvAdresi,
                EvTelefonu = student.EvTelefonu,
                İşTelefonu = student.İşTelefonu,
                ID = gid,
                MasterID = student.MasterID,
                NotOrtalaması = student.NotOrtalaması,
                VeliAdSoyad = student.VeliAdSoyad,
                Status = 0,
                SınıfID = sınıfd,
                RolID = db.Roller.Where(x => x.Yetki.Contains("Öğrenci")).FirstOrDefault().ID
            };


            Devamsızlık devamsızlık = new Devamsızlık()
            {
                ID = gid,
                MasterID = student.MasterID,
                Nöbetçi = 0,
                Raporsuz = 0,
                Raprolu = 0,
                Status = 0,
                Öğrenci = öğrenci

            };
           
            
            
            
            
            ÖğrenciService.Create(öğrenci);
            DevamsızlıkService.Create(devamsızlık);
            ÖnKayıtService.Delete(student);
            return RedirectToAction("SınıfSeçim");
            
        }

    }
}