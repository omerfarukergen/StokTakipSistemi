using StokTakipSistemi.DAL;
using StokTakipSistemi.DOMAIN;
using System;
using System.Data;

namespace StokTakipSistemi.BLL
{
    public class SalesManager
    {
        // DAL katmanındaki Repository'ye bağlanıyoruz
        private SalesRepository _salesRepo = new SalesRepository();

        // Satış yapma kuralı
        public void MakeSale(Sale sale)
        {
            // İleride buraya "Stok yetersizse satış yapma" gibi kurallar ekleyebiliriz kanka
            _salesRepo.MakeSale(sale);
        }

        // İŞTE BİZE LAZIM OLAN: Raporu çeken metod
        public DataTable GetDetailedReport()
        {
            // Repository'deki o isimli (JOIN'li) raporu çağırıyoruz
            return _salesRepo.GetDetailedSalesReport();
        }
    }
}