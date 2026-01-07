using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakipSistemi.DOMAIN
{
    public class Sale : BaseEntity
    {
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public DateTime SaleDate { get; set; } = DateTime.Now;
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }

        public string ProductName { get; set; }
        public string CustomerName { get; set; }
    }
}
