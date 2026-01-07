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
    public partial class ProductForm : Form
    {
        ProductManager _productManager = new ProductManager();
        public ProductForm()
        {
            InitializeComponent();
        }

        private void ProductForm_Load(object sender, EventArgs e)
        {
            RefreshData();
        }
        private void RefreshData()
        {
            // BLL üzerinden verileri çekip tabloya basıyoruz
            dgvProducts.DataSource = _productManager.GetAllProducts();
            var urunler = _productManager.GetAllProducts();
            dgvProducts.DataSource = urunler;

            // Stok kontrolü
            foreach (DataGridViewRow row in dgvProducts.Rows)
            {
                int stok = Convert.ToInt32(row.Cells["StockQuantity"].Value);
                int limit = Convert.ToInt32(row.Cells["MinStockLimit"].Value);

                if (stok <= limit)
                {
                    row.DefaultCellStyle.BackColor = Color.Red; 
                    row.DefaultCellStyle.ForeColor = Color.White;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var yeniUrun = new DOMAIN.Product
            {
                ProductName = txtProductName.Text,
                StockQuantity = int.Parse(txtStock.Text),
                Price = decimal.Parse(txtPrice.Text),
                MinStockLimit = int.Parse(txtMinLimit.Text)
            };

            string mesaj = _productManager.AddProduct(yeniUrun);
            MessageBox.Show(mesaj);
            RefreshData();
        }

        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtProductName.Text = dgvProducts.CurrentRow.Cells["ProductName"].Value.ToString();
            txtStock.Text = dgvProducts.CurrentRow.Cells["StockQuantity"].Value.ToString();
            txtPrice.Text = dgvProducts.CurrentRow.Cells["Price"].Value.ToString();
            txtMinLimit.Text = dgvProducts.CurrentRow.Cells["MinStockLimit"].Value.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgvProducts.CurrentRow.Cells["Id"].Value);
            _productManager.DeleteProduct(id);
            MessageBox.Show("Ürün başarıyla silindi.");
            RefreshData(); // Tabloyu yeniler
        }
    }
    }

