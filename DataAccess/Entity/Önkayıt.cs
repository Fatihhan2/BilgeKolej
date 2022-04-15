using CoreTier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entity
{
   public class Önkayıt:CoreEntity
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
    }
}
