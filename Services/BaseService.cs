using CoreTier;
using DataAccess.Context;
using Services.Tools;   
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.Infrastructure;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BaseService<T> : ICoreService<T> where T : CoreEntity
    {

        AppDbContext db=Singelton.Context;
    

        public bool Any(Expression<Func<T, bool>> exp)
        {
            return db.Set<T>().Any(exp);
        }

        public string ChangeEducetion(T model,CoreTier.Enum.Status status)
        {
            T changed = db.Set<T>().Find(model.ID);
            
            if (status == CoreTier.Enum.Status.DevamEdiyor) {changed.Status = CoreTier.Enum.Status.DevamEdiyor; }
            else if (status==CoreTier.Enum.Status.DevamEtmiyor){ changed.Status = CoreTier.Enum.Status.DevamEtmiyor; }
            else if (status == CoreTier.Enum.Status.SınıfTekrarı) { changed.Status = CoreTier.Enum.Status.SınıfTekrarı; }

            Update(changed);
            return "Öğrencinin eğitim programı değiştilirmiştir.";
        }

        public string Create(T model)
        {
            model.ID = Guid.NewGuid();
            db.Set<T>().Add(model);
            db.SaveChanges();
            return "Öğrenci Kaydı Başarılı";
        }
        public List<T> GetDefault(Expression<Func<T, bool>> exp)
        {
            return db.Set<T>().Cast<T>().Where(exp).ToList();
        }

        public string Create(List<T> model)
        {
            db.Set<T>().AddRange(model);
            db.SaveChanges();
            return "Öğrencilerin Kayıtları Başarılı";
        }

        public string Delete(T model)
        {
            T delete = db.Set<T>().Find(model.ID);
            delete.Status = CoreTier.Enum.Status.DevamEtmiyor;
            db.Set<T>().Remove(delete);
            return "Öğrencinin eğitim programı durdurulmuştur";
        }

        public T GetById(Guid id)
        {
            return db.Set<T>().Find(id);
        }

        public List<T> GetList()
        {
            return db.Set<T>().ToList();
        }

        public string Update(T model)
        {
            T updated = GetById(model.ID);
            DbEntityEntry entry = db.Entry(updated);
            entry.CurrentValues.SetValues(model);
            db.SaveChanges();
            return "Bilgiler Değiştirildi";
        }
    }
}
