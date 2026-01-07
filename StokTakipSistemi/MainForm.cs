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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void ürünYönetimiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProductForm frm = new ProductForm(); frm.MdiParent = this; frm.Show();
        }

        private void müşteriYönetimiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomerForm frm = new CustomerForm();
            frm.MdiParent = this;
            frm.Show();
        }

        private void raporlarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportForm frm = new ReportForm();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
