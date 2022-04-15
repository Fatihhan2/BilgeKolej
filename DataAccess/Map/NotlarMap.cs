using CoreTier;
using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Map
{
   public class NotlarMap:CoreMap<Notlar>
    {
        public NotlarMap()
        {
            Property(x => x.Sınav1).IsOptional();
            Property(x => x.Sınav2).IsOptional();
            Property(x => x.Ortalama).IsOptional();
            Property(x => x.PerformansNotu).IsOptional();
        }
    }
}
