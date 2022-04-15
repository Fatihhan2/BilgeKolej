using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEB.Areas.Öğretmen.Models
{
    public class MultiModel3
    {
        public List<DataAccess.Entity.Öğrenci> Öğrencis { get; set; }
        public List<DataAccess.Entity.Sınıf> Sınıfs { get; set; }
        public DataAccess.Entity.Sınıf Sınıf { get; set; }
    }
}