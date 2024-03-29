using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ArabaKirala
{
    internal static class Program
    {
        /// <summary>
        /// Uygulamanın ana girdi noktası.
        /// </summary>
        [STAThread]
       static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmGirisSec());

            //            string currentdatetime = DateTime.Now.ToString("yyyyMMddHHmmss");
            //            string LogFolder = @"D:\Files\Logs";
            //            string connectionString = @"Server=DESKTOP-6P4VD2O\SQLEXPRESS;Initial Catalog=A_Kiralama;Integrated Security=True";
            //            string queryString = "select * from email";
            //            string filePath = @"C:\Users\YALÇINKAYA\Desktop\arabaexport.xls";

            //            try
            //            {
            //                if (File.Exists(filePath))
            //                    File.Delete(filePath);

            //                // Connect to the SQL Server database and retrieve the data you want to export
            //                using (SqlConnection baglanti = new SqlConnection(connectionString))
            //                {
            //                    baglanti.Open();
            //                    using (SqlCommand command = new SqlCommand(queryString, baglanti))
            //                    {
            //                        using (SqlDataReader reader = command.ExecuteReader())
            //                        {
            //                            // Create a new Excel application and workbook
            //                            Application excelApp = new Application();
            //                            Workbook excelWorkbook = excelApp.Workbooks.Add();
            //                            Worksheet excelWorksheet = excelWorkbook.Worksheets[1];

            //                            // Add the headers to the first row
            //                            int col = 1;
            //                            for (int i = 0; i < reader.FieldCount; i++)
            //                            {
            //                                excelWorksheet.Cells[1, col].Value2 = reader.GetName(i);
            //                                col++;
            //                            }

            //                            // Iterate through the rows of data and insert them into the worksheet, starting from the second row
            //                            int row = 2;
            //                            while (reader.Read())
            //                            {
            //                                col = 1;
            //                                for (int i = 0; i < reader.FieldCount; i++)
            //                                {
            //                                    excelWorksheet.Cells[row, col].Value2 = reader[i];
            //                                    col++;
            //                                }
            //                                row++;
            //                            }

            //                            // Save the workbook and close the Excel application
            //                            excelWorkbook.SaveAs(filePath);
            //                            excelWorkbook.Close();
            //                            excelApp.Quit();
            //                        }
            //                    }
            //                }

            //            }

            //            catch (Exception exception)
            //            {
            //                using (StreamWriter sw = File.CreateText(LogFolder + "\\" + "ErrorLog_" + currentdatetime + ".log"))
            //                {
            //                    sw.WriteLine(exception.ToString());
            //                }

            //            }
        }
    }
}
