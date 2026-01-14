using MySql.Data.MySqlClient;
using StokTakipSistemi.DOMAIN;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace StokTakipSistemi.DAL
{
    // IRepository şablonunu Ürünler için dolduruyoruz
    public class ProductRepository : IRepository<Product>
    {
        private DbConnection db = new DbConnection();

        public List<Product> GetAll()
        {
            List<Product> products = new List<Product>();
            using (var conn = db.GetConnection())
            {
                string query = "SELECT * FROM Products";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        products.Add(new Product
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            ProductName = reader["ProductName"].ToString(),
                            StockQuantity = Convert.ToInt32(reader["StockQuantity"]),
                            Price = Convert.ToDecimal(reader["Price"]),
                            MinStockLimit = Convert.ToInt32(reader["MinStockLimit"])
                        });
                    }
                }
            }
            return products;
        }

        public void Add(Product entity)
        {
            using (var conn = db.GetConnection())
            {
                string query = "INSERT INTO Products (ProductName, StockQuantity, Price, MinStockLimit) VALUES (@name, @stock, @price, @limit)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", entity.ProductName);
                cmd.Parameters.AddWithValue("@stock", entity.StockQuantity);
                cmd.Parameters.AddWithValue("@price", entity.Price);
                cmd.Parameters.AddWithValue("@limit", entity.MinStockLimit);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Şimdilik temel olanları yazdık, Update ve Delete'i UI kısmına geçince tamamlarız.
        public void Update(Product product) {
            using (var conn = db.GetConnection())
            {
                // SQL sorgusunda Id'ye göre filtreleme yapıyoruz
                string query = "UPDATE Products SET ProductName=@name, StockQuantity=@stock, Price=@price, MinStockLimit=@min WHERE Id=@id";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", product.ProductName);
                cmd.Parameters.AddWithValue("@stock", product.StockQuantity);
                cmd.Parameters.AddWithValue("@price", product.Price);
                cmd.Parameters.AddWithValue("@min", product.MinStockLimit);
                cmd.Parameters.AddWithValue("@id", product.Id);

                conn.Open();
                int etkilenenSatir = cmd.ExecuteNonQuery();

                if (etkilenenSatir > 0)
                    MessageBox.Show("Ürün başarıyla güncellendi!");
                else
                    MessageBox.Show("Güncelleme başarısız! Ürün bulunamadı.");
            }
        }
        public void Delete(int id)
        { // Önce gelen ID'yi kontrol et
            if (id <= 0)
            {
                MessageBox.Show("Hata: Geçersiz Ürün ID'si!");
                return;
            }

            using (var conn = db.GetConnection())
            {
                // Sorguda tablo isminin doğru olduğundan emin ol (Örn: Products mı Product mı?)
                string query = "DELETE FROM Products WHERE Id = @id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);

                conn.Open();
                int result = cmd.ExecuteNonQuery(); // Kaç satır silindiğini döndürür

                if (result > 0)
                    MessageBox.Show("Ürün başarıyla silindi.");
                else
                    MessageBox.Show("Ürün bulunamadı veya silinemedi (ID yanlış olabilir).");
            }
        }
        public Product GetById(int id) { return null; }
    }
}