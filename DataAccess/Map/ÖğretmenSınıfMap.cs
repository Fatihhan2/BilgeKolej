using CoreTier;
using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Map
{
   public class ÖğretmenSınıfMap:CoreMap<ÖğretmenSınıf>
    {
        public ÖğretmenSınıfMap()
        {
            ToTable("ÖğretmenSınıf");
            Ignore(x => x.ID);
            HasKey(x => new { x.ÖğretmenID, x.SınıfID });
        }
    }
}
