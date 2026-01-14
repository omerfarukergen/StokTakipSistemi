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
    public partial class CustomerForm : Form
    {
        CustomerManager _mgr = new CustomerManager();
        public CustomerForm()
        {
            InitializeComponent();
        }

        private void btnSaveCustomer_Click(object sender, EventArgs e)
        {
            var c = new DOMAIN.Customer
            {
                FullName = txtCustomerName.Text,
                Phone = txtPhone.Text,
                CustomerType = cmbCustomerType.SelectedItem?.ToString() ?? "Bireysel",
                Address = txtAddress.Text // 2. EKSİK: Adres buraya eklendi
            };
            MessageBox.Show(_mgr.Save(c));
            Yenile();
        }

        private void dgvCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Hücreye tıklandığında verileri kutulara doldur
            if (dgvCustomers.CurrentRow != null)
            {
                txtCustomerName.Text = dgvCustomers.CurrentRow.Cells["FullName"].Value.ToString();
                txtPhone.Text = dgvCustomers.CurrentRow.Cells["Phone"].Value.ToString();
                cmbCustomerType.SelectedItem = dgvCustomers.CurrentRow.Cells["CustomerType"].Value.ToString();
                txtAddress.Text = dgvCustomers.CurrentRow.Cells["Address"].Value?.ToString(); // 3. EKSİK: Adresi kutuya çek
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var c = new DOMAIN.Customer
            {
                Id = Convert.ToInt32(dgvCustomers.CurrentRow.Cells["Id"].Value),
                FullName = txtCustomerName.Text,
                Phone = txtPhone.Text,
                CustomerType = cmbCustomerType.SelectedItem.ToString(),
                Address = txtAddress.Text // 4. EKSİK: Güncellemeye adres eklendi
            };
            _mgr.UpdateCustomer(c);
            MessageBox.Show("Müşteri güncellendi.");
            Yenile();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.CurrentRow != null)
            {
                int id = Convert.ToInt32(dgvCustomers.CurrentRow.Cells["Id"].Value);
                _mgr.DeleteCustomer(id);
                MessageBox.Show("Müşteri silindi.");
                Yenile();
            }
        }

        private void txtCustomerName_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbCustomerType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void CustomerForm_Load(object sender, EventArgs e)
        {
            Yenile();
        }
        private void Yenile()
        {
            dgvCustomers.DataSource = _mgr.GetList();
            // Görsel düzeltme: ID ve Adres gibi kolonları istersen gizleyebilirsin
        }
        private void dgvCustomers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
