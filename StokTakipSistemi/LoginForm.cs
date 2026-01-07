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
    public partial class Form1 : Form
    {
        UserManager _userManager = new UserManager();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string user = txtUsername.Text;
            string pass = txtPassword.Text;

            if (_userManager.Login(user, pass))
            {
                MessageBox.Show("Giriş Başarılı!");
                MainForm anaForm = new MainForm();
                anaForm.Show();
                this.Hide(); // Login formunu gizle
            }
            else
            {
                MessageBox.Show("Hatalı kullanıcı adı veya şifre!");
            }
        }
    }
}
