using iTextSharp.text.pdf.qrcode;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


    namespace ArabaKirala
{

    public partial class frmImport : Form
    {
        public frmImport()
        {
            InitializeComponent();
        }

        private void btndosya_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtdosya.Text = openFileDialog.FileName;
            }
        }

        private void btnyükle_Click(object sender, EventArgs e)
        {
            string dosyaYolu = txtdosya.Text;

            if (!string.IsNullOrEmpty(dosyaYolu) && File.Exists(dosyaYolu))
            {
                try
                {
                    using (StreamReader sr = new StreamReader(dosyaYolu))
                    {
                        while (!sr.EndOfStream)
                        {
                            string line = sr.ReadLine();
                            string[] values = line.Split(',');

                            if (values.Length == 11)
                            {
                                string plaka = values[0].ToString();
                                string marka = values[1].ToString();
                                string seri = values[2].ToString();
                                string y_tipi = values[3].ToString();
                                string model = values[4].ToString();
                                string v_tipi = values[5].ToString();
                                string km = values[6].ToString();
                                int g_fiyat;
                                if (!int.TryParse(values[7], out g_fiyat))
                                {

                                    MessageBox.Show("Günlük fiyat değeri geçersiz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    break;
                                }
                                string durum = values[8].ToString();
                                string resim = values[9].ToString();
                                string tarih = values[10].ToString();
                                break;
                            }
                        }

                        MessageBox.Show("Seçilen text dosyasındaki araba bilgileri başarıyla sisteme yüklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Text dosyasındaki araba bilgilerini yüklerken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Lütfen geçerli bir dosya seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void ImportAraba(string plaka, string marka, string seri, string y_tipi, string model, string v_tipi, string km, int g_fiyat, string durum, string resim, string tarih)
        {
            string baglanti2 = "Data Source=DESKTOP-6P4VD2O\\SQLEXPRESS;Initial Catalog=A_Kiralama;Integrated Security=True";
            using (SqlConnection baglanti = new SqlConnection(baglanti2))
            {
                baglanti.Open();

                string sqlQuery = "INSERT INTO araba (plaka,marka,seri,y_tipi,model,v_tipi,km,g_fiyat,durum,resim,tarih) VALUES (@plaka,@marka,@seri,@y_tipi,@model,@v_tipi,@km,@g_fiyat,@durum,@resim,@tarih)";

                using (SqlCommand command = new SqlCommand(sqlQuery, baglanti))
                {
                    command.Parameters.AddWithValue("@plaka", plaka);
                    command.Parameters.AddWithValue("@marka", marka);
                    command.Parameters.AddWithValue("@seri", seri);
                    command.Parameters.AddWithValue("@y_tipi", y_tipi);
                    command.Parameters.AddWithValue("@model", model);
                    command.Parameters.AddWithValue("@v_tipi", v_tipi);
                    command.Parameters.AddWithValue("@km", km);
                    command.Parameters.AddWithValue("@g_fiyat", g_fiyat);
                    command.Parameters.AddWithValue("@durum", durum);
                    command.Parameters.AddWithValue("@resim", resim);
                    command.Parameters.AddWithValue("@tarih", tarih);

                    command.ExecuteNonQuery();
                }
                baglanti.Close();
            }
        }
    }
}



