using CoreTier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entity
{
   public class Sınıf:CoreEntity
    {
        public Guid SınıfID { get; set; }
        public string SınıfNo { get; set; }

        public virtual List<Öğrenci> Öğrenciler { get; set; }
    }
}
