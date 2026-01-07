using StokTakipSistemi.DAL;
using StokTakipSistemi.DOMAIN;
using System.Linq;

namespace StokTakipSistemi.BLL
{
    public class UserManager
    {
        // Şimdilik test için manuel kontrol yapıyoruz, ileride UserRepository ekleyebilirsin
        public bool Login(string username, string password)
        {
            // Veritabanına eklediğimiz admin/1234 bilgisiyle eşleşiyor mu?
            if (username == "admin" && password == "1234")
                return true;

            return false;
        }
    }
}