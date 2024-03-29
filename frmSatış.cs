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
    public partial class frmSatış : Form
    {
        public frmSatış()
        {
            InitializeComponent();
        }
        Araba_Kiralama araba = new Araba_Kiralama();

        private void frmSatış_Load(object sender, EventArgs e)
        {
            string sorgu2 = "select *from satış";
            SqlDataAdapter adtr2 = new SqlDataAdapter();
            dataGridView1.DataSource = araba.listele(adtr2,sorgu2);
            araba.satışhesapla(label1);

        }
    }
}
