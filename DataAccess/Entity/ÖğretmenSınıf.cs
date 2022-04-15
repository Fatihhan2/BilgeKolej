using CoreTier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entity
{
   public class ÖğretmenSınıf:CoreEntity
    {
        public Guid ÖğretmenID { get; set; }
        public Guid SınıfID { get; set; }
        public virtual Öğretmen Öğretmen { get; set; }
        public virtual Sınıf Sınıf { get; set; }
    }
}
