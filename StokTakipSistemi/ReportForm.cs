using StokTakipSistemi.BLL; // Katmanları kullanabilmek için
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace StokTakipSistemi
{
    public partial class ReportForm : Form
    {
        ProductManager _pMgr = new ProductManager();
        SalesManager _sMgr = new SalesManager(); // Yeni oluşturduğumuz dosya

        public ReportForm()
        {
            InitializeComponent();
        }

        private void ReportForm_Load(object sender, EventArgs e)
        {
            VerileriYukle();
        }

        private void VerileriYukle()
        {
            // 1.Verileri Çek
            var tumUrunler = _pMgr.GetAllProducts();
            var satislar = _sMgr.GetDetailedReport(); // JOIN'li detaylı satış raporun

            // 2. Tabloları Bağla
            dgvAllStock.DataSource = tumUrunler;
            dgvCriticalStock.DataSource = tumUrunler.Where(x => x.StockQuantity <= x.MinStockLimit).ToList();
            dgvSalesHistory.DataSource = satislar;

            // 3. Üst Kartları Doldur (Rakamları Hesapla)
           lblTotalProduct.Text = tumUrunler.Count.ToString();
            lblTotalSales.Text = satislar.Rows.Count.ToString();
            lblCriticalCount.Text = tumUrunler.Count(x => x.StockQuantity <= x.MinStockLimit).ToString();

            decimal ciro = 0;
            foreach (DataRow row in satislar.Rows)
            {
                ciro += Convert.ToDecimal(row["Toplam Tutar"]);
            }
            lblTotalRevenue.Text = ciro.ToString("C2"); // TL formatında gösterir

            // 4. Gereksiz Sütunları Gizle (Görseli Temizler)
            dgvAllStock.Columns["Id"].Visible = false;
            dgvAllStock.Columns["CreatedDate"].Visible = false;
            dgvCriticalStock.Columns["Id"].Visible = false;


        }
    

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}