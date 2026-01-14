using MySql.Data.MySqlClient;
using StokTakipSistemi.DOMAIN;
using System;
using System.Data;

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
        public System.Data.DataTable GetAllSales()
        {
            using (var conn = db.GetConnection())
            {
                conn.Open();
                if (conn.State != ConnectionState.Open) conn.Open(); // Güvenlik önlemi
                string query = "SELECT * FROM Sales";
                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        public DataTable GetDetailedSalesReport()
        {
            using (var conn = db.GetConnection())
            {
                if (conn.State != ConnectionState.Open) conn.Open();

                // Bu sorgu; satış tablosunu, ürünler ve müşterilerle birleştirir.
                // Böylece sadece ID değil, isimleri de çekeriz.
                string query = @"SELECT 
                            s.Id as 'Satış No', 
                            p.ProductName as 'Ürün Adı', 
                            c.FullName as 'Müşteri', 
                            s.Quantity as 'Adet', 
                            s.TotalPrice as 'Toplam Tutar', 
                            s.SaleDate as 'Tarih' 
                         FROM Sales s
                         INNER JOIN Products p ON s.ProductId = p.Id
                         INNER JOIN Customers c ON s.CustomerId = c.Id
                         ORDER BY s.SaleDate DESC";

                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }
}