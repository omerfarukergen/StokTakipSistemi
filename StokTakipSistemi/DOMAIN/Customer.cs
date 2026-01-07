using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakipSistemi.DOMAIN
{
    public class Customer : BaseEntity
    {
        public string FullName { get; set; }
        public string CustomerType { get; set; } // Perakende veya Toptan
        public string Phone { get; set; }
    }
}
