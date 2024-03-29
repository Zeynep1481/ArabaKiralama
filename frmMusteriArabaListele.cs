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
    public partial class frmMusteriArabaListele : Form
    {
        Araba_Kiralama arabakiralama = new Araba_Kiralama();
        public frmMusteriArabaListele()
        {
            InitializeComponent();
        }
        private void frmMusteriArabaListele_Load(object sender, EventArgs e)
        {
            YenileArabalarListesi();

            comboAraçlar.SelectedIndex = 0;
        }
        private void YenileArabalarListesi()
        {
            string cümle = "select*from araba";
            SqlDataAdapter adtr2 = new SqlDataAdapter();
            dataGridView1.DataSource = arabakiralama.listele(adtr2, cümle);
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satır = dataGridView1.CurrentRow;
            pictureBox2.ImageLocation = satır.Cells["resim"].Value.ToString();
        }

        private void comboAraçlar_SelectedIndexChanged(object sender, EventArgs e)
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
    }
       
    
}
