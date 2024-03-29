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
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;

namespace ArabaKirala
{
    public partial class frmSözleşme : Form
    {
        public frmSözleşme()
        {
            InitializeComponent();
        }
        Araba_Kiralama araba = new Araba_Kiralama();

        

        private void frmSözleşme_Load(object sender, EventArgs e)
        {
            Boş_Arabalar();
            Yenile();
        }

        private void Boş_Arabalar()
        {
            string sorgu2 = " select *from araba where durum='BOŞ'";
            araba.Bos_Arabalar(comboAraba, sorgu2);
        }

        private void Yenile()
        {
            string sorgu3 = "select * from sözleşme";
            SqlDataAdapter adtr2 = new SqlDataAdapter();
            dataGridView1.DataSource = araba.listele(adtr2, sorgu3);
        }

        private void txtTc_TextChanged(object sender, EventArgs e)
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

        //prosedür
        private void comboAraba_SelectedIndexChanged(object sender, EventArgs e)
        {
            string  baglanti2 = "Data Source=DESKTOP-6P4VD2O\\SQLEXPRESS;Initial Catalog=A_Kiralama;Integrated Security=True";
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

        private void comboKiraŞekli_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sorgu2 = "select *from araba where plaka like '" + comboAraba.SelectedItem + "'";
            araba.UcretHesapla(comboKiraŞekli,txtKiraÜcreti,sorgu2 );
        }

