using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAccess.Entity;

namespace WEB.Areas.Öğretmen.Models
{
    public class MultiModel2
    {
        
        public List<Dersler> Derslers { get; set; }

       public List<DataAccess.Entity.Öğretmen> Öğretmens { get; set; }
        public DataAccess.Entity.Öğretmen Öğretmen { get; set; }
    }
}