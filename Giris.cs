using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArabaKirala
{
    public class Giris
    {
        public SqlDataReader Giris2(string tc,string sifre)
        {
            SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-6P4VD2O\\SQLEXPRESS;Initial Catalog=A_Kiralama;Integrated Security=True");
            
            baglanti.Open();
            SqlCommand komut=new SqlCommand("Select * from musteri where M_tc=@tc and M_Sifre=@sifre",baglanti);
            komut.Parameters.AddWithValue("@tc", tc);
            komut.Parameters.AddWithValue("@sifre", sifre);
            SqlDataReader oku=komut.ExecuteReader();
            
            return oku;


        }
    }
}
