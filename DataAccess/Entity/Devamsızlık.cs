using CoreTier;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entity
{
  public class Devamsızlık:CoreEntity
    {
        public decimal Raprolu { get; set; }
        public int Nöbetçi { get; set; }
        public decimal Raporsuz { get; set; }
        [Required]
        public virtual Öğrenci Öğrenci { get; set; }
    }
}
