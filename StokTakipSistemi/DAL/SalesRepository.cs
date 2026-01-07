using MySql.Data.MySqlClient;
using StokTakipSistemi.DOMAIN;
using System;

namespace StokTakipSistemi.DAL
{
    public class SalesRepository
    {
        private DbConnection db = new DbConnection();

        public void MakeSale(Sale sale)
        {
            using (var conn = db.GetConnection())
            {
                conn.Open();
                // 1. Satış Kaydını Ekle (Senin modelindeki isimlere göre)
                string saleQuery = "INSERT INTO Sales (ProductId, CustomerId, Quantity, TotalPrice, SaleDate) VALUES (@pId, @cId, @qty, @total, @date)";
                MySqlCommand cmdSale = new MySqlCommand(saleQuery, conn);
                cmdSale.Parameters.AddWithValue("@pId", sale.ProductId);
                cmdSale.Parameters.AddWithValue("@cId", sale.CustomerId);
                cmdSale.Parameters.AddWithValue("@qty", sale.Quantity);
                cmdSale.Parameters.AddWithValue("@total", sale.TotalPrice);
                cmdSale.Parameters.AddWithValue("@date", sale.SaleDate);
                cmdSale.ExecuteNonQuery();

                // 2. STOK AZALTMA
                string updateStockQuery = "UPDATE Products SET StockQuantity = StockQuantity - @qty WHERE Id = @pId";
                MySqlCommand cmdUpdateStock = new MySqlCommand(updateStockQuery, conn);
                cmdUpdateStock.Parameters.AddWithValue("@qty", sale.Quantity);
                cmdUpdateStock.Parameters.AddWithValue("@pId", sale.ProductId);
                cmdUpdateStock.ExecuteNonQuery();
            }
        }
    }
}