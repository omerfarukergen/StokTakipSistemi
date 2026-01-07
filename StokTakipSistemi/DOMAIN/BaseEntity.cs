using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakipSistemi.DOMAIN
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        // Her tabloda ortak olabilecek alanlar eklenebilir
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
