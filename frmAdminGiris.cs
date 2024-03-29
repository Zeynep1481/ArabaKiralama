using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArabaKirala
{
    public partial class frmAdminGiris : Form
    {
        public frmAdminGiris()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtSifre.Text == "6" && txtTC.Text == "66666666666")
            {
                frmAdmincs admin = new frmAdmincs();
                admin.ShowDialog();
            }
            else
                MessageBox.Show("Admin Kullanıcısı Değilsiniz.");
        }

        private void frmAdminGiris_Load(object sender, EventArgs e)
        {
            txtSifre.PasswordChar = '*';
        }

       
    }
}
