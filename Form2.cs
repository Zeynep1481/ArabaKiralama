using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArabaKirala
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            frmMüşteriListele Listele = new frmMüşteriListele();
            Listele.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmArabaKayıt kayıt = new frmArabaKayıt();
            kayıt.ShowDialog();


        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmMusteriArabaListele listele = new frmMusteriArabaListele();
            listele.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frmMusteriSözlesmecs sözleşme = new frmMusteriSözlesmecs();
            sözleşme.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            frmSatış satış= new frmSatış(); 
            satış.ShowDialog();

        }
    }
}
