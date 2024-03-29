using Microsoft.SqlServer.Management.Assessment;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace ArabaKirala
{
    public partial class frmYedekle : Form
    { MaxNumberDAL maxnodal = new MaxNumberDAL();
        public frmYedekle()
        {
            InitializeComponent();
        }

        private void btnSec_Click(object sender, EventArgs e)
        {
            //saveFileDialog1.Title = "Yedeklenecek yolu belirtiniz.";
            //saveFileDialog1.Filter = "Yedekleme dosyaları (*.bak| *.bak | Tüm Dosyalar(*.*)| *.*)";
            //if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            //{
            //    txtPath.Text=saveFileDialog1.FileName;
            //}
            FolderBrowserDialog fd = new FolderBrowserDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = fd.SelectedPath;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //    Server dbserver = new Server(new ServerConnection(txtServer.Text));
            //    Backup dbBackup =new Backup();
            //    dbBackup.Action = BackupActionType.Database;
            //    dbBackup.Database = txtDatabase.Text;
            //    dbBackup.Devices.AddDevice(txtPath.Text, DeviceType.File);
            //    dbBackup.Initialize = false;

            //    dbBackup.Complete += DbBackup_Complete;
            //    dbBackup.SqlBackup(dbserver);
            if (txtPath.Text != string.Empty)
            {
                string path = txtPath.Text;
                bool success = maxnodal.DatabaseBackup(path);
                if (success == true)
                {
                    MessageBox.Show("Yedekleme işlemi başarılı bir şekilde gerçekleşti.");
                }
                else
                {
                    MessageBox.Show("Yedekleme işlemi başarısız ");
                }


            }
            else
            {
                MessageBox.Show("Lütfen yedekleme yolunu seçiniz", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            //private void DbBackup_Complete(object sender, ServerMessageEventArgs e)
            //{
            //    try
            //    {
            //        MessageBox.Show("Yedekleme işlemi başarılı bir şekilde gerçekleşti.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //    catch (Exception ex)
            //    {

            //        MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}

        }

        private void frmYedekle_Load(object sender, EventArgs e)
        {

        }
    }
}
