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
    public partial class frmMüşteriListele : Form
    {
        Araba_Kiralama arabakiralama = new Araba_Kiralama();
        public frmMüşteriListele()
        {
            InitializeComponent();
        }

        private void frmMüşteriListele_Load(object sender, EventArgs e)
        {
            Yenilelistele();
        }
        private void Yenilelistele()
        {
            string cümle = " select * from musteri ";
            SqlDataAdapter adtr2 = new SqlDataAdapter();

            dataGridView1.DataSource = arabakiralama.listele(adtr2, cümle);
            dataGridView1.Columns[0].HeaderText = "TC No";
            dataGridView1.Columns[1].HeaderText = "Telefon Numarası";
            dataGridView1.Columns[2].HeaderText = "E-posta Adresi";
            dataGridView1.Columns[3].HeaderText = "İsim";
            dataGridView1.Columns[4].HeaderText = "Soyisim";
            //dataGridView1.Columns[5].HeaderText = "Şifre";
            dataGridView1.Columns[6].HeaderText = "Ehliyet Süresi";
            dataGridView1.Columns[7].HeaderText = "Ehliyet Tipi";
            dataGridView1.Columns[8].HeaderText = "Yaş";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string cümle = " select * from musteri where M_tc like '%" + textBox1.Text + "%'";
            SqlDataAdapter adtr2 = new SqlDataAdapter();

            dataGridView1.DataSource = arabakiralama.listele(adtr2, cümle);
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satır = dataGridView1.CurrentRow;
            txtTc.Text = satır.Cells[0].Value.ToString();
            txtTelNo.Text = satır.Cells[1].Value.ToString();
            txtisim.Text = satır.Cells[3].Value.ToString();
            txtsoyisim.Text = satır.Cells[4].Value.ToString();
            txtyas.Text = satır.Cells[8].Value.ToString();
            txteposta.Text = satır.Cells[2].Value.ToString();
            txtEtip.Text = satır.Cells[7].Value.ToString();
            txtEsure.Text = satır.Cells[6].Value.ToString();
            //txtsifre.Text = satır.Cells[5].Value.ToString();
        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            String cümle = " update musteri set M_TelNo=@M_TelNo,M_Eposta=@M_Eposta,M_Ad=@M_Ad,M_Soyad=@M_Soyad,M_EhliyetSure=@M_EhliyetSure,M_EhliyetT=@M_EhliyetT,M_Yas=@M_Yas where M_tc=@M_tc";
            SqlCommand komut2 = new SqlCommand();
            komut2.Parameters.AddWithValue("@M_tc", txtTc.Text);
            komut2.Parameters.AddWithValue("@M_TelNo", txtTelNo.Text);
            komut2.Parameters.AddWithValue("@M_Ad", txtisim.Text);
            komut2.Parameters.AddWithValue("@M_Soyad", txtsoyisim.Text);
            //komut2.Parameters.AddWithValue("@M_Sifre", txtsifre.Text);
            komut2.Parameters.AddWithValue("@M_EhliyetSure", txtEsure.Text);
            komut2.Parameters.AddWithValue("@M_EhliyetT", txtEtip.Text);
            komut2.Parameters.AddWithValue("@M_Yas", txtyas.Text);
            arabakiralama.ekle_sil_guncelle(komut2, cümle);
            foreach (Control item in Controls) if (item is TextBox) item.Text = "";
            Yenilelistele();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            DataGridViewRow satır = dataGridView1.CurrentRow;
            string cümle = "delete from musteri where M_tc='" + satır.Cells["M_tc"].Value.ToString() + "'";
            SqlCommand komut2 = new SqlCommand();
            arabakiralama.ekle_sil_guncelle(komut2, cümle);
            foreach (Control item in Controls) if (item is TextBox) item.Text = "";
            Yenilelistele();
        }
    }
}
