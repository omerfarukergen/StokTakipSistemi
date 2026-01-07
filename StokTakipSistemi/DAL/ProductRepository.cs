using MySql.Data.MySqlClient;
using StokTakipSistemi.DOMAIN;
using System;
using System.Collections.Generic;

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
        public void Update(Product entity) { /* Kodlar buraya gelecek */ }
        public void Delete(int id) { /* Kodlar buraya gelecek */ }
        public Product GetById(int id) { return null; }
    }
}