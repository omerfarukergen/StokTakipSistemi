using MySql.Data.MySqlClient;
using StokTakipSistemi.DOMAIN;
using System;
using System.Collections.Generic;

namespace StokTakipSistemi.DAL
{
    public class CustomerRepository : IRepository<Customer>
    {
        private DbConnection db = new DbConnection();

        public List<Customer> GetAll()
        {
            List<Customer> customers = new List<Customer>();
            using (var conn = db.GetConnection())
            {
                string query = "SELECT * FROM Customers";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        customers.Add(new Customer
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            FullName = reader["FullName"].ToString(),
                            CustomerType = reader["CustomerType"].ToString(),
                            Phone = reader["Phone"].ToString(),
                            Address = reader["Address"].ToString() // ADRES BURAYA EKLENDİ
                        });
                    }
                }
            }
            return customers;
        }

        public void Add(Customer entity)
        {
            using (var conn = db.GetConnection())
            {
                // INSERT sorgusuna Address eklendi
                string query = "INSERT INTO Customers (FullName, CustomerType, Phone, Address) VALUES (@name, @type, @phone, @address)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", entity.FullName);
                cmd.Parameters.AddWithValue("@type", entity.CustomerType);
                cmd.Parameters.AddWithValue("@phone", entity.Phone);
                cmd.Parameters.AddWithValue("@address", entity.Address); // ADRES PARAMETRESİ
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(Customer entity)
        {
            using (var conn = db.GetConnection())
            {
                // UPDATE sorgusuna Address eklendi
                string query = "UPDATE Customers SET FullName=@name, CustomerType=@type, Phone=@phone, Address=@address WHERE Id=@id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", entity.FullName);
                cmd.Parameters.AddWithValue("@type", entity.CustomerType);
                cmd.Parameters.AddWithValue("@phone", entity.Phone);
                cmd.Parameters.AddWithValue("@address", entity.Address); // ADRES PARAMETRESİ
                cmd.Parameters.AddWithValue("@id", entity.Id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (var conn = db.GetConnection())
            {
                string query = "DELETE FROM Customers WHERE Id=@id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public Customer GetById(int id) { return null; }
    }
}