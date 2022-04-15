using CoreTier;
using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Map
{
   public class ÖğretmenMap:CoreMap<Öğretmen>
    {
        public ÖğretmenMap()
        {
            ToTable("Öğretmen");
            Ignore(x => x.ID);
            HasKey(x => x.ÖğretmenID);
            Property(x => x.Branşı).IsOptional();
            Property(x => x.DerslerID).IsOptional();
            Property(x => x.Sırası).IsOptional();
            Property(x => x.DerslerID).IsOptional();
            
            
        }
    }
 }
    

