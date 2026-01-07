using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakipSistemi.DOMAIN
{
    public class Product : BaseEntity
    {
        public string ProductName { get; set; }
        public int StockQuantity { get; set; }
        public decimal Price { get; set; }
        public int MinStockLimit { get; set; }
    }
}
