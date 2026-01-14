using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
    
namespace StokTakipSistemi.DAL
{
    public class DbConnection
    {
        // Bağlantı dizesi (Senin veritabanı bilgilerine göre ayarlı)
        private string connectionString = "Server=172.21.54.253;Database=26_132430062;User ID=26_132430062;Password=İnif123.;";

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
    }
}
