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
    public partial class frmArabaListele : Form
    {
        Araba_Kiralama arabakiralama=new Araba_Kiralama();
        public frmArabaListele()
        {
            InitializeComponent();
        }

        private void comboAraçlar_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frmArabaListele_Load(object sender, EventArgs e)
        {
            YenileArabalarListesi();
            
                comboAraçlar.SelectedIndex= 0;  
           

        }

        private void YenileArabalarListesi()
        {
            string cümle = "select*from araba";
            SqlDataAdapter adtr2 = new SqlDataAdapter();
            dataGridView1.DataSource=arabakiralama.listele(adtr2, cümle);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satır = dataGridView1.CurrentRow;
            Plakatxt.Text = satır.Cells["plaka"].Value.ToString();
            Markacombo.Text = satır.Cells["marka"].Value.ToString();
            Sericombo.Text = satır.Cells["seri"].Value.ToString();
            Yakıtcombo.Text = satır.Cells["y_tipi"].Value.ToString();
            Yiltxt.Text = satır.Cells["model"].Value.ToString();
            Vitestxt.Text = satır.Cells["v_tipi"].Value.ToString();
            Kmtxt.Text = satır.Cells["Km"].Value.ToString();
            Ücrettxt.Text = satır.Cells["g_fiyat"].Value.ToString();
            pictureBox2.ImageLocation = satır.Cells["resim"].Value.ToString();
           
        }

        private void btn_Resim_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pictureBox2.ImageLocation = openFileDialog1.FileName;


        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            string cümle = "update araba set marka=@marka,seri=@seri,model=@model,v_tipi=@v_tipi,km=@km,g_fiyat=@g_fiyat,resim=@resim,tarih=@tarih where plaka=@plaka";
            SqlCommand komut2=new SqlCommand();
            komut2.Parameters.AddWithValue("@plaka", Plakatxt.Text);
            komut2.Parameters.AddWithValue("@marka", Markacombo.Text);
            komut2.Parameters.AddWithValue("@seri", Sericombo.Text);
            komut2.Parameters.AddWithValue("@y_tipi", Yakıtcombo.Text);
            komut2.Parameters.AddWithValue("@model", Yiltxt.Text);
            komut2.Parameters.AddWithValue("@v_tipi", Vitestxt.Text);
            komut2.Parameters.AddWithValue("@km", Kmtxt.Text);
            komut2.Parameters.AddWithValue("@g_fiyat", int.Parse(Ücrettxt.Text));
            komut2.Parameters.AddWithValue("@resim", pictureBox2.ImageLocation);
            komut2.Parameters.AddWithValue("@tarih", DateTime.Now.ToString());
            arabakiralama.ekle_sil_guncelle(komut2, cümle);
            Sericombo.Items.Clear();
            foreach (Control item in Controls) if (item is TextBox) item.Text = "";
            foreach (Control item in Controls) if (item is ComboBox) item.Text = "";
            pictureBox2.ImageLocation = "";
            YenileArabalarListesi();

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
           
            DataGridViewRow satır = dataGridView1.CurrentRow;
            string plaka = satır.Cells["plaka"].Value.ToString();
            string cümle = "delete from araba where plaka='" + satır.Cells["plaka"].Value.ToString() + "'";
            SqlCommand komut2 = new SqlCommand();
            arabakiralama.ekle_sil_guncelle(komut2, cümle);
            YenileArabalarListesi();
            Sericombo.Items.Clear();
            foreach (Control item in Controls) if (item is TextBox) item.Text = "";
            foreach (Control item in Controls) if (item is ComboBox) item.Text = "";
            pictureBox2.ImageLocation = "";
            
        }

        private void Markacombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Sericombo.Items.Clear();
                if (Markacombo.SelectedIndex == 0)
                {
                    Sericombo.Items.Add("316i");
                    Sericombo.Items.Add("520d");
                    Sericombo.Items.Add("M4");
                }
                else if (Markacombo.SelectedIndex == 1)
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

        private void comboAraçlar_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                if (comboAraçlar.SelectedIndex == 0)
                {
                    YenileArabalarListesi();
                }
                if (comboAraçlar.SelectedIndex == 1)
                {
                    string cümle = "select*from araba where durum='BOŞ'";
                    SqlDataAdapter adtr2 = new SqlDataAdapter();
                    dataGridView1.DataSource = arabakiralama.listele(adtr2, cümle);
                }
                if (comboAraçlar.SelectedIndex == 2)
                {
                    string cümle = "select*from araba WHERE durum='DOLU'";
                    SqlDataAdapter adtr2 = new SqlDataAdapter();
                    dataGridView1.DataSource = arabakiralama.listele(adtr2, cümle);
                }
               

            }
            catch 
            {

                ;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
