using CoreTier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entity
{
   public class Dersler:CoreEntity
    {
        public string Kod { get; set; }
        public int HD { get; set; }
        public int Sırası { get; set; }
        public string DersAdı { get; set; }
        public virtual List<Öğretmen> Öğretmenler { get; set; }
        public virtual List<Dersler> Derslers { get; set; }
    }
}
