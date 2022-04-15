using CoreTier;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entity
{
   public class Notlar:CoreEntity
    {
       
        public int Sınav1 { get; set; }
        public int Sınav2 { get; set; }
        public int PerformansNotu { get; set; }
        public decimal Ortalama { get; set; }

        public Guid DersID { get; set; }
        public virtual Dersler Dersler { get; set; }
        public Guid ÖğrenciID { get; set; }
        public virtual  Öğrenci Öğrenci { get; set; }

    }
}
