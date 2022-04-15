namespace DataAccess.Migrations
{
    using DataAccess.Entity;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<DataAccess.Context.AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(DataAccess.Context.AppDbContext context)
        {

            List<Dersler> derslers = new List<Dersler>()
       {
           new Dersler{ID=Guid.NewGuid(),DersAdı="Matematik",HD=1,Kod="Mat1",MasterID=1,Sırası=10}
       };
            if (!context.Roller.Any())
            {
                foreach (var dersler in derslers)
                {
                    context.Derslers.Add(dersler);
                    context.SaveChanges();
                }
            }

            List<Rol> rols = new List<Rol>()
           {
               new Rol{ID=Guid.NewGuid(),Yetki="Öğrenci",MasterID=2},
               new Rol{ID=Guid.NewGuid(),Yetki="Öğretmen",MasterID=1}
           };
            if (!context.Roller.Any())
            {
                foreach (var rol in rols)
                {
                    context.Roller.Add(rol);
                    context.SaveChanges();
                }
            }

            List<Sınıf> sınıfs = new List<Sınıf>()
            {
                new Sınıf{ID=Guid.NewGuid(),SınıfID=Guid.NewGuid(),SınıfNo="9A",MasterID=1},
                new Sınıf{ID=Guid.NewGuid(),SınıfID=Guid.NewGuid(),SınıfNo="9B",MasterID=2}
            };

            if (!context.Sınıflar.Any())
            {
                foreach (var sınıf in sınıfs)
                {
                    context.Sınıflar.Add(sınıf);
                    context.SaveChanges();
                }
            }

            List<Öğretmen> öğretmens = new List<Öğretmen>()
            {
                new Öğretmen{ID=Guid.NewGuid(),Ad="Mert",Soyad="Hakan",Branşı="Matematik",Sırası=4,Görevi="",MasterID=1,Status=CoreTier.Enum.Status.DevamEdiyor,RolID=context.Roller.Where(x=>x.Yetki.Contains("Öğretmen")).FirstOrDefault().ID,DerslerID=context.Derslers.Where(x=>x.DersAdı.Contains("Matematik")).FirstOrDefault().ID}
            };
            if (!context.Öğretmenler.Any())
            {
                foreach (var öğretmen in öğretmens)
                {
                    context.Öğretmenler.Add(öğretmen);
                    context.SaveChanges();
                }
            }
            // TODO: çoka çok ilişkiden ötürü id hata verebilir dikkatli ol!!!;
            List<Öğrenci> öğrencis = new List<Öğrenci>()
            {
                new Öğrenci{ID=Guid.NewGuid(),Ad="Fatih",Soyad="Dalgıç",Cinsiyet=false,EvAdresi="ümraniye",VeliAdSoyad="S.D",EvTelefonu="43123",BitirdiğiOkul="Anadolu",OkulNo=10022,SınıfID=context.Sınıflar.Where(x=>x.SınıfNo.Contains("9A")).FirstOrDefault().SınıfID,RolID=context.Roller.Where(x=>x.Yetki.Contains("Öğrenci")).FirstOrDefault().ID,İşTelefonu="3214213",MasterID=9,NotOrtalaması=3,Status=CoreTier.Enum.Status.DevamEdiyor }
                };

            if (!context.Öğrenciler.Any())
            {
                foreach (var öğrenci in öğrencis)
                {

                    context.Öğrenciler.Add(öğrenci);
                    
                    Devamsızlık devamsızlıks = new Devamsızlık()
                    {
                        ID = öğrenci.ID,
                        MasterID = 8,
                        Nöbetçi = 0,
                        Raporsuz = 0,
                        Raprolu = 0,
                        Öğrenci = öğrenci,
                        Status = CoreTier.Enum.Status.DevamEdiyor
                    };
                    context.Devamsızlıklar.Add(devamsızlıks);
                    context.SaveChanges();
                }
               
            }
        }

    }
}
