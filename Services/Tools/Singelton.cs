using System;
using DataAccess.Context;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Tools
{
  public  class Singelton
    {
        public Singelton()
        {

        }
        private static AppDbContext _context;
        public static AppDbContext Context
        {
            get
            {
                if (_context == null)
                    _context = new AppDbContext();
                return _context;
            }
        }
            
    }
}
