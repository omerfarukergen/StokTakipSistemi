using StokTakipSistemi.BLL;
using StokTakipSistemi.DAL;
using StokTakipSistemi.DOMAIN;
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
    public partial class SalesForm : Form
    {
        ProductManager _pMgr = new ProductManager();
        CustomerManager _cMgr = new CustomerManager();
        SalesRepository _sRepo = new SalesRepository();
        public SalesForm()
        {
            InitializeComponent();
            LoadCombos();
            SatisListele();
        }
        void LoadCombos()
        {
            // Ürünler
            var urunler = _pMgr.GetAllProducts();
            cmbProducts.DataSource = urunler;
            cmbProducts.DisplayMember = "ProductName"; // Ekranda görünecek isim (Property ismiyle aynı olmalı)
            cmbProducts.ValueMember = "Id";            // Arka planda tutulacak ID

            // Müşteriler
            var musteriler = _cMgr.GetList();
            cmbCustomers.DataSource = musteriler;
            cmbCustomers.DisplayMember = "FullName";   // Ekranda görünecek isim
            cmbCustomers.ValueMember = "Id";           // Arka planda tutulacak ID
        }
        private void btnSell_Click(object sender, EventArgs e)
        {
            if (cmbProducts.SelectedValue == null || cmbCustomers.SelectedValue == null)
            {
                MessageBox.Show("Lütfen ürün ve müşteri seçiniz!");
                return;
            }

            var yeniSatis = new StokTakipSistemi.DOMAIN.Sale
            {
                // SelectedValue kullanarak doğrudan ID'yi alıyoruz
                ProductId = Convert.ToInt32(cmbProducts.SelectedValue),
                CustomerId = Convert.ToInt32(cmbCustomers.SelectedValue),
                Quantity = (int)nmQuantity.Value,
                TotalPrice = 0, // Manager içinde hesaplatabilirsin veya buraya fiyat ekle
                SaleDate = DateTime.Now
            };

            _sRepo.MakeSale(yeniSatis);
            MessageBox.Show("Satış başarılı!");
            SatisListele(); // Tabloyu yenilemek için
            LoadCombos();   // ComboBox'ı yenilemek için
        }

        void SatisListele()
        {
            var satislar = _sRepo.GetAllSales();

            dgvSales.DataSource = null;
            dgvSales.AutoGenerateColumns = true; // Sütunları sistem kendisi yaratsın
            dgvSales.DataSource = satislar;

            // RENK AYARI BURADA KANKA:
            dgvSales.DefaultCellStyle.ForeColor = Color.Black; // Yazı rengi siyah
            dgvSales.DefaultCellStyle.BackColor = Color.White; // Arka plan beyaz
            dgvSales.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black; // Başlık yazı rengi

            dgvSales.Refresh(); // Tabloyu zorla yenile
        }
        private void txtPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void SalesForm_Load(object sender, EventArgs e)
        {

        }

        private void dgvSales_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnSell_Click_1(object sender, EventArgs e)
        {
            if (cmbProducts.SelectedValue == null || cmbCustomers.SelectedValue == null)
            {
                MessageBox.Show("Lütfen ürün ve müşteri seçiniz!");
                return;
            }

            var yeniSatis = new StokTakipSistemi.DOMAIN.Sale
            {
                // SelectedValue kullanarak doğrudan ID'yi alıyoruz
                ProductId = Convert.ToInt32(cmbProducts.SelectedValue),
                CustomerId = Convert.ToInt32(cmbCustomers.SelectedValue),
                Quantity = (int)nmQuantity.Value,
                TotalPrice = 0, // Manager içinde hesaplatabilirsin veya buraya fiyat ekle
                SaleDate = DateTime.Now
            };

            _sRepo.MakeSale(yeniSatis);
            MessageBox.Show("Satış başarılı!");
            SatisListele(); // Tabloyu yenilemek için
            LoadCombos();   // ComboBox'ı yenilemek için
        }
    }
}


