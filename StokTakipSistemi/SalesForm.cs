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
        }
        void LoadCombos()
        {
            cmbProducts.DataSource = _pMgr.GetAllProducts();
            cmbProducts.DisplayMember = "ProductName";
            cmbProducts.ValueMember = "Id";

            cmbCustomers.DataSource = _cMgr.GetList();
            cmbCustomers.DisplayMember = "FullName";
            cmbCustomers.ValueMember = "Id";
        }
        private void btnSell_Click(object sender, EventArgs e)
        {
            var seciliUrun = (Product)cmbProducts.SelectedItem;

            var yeniSatis = new Sale
            {
                ProductId = (int)cmbProducts.SelectedValue,
                CustomerId = (int)cmbCustomers.SelectedValue,
                Quantity = (int)nmQuantity.Value,
                TotalPrice = seciliUrun.Price * nmQuantity.Value,
                SaleDate = DateTime.Now
            };

            _sRepo.MakeSale(yeniSatis);
            MessageBox.Show($"Satış Başarılı! Toplam Tutar: {yeniSatis.TotalPrice}");
        
    }
    }
}