        private void btnHesapla_Click(object sender, EventArgs e)
        {
            TimeSpan gun = DateTime.Parse(dateDönüş.Text) - DateTime.Parse(dateÇıkış.Text);
            int gun2 = gun.Days;
            txtGün.Text=gun2.ToString();
            txtTutar.Text=(gun2 * int.Parse(txtKiraÜcreti.Text)).ToString();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
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

        private void btnEkle_Click(object sender, EventArgs e)
        {
            string sorgu2 = "insert into sözleşme(M_tc,M_Ad,M_Soyad,M_TelNo,plaka,marka,seri,model,v_tipi,kirasekli,g_fiyat,gun,tutar,ctarih,dtarih) values(@M_tc,@M_Ad,@M_Soyad,@M_TelNo,@plaka,@marka,@seri,@model,@v_tipi,@kirasekli,@g_fiyat,@gun,@tutar,@ctarih,@dtarih)";
            SqlCommand komut2=new SqlCommand();
            komut2.Parameters.AddWithValue("@M_tc", txtTc.Text);
            komut2.Parameters.AddWithValue("@M_ad", txtAd.Text);
            komut2.Parameters.AddWithValue("@M_Soyad", txtSoyad.Text);
            komut2.Parameters.AddWithValue("@M_TelNo", txtTelefon.Text);
            //komut2.Parameters.AddWithValue("@M_Soyad", txtsoyisim.Text);
            //komut2.Parameters.AddWithValue("@M_Sifre", txtsifre.Text);
            komut2.Parameters.AddWithValue("@M_EhliyetSure", txtE_Sure.Text);
            komut2.Parameters.AddWithValue("@M_EhliyetT", txtE_Tipi.Text);
            komut2.Parameters.AddWithValue("@M_Yas", txtyas.Text);
            komut2.Parameters.AddWithValue("@plaka",comboAraba.Text);
            komut2.Parameters.AddWithValue("@marka", txtMarka.Text);
            komut2.Parameters.AddWithValue("@seri", txtSeri.Text);
            //komut2.Parameters.AddWithValue("@y_tipi", Yakıtcombo.Text);
            komut2.Parameters.AddWithValue("@model", txtYil.Text);
            komut2.Parameters.AddWithValue("@v_tipi", txtV_tipi.Text);
            komut2.Parameters.AddWithValue("@kirasekli",comboKiraŞekli.Text);
            //komut2.Parameters.AddWithValue("@km", Kmtxt.Text);
            komut2.Parameters.AddWithValue("@g_fiyat", int.Parse(txtKiraÜcreti.Text));
            komut2.Parameters.AddWithValue("@gun", int.Parse(txtGün.Text));
            komut2.Parameters.AddWithValue("@tutar", int.Parse(txtTutar.Text));
            //komut2.Parameters.AddWithValue("@resim", pictureBox1.ImageLocation);
            komut2.Parameters.AddWithValue("@ctarih", dateÇıkış.Text);
            komut2.Parameters.AddWithValue("@dtarih", dateDönüş.Text);
            araba.ekle_sil_guncelle(komut2, sorgu2);

            string sorgu3 = " update araba set durum='DOLU' where plaka='" + comboAraba.Text + "'";
            SqlCommand komut3 = new SqlCommand();
            araba.ekle_sil_guncelle(komut3, sorgu3);
            comboAraba.Items.Clear();
            Boş_Arabalar();
            Yenile();
            foreach (Control item in groupBox1.Controls) if (item is TextBox) item.Text = "";
            foreach (Control item in groupBox2.Controls) if (item is TextBox) item.Text = "";
            comboAraba.Text = "";
            Temizle();
            MessageBox.Show("Sözleşme eklendi");
        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            string sorgu2 = "update sözleşme set M_tc=@M_tc,M_Ad=@M_Ad,M_Soyad=@M_Soyad,M_TelNo=@M_TelNo,plaka=@plaka,marka=@marka,seri=@seri,model=@model,v_tipi=@v_tipi,kirasekli=@kirasekli,g_fiyat=@g_fiyat,gun=@gun,tutar=@tutar,ctarih=@ctarih,dtarih=@dtarih where plaka=@plaka";
            SqlCommand komut2 = new SqlCommand();
            komut2.Parameters.AddWithValue("@M_tc", txtTc.Text);
            komut2.Parameters.AddWithValue("@M_ad", txtAd.Text);
            komut2.Parameters.AddWithValue("@M_Soyad", txtSoyad.Text);
            komut2.Parameters.AddWithValue("@M_TelNo", txtTelefon.Text);
            //komut2.Parameters.AddWithValue("@M_Soyad", txtsoyisim.Text);
            //komut2.Parameters.AddWithValue("@M_Sifre", txtsifre.Text);
            komut2.Parameters.AddWithValue("@M_EhliyetSure", txtE_Sure.Text);
            komut2.Parameters.AddWithValue("@M_EhliyetT", txtE_Tipi.Text);
            komut2.Parameters.AddWithValue("@M_Yas", txtyas.Text);
            komut2.Parameters.AddWithValue("@plaka", comboAraba.Text);
            komut2.Parameters.AddWithValue("@marka", txtMarka.Text);
            komut2.Parameters.AddWithValue("@seri", txtSeri.Text);
            //komut2.Parameters.AddWithValue("@y_tipi", Yakıtcombo.Text);
            komut2.Parameters.AddWithValue("@model", txtYil.Text);
            komut2.Parameters.AddWithValue("@v_tipi", txtV_tipi.Text);
            komut2.Parameters.AddWithValue("@kirasekli", comboKiraŞekli.Text);
            //komut2.Parameters.AddWithValue("@km", Kmtxt.Text);
            komut2.Parameters.AddWithValue("@g_fiyat", int.Parse(txtKiraÜcreti.Text));
            komut2.Parameters.AddWithValue("@gun", int.Parse(txtGün.Text));
            komut2.Parameters.AddWithValue("@tutar", int.Parse(txtTutar.Text));
            //komut2.Parameters.AddWithValue("@resim", pictureBox1.ImageLocation);
            komut2.Parameters.AddWithValue("@ctarih", dateÇıkış.Text);
            komut2.Parameters.AddWithValue("@dtarih", dateDönüş.Text);
            araba.ekle_sil_guncelle(komut2, sorgu2);
            comboAraba.Items.Clear();
            Boş_Arabalar();
            Yenile();
            foreach (Control item in groupBox1.Controls) if (item is TextBox) item.Text = "";
            foreach (Control item in groupBox2.Controls) if (item is TextBox) item.Text = "";
            comboAraba.Text = "";
            Temizle();
            MessageBox.Show("Sözleşme güncellendi");
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satır = dataGridView1.CurrentRow;
            txtTc.Text = satır.Cells[0].Value.ToString();
            txtAd.Text = satır.Cells[1].Value.ToString();
            txtSoyad.Text = satır.Cells[2].Value.ToString();
            txtTelefon.Text = satır.Cells[3].Value.ToString();
            comboAraba.Text = satır.Cells[4].Value.ToString();
            txtMarka.Text = satır.Cells[5].Value.ToString();
            txtSeri.Text = satır.Cells[6].Value.ToString();
            txtYil.Text = satır.Cells[7].Value.ToString();
            txtV_tipi.Text = satır.Cells[8].Value.ToString();
            comboKiraŞekli.Text = satır.Cells[9].Value.ToString();
            txtKiraÜcreti.Text = satır.Cells[10].Value.ToString();
            txtGün.Text = satır.Cells[11].Value.ToString();
            txtTutar.Text = satır.Cells[12].Value.ToString();

            string cellValue = satır.Cells[13].Value.ToString();
            DateTime cikisTarihi;
            if (DateTime.TryParse(cellValue, out cikisTarihi))
            {
                dateÇıkış.Value = cikisTarihi; // Başarılı bir dönüşüm yapıldıysa DateTime değerini kullan
            }
            else
            {
                // Dönüşüm başarısız olduysa, uygun bir hata mesajı gösterebilirsiniz
                MessageBox.Show("Geçersiz tarih formatı!");
            }
            dateDönüş.Text = satır.Cells[14].Value.ToString();
            
        }

      
        private void btnArabaTeslim_Click(object sender, EventArgs e)
        {
            
                DataGridViewRow satır = dataGridView1.CurrentRow;
                DateTime bugün = DateTime.Parse(DateTime.Now.ToShortDateString());
                int ucret = int.Parse(satır.Cells["g_fiyat"].Value.ToString());
                int tutar = int.Parse(satır.Cells["tutar"].Value.ToString());
                DateTime çıkış = DateTime.Parse(satır.Cells["ctarih"].Value.ToString());
                TimeSpan gun = bugün - çıkış;
                int _gun = gun.Days;
                int toplamtutar = _gun * ucret;
                //toplamtutar, _gun ve ucret satış tablosuna aktarılacak
                string sorgu1 = "delete from sözleşme where plaka = '" + satır.Cells["plaka"].Value.ToString() + "' ";
                SqlCommand komut = new SqlCommand();
                araba.ekle_sil_guncelle(komut,sorgu1);
                string sorgu2 = "update araba set durum = 'BOŞ' where plaka='" + satır.Cells["plaka"].Value.ToString() + "'";
                SqlCommand komut3 = new SqlCommand();
                araba.ekle_sil_guncelle(komut3, sorgu2);
                string sorgu3 = "insert into satış(M_tc,M_Ad,M_Soyad,plaka,marka,seri,model,v_tipi,gun,fiyat,tutar,tarih1,tarih2) values(@M_tc,@M_Ad,@M_Soyad,@plaka,@marka,@seri,@model,@v_tipi,@gun,@fiyat,@tutar,@tarih1,@tarih2)";
                SqlCommand komut2 = new SqlCommand();
                komut2.Parameters.AddWithValue("@M_tc", satır.Cells["M_tc"].Value.ToString());
                komut2.Parameters.AddWithValue("@M_ad", satır.Cells["M_ad"].Value.ToString());
                komut2.Parameters.AddWithValue("@M_Soyad", satır.Cells["M_soyad"].Value.ToString());
                komut2.Parameters.AddWithValue("@plaka", satır.Cells["plaka"].Value.ToString());
                komut2.Parameters.AddWithValue("@marka", satır.Cells["marka"].Value.ToString());
                komut2.Parameters.AddWithValue("@seri", satır.Cells["seri"].Value.ToString());
                komut2.Parameters.AddWithValue("@model", satır.Cells["model"].Value.ToString());
                komut2.Parameters.AddWithValue("@v_tipi", satır.Cells["v_tipi"].Value.ToString());
                komut2.Parameters.AddWithValue("@gun",_gun);
                komut2.Parameters.AddWithValue("@fiyat", ucret);
                komut2.Parameters.AddWithValue("@tutar", toplamtutar );
                komut2.Parameters.AddWithValue("@tarih1", satır.Cells["ctarih"].Value.ToString());
                komut2.Parameters.AddWithValue("@tarih2", DateTime.Now.ToShortDateString());
                araba.ekle_sil_guncelle(komut2, sorgu3);
                MessageBox.Show("Araba teslim edildi");
                comboAraba.Text = "";
                comboAraba.Items.Clear();
                Boş_Arabalar();
                Yenile();
                foreach (Control item in groupBox1.Controls) if (item is TextBox) item.Text = "";
                foreach (Control item in groupBox2.Controls) if (item is TextBox) item.Text = "";
                comboAraba.Text = "";
                Temizle();

              
        }

        private void btnPDF_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count>0)
            {
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "PDF(*.pdf|*.pdf)";
                save.FileName = "Sözlesme.pdf";
                bool ErrorMessage = false;
                if (save.ShowDialog()==DialogResult.OK)
                {
                    if (File.Exists(save.FileName))
                    {
                        try
                        {
                            File.Delete(save.FileName);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("PDF alınamıyor." + ex.Message);
                            
                        }
                    }
                    if (!ErrorMessage)
                    {
                        try
                        {
                            PdfPTable pdftable = new PdfPTable(dataGridView1.Columns.Count);
                            pdftable.DefaultCell.Padding = 2;
                            pdftable.WidthPercentage = 100;
                            pdftable.HorizontalAlignment = Element.ALIGN_LEFT;
                            foreach (DataGridViewColumn col in dataGridView1.Columns)
                            {
                                PdfPCell pdfcell = new PdfPCell(new Phrase(col.HeaderText));
                                pdftable.AddCell(pdfcell);
                            }
                            //foreach (DataGridViewRow viewRow in dataGridView1.Rows)
                            //{
                            //    foreach (DataGridViewCell dgwCell in viewRow.Cells)
                            //    {
                            //        pdftable.AddCell(dgwCell.Value.ToString());
                            //    }
                            //}
                            foreach (DataGridViewRow viewRow in dataGridView1.Rows)
                            {
                                foreach (DataGridViewCell dgwCell in viewRow.Cells)
                                {
                                    if (dgwCell.Value != null) 
                                    {
                                        pdftable.AddCell(dgwCell.Value.ToString());
                                    }
                                    else
                                    {
                                        pdftable.AddCell("");
                                    }
                                }
                            }

                            using (FileStream filestream =new FileStream(save.FileName,FileMode.Create))
                            {
                                using(Document document= new Document(PageSize.A4,8f,16f,16f,8f)) 
                                {
                                    PdfWriter.GetInstance(document, filestream);
                                    document.Open();
                                    document.Add(pdftable);
                                    document.Close();   
                                }
                                filestream.Close();
                            }
                            MessageBox.Show("Sözleşmeniz PDF formatında kaydedilmiştir.", "Bilgilendirme",MessageBoxButtons.OK, MessageBoxIcon.Information);
                            
                        }
                        
                        catch (Exception ex)
                        {
                            MessageBox.Show("PDF formatına çevrilirken bir hata oluştu.", "Hata" + ex.Message);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Kayıt bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

      
    }
}
