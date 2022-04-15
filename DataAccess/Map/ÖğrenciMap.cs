﻿using CoreTier;
using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Map
{
   public class ÖğrenciMap:CoreMap<Öğrenci>
    {
        public ÖğrenciMap()
        {
            Property(x => x.BitirdiğiOkul).IsOptional();
            Property(x => x.EvTelefonu).IsOptional();
            Property(x => x.İşTelefonu).IsOptional();
            Property(x => x.NotOrtalaması).IsOptional();
            
        }
    }
}
