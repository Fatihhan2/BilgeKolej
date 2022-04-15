using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEB.Areas.Öğretmen.Models
{
    public class MultiModel
    {
        public List<Sınıf> SınıfListesi { get; set; }
        public Önkayıt ÖnKayıt { get; set; }
        
    }
}