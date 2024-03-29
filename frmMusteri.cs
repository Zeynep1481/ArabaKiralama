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
    public partial class frmMusteri : Form
    {
        Araba_Kiralama araba_kiralama = new Araba_Kiralama();
        public frmMusteri()
        {
            InitializeComponent();
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            string cumle = "insert into Musteri(M_tc,M_TelNo,M_Eposta,M_Ad,M_Soyad,M_Sifre,M_EhliyetSure,M_EhliyetT,M_Yas) values(@M_tc,@M_TelNo,@M_Eposta,@M_Ad,@M_Soyad,@M_Sifre,@M_EhliyetSure,@M_EhliyetT,@M_Yas)";
            SqlCommand komut2 = new SqlCommand();
            komut2.Parameters.AddWithValue("@M_tc", txtTc.Text);
            komut2.Parameters.AddWithValue("@M_TelNo", txtTelNo.Text);
            komut2.Parameters.AddWithValue("@M_Eposta", txteposta.Text);
            komut2.Parameters.AddWithValue("@M_Ad", txtisim.Text);
            komut2.Parameters.AddWithValue("@M_Soyad", txtsoyisim.Text);
            komut2.Parameters.AddWithValue("@M_Sifre", txtsifre.Text);
            komut2.Parameters.AddWithValue("@M_EhliyetSure", txtEsure.Text);
            komut2.Parameters.AddWithValue("@M_EhliyetT", txtEtip.Text);
            komut2.Parameters.AddWithValue("@M_Yas", txtyas.Text);
            araba_kiralama.ekle_sil_guncelle(komut2, cumle);
            foreach (Control item in Controls) if (item is TextBox) item.Text = "";
            Form2 gor = new Form2();
            gor.ShowDialog();

        }

        private void frmMusteri_Load(object sender, EventArgs e)
        {

        }

        
    }
}
