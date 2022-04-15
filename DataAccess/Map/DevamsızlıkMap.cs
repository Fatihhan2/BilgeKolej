using CoreTier;
using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Map
{
   public class DevamsızlıkMap:CoreMap<Devamsızlık>
    {
        public DevamsızlıkMap()
        {
            Property(x => x.Nöbetçi).IsOptional();
            
        }
    }
}
