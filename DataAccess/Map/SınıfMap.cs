using CoreTier;
using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Map
{
   public class SınıfMap:CoreMap<Sınıf>
    {
        public SınıfMap()
        {
            ToTable("Sınıf");
            Ignore(x => x.ID);
            HasKey(x => x.SınıfID);
            

        }
    }
}
