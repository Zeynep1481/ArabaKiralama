using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static iTextSharp.awt.geom.Point2D;

namespace ArabaKirala
{
    public partial class frmAdmincs : Form
    {
        public frmAdmincs()
        {
            InitializeComponent();
        }

        private void frmAdmincs_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmMüşteriListele listele = new frmMüşteriListele();
            listele.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmArabaKayıt kayıt = new frmArabaKayıt();
            kayıt.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmArabaListele listele = new frmArabaListele();
            listele.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmSözleşme sözleşme = new frmSözleşme();
            sözleşme.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frmSatış satıs = new frmSatış();
            satıs.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            frmYedekle yedekle = new frmYedekle();
            yedekle.ShowDialog();
        }

        private void btnimport_Click(object sender, EventArgs e)
        {
            frmImport frmImport = new frmImport();
            frmImport.ShowDialog();
        }

    }    
}
