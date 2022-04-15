using CoreTier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entity
{
   public class Öğretmen:CoreEntity
    {
        public Guid ÖğretmenID { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public int Sırası { get; set; }
        public string Görevi { get; set; }
        public string Branşı { get; set; }
        public Guid RolID { get; set; }
        public virtual Rol Roller { get; set; }
        public Guid DerslerID { get; set; }
        public virtual Dersler Dersler { get; set; }
    }
}
