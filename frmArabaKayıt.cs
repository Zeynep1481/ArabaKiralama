using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArabaKirala
{
    public partial class frmArabaKayıt : Form
    {
        Araba_Kiralama arabakiralama = new Araba_Kiralama();

        public frmArabaKayıt()
        {
            InitializeComponent();
        }

       

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

     

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pictureBox1.ImageLocation = openFileDialog1.FileName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Sericombo.Items.Clear();    
                if(Markacombo.SelectedIndex == 0)
                {
                    Sericombo.Items.Add("316i");
                    Sericombo.Items.Add("520d");
                    Sericombo.Items.Add("M4");
                }
                else if(Markacombo.SelectedIndex == 1)
                {
                    Sericombo.Items.Add("Albea");
                    Sericombo.Items.Add("Egea");
                    Sericombo.Items.Add("Linea");
                }
                else if (Markacombo.SelectedIndex == 2)
                {
                    Sericombo.Items.Add("Civic");
                    Sericombo.Items.Add("Accord");
                    
                }
                else if (Markacombo.SelectedIndex == 3)
                {
                    Sericombo.Items.Add("CLA");
                    Sericombo.Items.Add("E Serisi");

                }
                else if (Markacombo.SelectedIndex == 4)
                {
                    Sericombo.Items.Add("Astra");
                    Sericombo.Items.Add("Corsa");
                    Sericombo.Items.Add("Vectra");

                }
                else if (Markacombo.SelectedIndex == 5)
                {
                    Sericombo.Items.Add("S40");
                    Sericombo.Items.Add("V40");
              
                }
            }
            catch 
            {

                ;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cümle = " insert into araba(plaka,marka,seri,y_tipi,model,v_tipi,km,g_fiyat,resim,tarih,durum) values(@plaka,@marka,@seri,@y_tipi,@model,@v_tipi,@km,@g_fiyat,@resim,@tarih,@durum)";
           
            SqlCommand komut2 = new SqlCommand();
            komut2.Parameters.AddWithValue("@plaka", Plakatxt.Text);
            komut2.Parameters.AddWithValue("@marka", Markacombo.Text);
            komut2.Parameters.AddWithValue("@seri", Sericombo.Text);
            komut2.Parameters.AddWithValue("@y_tipi",Yakıtcombo.Text);
            komut2.Parameters.AddWithValue("@model", Yiltxt.Text);
            komut2.Parameters.AddWithValue("@v_tipi", Vitestxt.Text);
            komut2.Parameters.AddWithValue("@km", Kmtxt.Text);
            komut2.Parameters.AddWithValue("@g_fiyat", int.Parse(Ücrettxt.Text));
            komut2.Parameters.AddWithValue("@resim", pictureBox1.ImageLocation);
            komut2.Parameters.AddWithValue("@tarih",DateTime.Now.ToString());
            komut2.Parameters.AddWithValue("@durum", "BOŞ");
            arabakiralama.ekle_sil_guncelle(komut2, cümle);
            Sericombo.Items.Clear();
            foreach (Control item in Controls) if (item is TextBox) item.Text = "";
            foreach (Control item in Controls) if (item is ComboBox) item.Text = "";
            pictureBox1.ImageLocation = "";

        }

        
    }
}
