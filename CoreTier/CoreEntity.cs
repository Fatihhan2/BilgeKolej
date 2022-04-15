using CoreTier.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreTier
{
   public class CoreEntity:IEntity<Guid>
    {
        public Guid ID { get; set; }
        public int MasterID { get; set; }
        public Status Status { get; set; }



      



    




    }
}
