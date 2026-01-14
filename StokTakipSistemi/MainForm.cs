// Kanka buraya dikkat, eğer LoginForm farklı bir yerdeyse burayı düzelteceğiz
using StokTakipSistemi;
using StokTakipSistemi.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
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
            lblDateTime.Text = DateTime.Now.ToString("dd MMMM yyyy | HH:mm:ss");
        }

        private void ürünYönetimiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProductForm frm = new ProductForm();
            frm.MdiParent = this;
            frm.Show();
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

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (CurrentUser.Identity != null && CurrentUser.Identity.Role == "Kasiyer")
            {
                //raporlarToolStripMenuItem.Visible = false;
                MessageBox.Show("Kasiyer Yetkisiyle Giriş Yapıldı.");
            }
        }

        private void satışEkranıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SalesForm frm = new SalesForm();
            frm.MdiParent = this;
            frm.Show();
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult sonuc = MessageBox.Show("Oturumu kapatmak istediğinize emin misiniz?", "Çıkış Yap", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (sonuc == DialogResult.Yes)
            {
                // 1. Kimliği sıfırla
                CurrentUser.Identity = null;

                // 2. LoginForm'u oluştur (Eğer hata verirse başına global::StokTakipSistemi. ekle)
                LoginForm login = new LoginForm();
                login.Show();

                // 3. Ana formu kapat veya gizle
                this.Hide();
            }
        }
        private void btn_MouseEnter(object sender, EventArgs e)
        {
            // Hangi butona basıldığını 'sender' üzerinden yakalıyoruz
            Button btn = (Button)sender;
            btn.BackColor = Color.FromArgb(40, 30, 130); // Parlama rengi
        }

        private void btn_MouseLeave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackColor = Color.FromArgb(27, 20, 100); // Orijinal lacivert
        }
        private void FormuGetir(Form frm)
        {
            // 1. Panelin içini temizle (Eski açık formu kapatır)
            pnlContent.Controls.Clear();

            // 2. Formu bir 'alt eleman' haline getir
            frm.TopLevel = false;

            // 3. Formun çerçevesini ve üst çubuğunu sil (Panele tam otursun)
            frm.FormBorderStyle = FormBorderStyle.None;

            // 4. Formun paneli tamamen kaplamasını sağla
            frm.Dock = DockStyle.Fill;

            // 5. Formu panele ekle ve göster
            pnlContent.Controls.Add(frm);
            frm.Show();
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            ProductForm frm = new ProductForm();
            FormuGetir(frm);
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            CustomerForm frm = new CustomerForm();
            FormuGetir(frm);
        }

        private void btnSales_Click(object sender, EventArgs e)
        {
            SalesForm frm = new SalesForm();
            FormuGetir(frm);
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            ReportForm frm = new ReportForm();
            FormuGetir(frm);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblDateTime.Text = DateTime.Now.ToString("dd MMMM yyyy | HH:mm:ss");
        }

        private void lblDateTime_Click(object sender, EventArgs e)
        {

        }
    }
}