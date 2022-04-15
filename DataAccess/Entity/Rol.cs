using CoreTier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entity
{
   public class Rol:CoreEntity
    {
        public string Yetki { get; set; }

        public virtual List<Öğrenci> Öğrenciler { get; set; }
        public virtual List<Öğretmen> Öğretmenler { get; set; }
    }
}
