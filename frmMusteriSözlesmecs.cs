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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace ArabaKirala
{
    public partial class frmMusteriSözlesmecs : Form
    {
        public frmMusteriSözlesmecs()
        {
            InitializeComponent();
        }
        Araba_Kiralama araba = new Araba_Kiralama();

        private void textBox14_TextChanged(object sender, EventArgs e)
        {
           

            //Prosedür
            string tcValue = txtTc.Text;
            SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-6P4VD2O\\SQLEXPRESS;Initial Catalog=A_Kiralama;Integrated Security=True");

            using (SqlCommand komut = new SqlCommand("TCAra", baglanti))
            {
                komut.CommandType = CommandType.StoredProcedure;
                komut.Parameters.AddWithValue("@tc", tcValue);

                baglanti.Open();
                SqlDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    txtAd.Text = oku["M_Ad"].ToString();
                    txtSoyad.Text = oku["M_Soyad"].ToString();
                    txtTelefon.Text = oku["M_TelNo"].ToString();
                    txtE_Sure.Text = oku["M_EhliyetSure"].ToString();
                    txtE_Tipi.Text = oku["M_EhliyetT"].ToString();
                    txtyas.Text = oku["M_Yas"].ToString();

                }


                baglanti.Close();
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string baglanti2 = "Data Source=DESKTOP-6P4VD2O\\SQLEXPRESS;Initial Catalog=A_Kiralama;Integrated Security=True";
            string plaka = comboAraba.SelectedItem.ToString();


            using (SqlConnection baglanti = new SqlConnection(baglanti2))
            {
                SqlCommand command = new SqlCommand("ArabaListele", baglanti);
                command.CommandType = CommandType.StoredProcedure;


                command.Parameters.AddWithValue("@Plaka", plaka);

                try
                {
                    baglanti.Open();


                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {

                                txtMarka.Text = reader["marka"].ToString();
                                txtSeri.Text = reader["seri"].ToString();
                                txtYil.Text = reader["model"].ToString();
                                txtV_tipi.Text = reader["v_tipi"].ToString();

                            }
                        }
                        else
                        {
                            MessageBox.Show("Araç bulunamadı.");
                        }
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Hata oluştu: " + ex.Message);
                }
                finally
                {
                    baglanti.Close();
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sorgu2 = "select *from araba where plaka like '" + comboAraba.SelectedItem + "'";
            araba.UcretHesapla(comboKiraŞekli, txtKiraÜcreti, sorgu2);
        }
       

        
        private void Temizle()
        {
            dateÇıkış.Text = DateTime.Now.ToShortDateString();
            dateDönüş.Text = DateTime.Now.ToShortDateString();
            comboKiraŞekli.Text = "";
            txtKiraÜcreti.Text = "";
            txtGün.Text = "";
            txtTutar.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string sorgu2 = "insert into sözleşme(M_tc,M_Ad,M_Soyad,M_TelNo,plaka,marka,seri,model,v_tipi,kirasekli,g_fiyat,gun,tutar,ctarih,dtarih) values(@M_tc,@M_Ad,@M_Soyad,@M_TelNo,@plaka,@marka,@seri,@model,@v_tipi,@kirasekli,@g_fiyat,@gun,@tutar,@ctarih,@dtarih)";
            SqlCommand komut2 = new SqlCommand();
            komut2.Parameters.AddWithValue("@M_tc", txtTc.Text);
            komut2.Parameters.AddWithValue("@M_ad", txtAd.Text);
            komut2.Parameters.AddWithValue("@M_Soyad", txtSoyad.Text);
            komut2.Parameters.AddWithValue("@M_TelNo", txtTelefon.Text);
            komut2.Parameters.AddWithValue("@M_EhliyetSure", txtE_Sure.Text);
            komut2.Parameters.AddWithValue("@M_EhliyetT", txtE_Tipi.Text);
            komut2.Parameters.AddWithValue("@M_Yas", txtyas.Text);
            komut2.Parameters.AddWithValue("@plaka", comboAraba.Text);
            komut2.Parameters.AddWithValue("@marka", txtMarka.Text);
            komut2.Parameters.AddWithValue("@seri", txtSeri.Text);
            komut2.Parameters.AddWithValue("@model", txtYil.Text);
            komut2.Parameters.AddWithValue("@v_tipi", txtV_tipi.Text);
            komut2.Parameters.AddWithValue("@kirasekli", comboKiraŞekli.Text);
            komut2.Parameters.AddWithValue("@g_fiyat", int.Parse(txtKiraÜcreti.Text));
            komut2.Parameters.AddWithValue("@gun", int.Parse(txtGün.Text));
            komut2.Parameters.AddWithValue("@tutar", int.Parse(txtTutar.Text));
            komut2.Parameters.AddWithValue("@ctarih", dateÇıkış.Text);
            komut2.Parameters.AddWithValue("@dtarih", dateDönüş.Text);
            araba.ekle_sil_guncelle(komut2, sorgu2);

            string sorgu3 = " update araba set durum='DOLU' where plaka='" + comboAraba.Text + "'";
            SqlCommand komut3 = new SqlCommand();
            araba.ekle_sil_guncelle(komut3, sorgu3);
            comboAraba.Items.Clear();
            Boş_Arabalar();
           
            foreach (Control item in groupBox1.Controls) if (item is TextBox) item.Text = "";
            foreach (Control item in groupBox2.Controls) if (item is TextBox) item.Text = "";
            comboAraba.Text = "";
            Temizle();
            MessageBox.Show("Sözleşme eklendi");
        }

       
        private void button2_Click(object sender, EventArgs e)
        {
            TimeSpan gun = DateTime.Parse(dateDönüş.Text) - DateTime.Parse(dateÇıkış.Text);
            int gun2 = gun.Days;
            txtGün.Text = gun2.ToString();
            txtTutar.Text = (gun2 * int.Parse(txtKiraÜcreti.Text)).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void frmMusteriSözlesmecs_Load(object sender, EventArgs e)
        {
            Boş_Arabalar();
           
        }
        private void Boş_Arabalar()
        {
            string sorgu2 = " select *from araba where durum='BOŞ'";
            araba.Bos_Arabalar(comboAraba, sorgu2);
        }
       

    }
}
