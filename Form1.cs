using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ArabaKirala
{
    public partial class frmAnaSayfa : Form
    {
        public frmAnaSayfa()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string girilenTC = txtTC.Text;
            string girilenSifre = txtSifre.Text;
            Giris giris = new Giris();
            SqlDataReader oku = giris.Giris2(girilenTC, girilenSifre);
            
            if (oku.Read())
            {
                Form2 gor = new Form2();
                gor.ShowDialog();

            }
            else
            {
                MessageBox.Show("Hatalı Giriş");
            }
            oku.Close();
        }

            private void button2_Click(object sender, EventArgs e)
        {
            frmMusteri musteriEkle= new frmMusteri();   
            musteriEkle.ShowDialog();
        }

       

        private void frmAnaSayfa_Load_1(object sender, EventArgs e)
        {
            txtSifre.PasswordChar = '*';
        }

       
    }



}
