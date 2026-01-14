using StokTakipSistemi.DOMAIN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakipSistemi.BLL
{
    public static class CurrentUser
    {
        // Program açık olduğu sürece giriş yapan kullanıcıyı burada tutacağız
        public static User Identity { get; set; }
    }
}
