using CoreTier;
using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Map
{
   public class DerslerMap:CoreMap<Dersler>
    {
        public DerslerMap()
        {
            ToTable("Ders");
            Property(x => x.HD).IsOptional();
            Property(x => x.Kod).IsOptional();
            Property(x => x.Sırası).IsOptional();
        }
    }
}
