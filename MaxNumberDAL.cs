using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArabaKirala
{
    public class MaxNumberDAL
    {
        string connectionstring = @"Data Source=DESKTOP-6P4VD2O\\SQLEXPRESS;Initial Catalog=A_Kiralama;Integrated Security=True";

        //string connectionstring =ConfigurationManager.ConnectionStrings["A_Kiralama"].ConnectionString;

        #region DataBase Backup
        public bool DatabaseBackup(string yol)
        {
            bool olduMu=false;
            SqlConnection conn = new SqlConnection(connectionstring);
            conn.Open();
            string dbName=conn.Database.ToString();
            try
            {
                string sql = "BACKUP DATABASE [" + dbName + "] TO DISK =N'" + yol + "\\" + DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss") + " " + dbName + ".bak'";
            SqlCommand cmd = new SqlCommand(sql, conn);
                int result= cmd.ExecuteNonQuery();
                if (result==-1)
                {
                    olduMu = true;
                }
                else
                {
                    olduMu=false;
                }
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
                return olduMu;
        }
        #endregion
    }
}
