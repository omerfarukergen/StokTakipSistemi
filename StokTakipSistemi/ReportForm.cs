using StokTakipSistemi.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StokTakipSistemi
{
    public partial class ReportForm : Form
    {
        ProductManager _pMgr = new ProductManager();
        public ReportForm()
        {
            InitializeComponent();
            GetReports();
        }
        private void GetReports()
        {
            var tumUrunler = _pMgr.GetAllProducts();

            // 1. Rapor: Kritik Stok (Stok <= MinLimit olanlar)
            var kritikUrunler = tumUrunler.Where(x => x.StockQuantity <= x.MinStockLimit).ToList();
            dgvCriticalStock.DataSource = kritikUrunler;

            // 2. Rapor: Tüm Liste
            dgvAllStock.DataSource = tumUrunler;
        }
        private void ReportForm_Load(object sender, EventArgs e)
        {

        }
    }
}
