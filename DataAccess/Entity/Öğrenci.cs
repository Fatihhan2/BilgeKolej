using CoreTier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entity
{
   public class Öğrenci:CoreEntity
    {
            
        public int OkulNo { get; set; }
        public bool Cinsiyet { get; set; }
        public string BitirdiğiOkul { get; set; }
        public decimal NotOrtalaması { get; set; }
        public string VeliAdSoyad { get; set; }
        public string EvTelefonu { get; set; }
        public string İşTelefonu { get; set; }
        public string EvAdresi { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public Guid RolID { get; set; }
        public virtual Rol Roller { get; set; }
        public virtual List<Notlar> Notlars { get; set; }
        public Guid SınıfID { get; set; }
        public virtual Sınıf Sınıf { get; set; }
        public virtual Devamsızlık Devamsızlık { get; set; }
        


    }
}
