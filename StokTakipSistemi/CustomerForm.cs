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
                CustomerType = cmbCustomerType.SelectedItem.ToString()
            };
            MessageBox.Show(_mgr.Save(c));
            dgvCustomers.DataSource = _mgr.GetList();
        }

        private void dgvCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCustomerName.Text = dgvCustomers.CurrentRow.Cells["FullName"].Value.ToString();
            txtPhone.Text = dgvCustomers.CurrentRow.Cells["Phone"].Value.ToString();
            cmbCustomerType.SelectedItem = dgvCustomers.CurrentRow.Cells["CustomerType"].Value.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var c = new DOMAIN.Customer
            {
                Id = Convert.ToInt32(dgvCustomers.CurrentRow.Cells["Id"].Value),
                FullName = txtCustomerName.Text,
                Phone = txtPhone.Text,
                CustomerType = cmbCustomerType.SelectedItem.ToString()
            };
            _mgr.UpdateCustomer(c);
            MessageBox.Show("Müşteri güncellendi.");
            dgvCustomers.DataSource = _mgr.GetList();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgvCustomers.CurrentRow.Cells["Id"].Value);
            _mgr.DeleteCustomer(id);
            MessageBox.Show("Müşteri silindi.");
            dgvCustomers.DataSource = _mgr.GetList();
        }
    }
}
