using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArabaKirala
{
    public class Araba_Kiralama
    {
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-6P4VD2O\\SQLEXPRESS;Initial Catalog=A_Kiralama;Integrated Security=True");
        DataTable tablo;

        public void ekle_sil_guncelle(SqlCommand komut, string sorgu)
        {
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = sorgu;
            komut.ExecuteNonQuery();
            baglanti.Close();
        }
        public DataTable listele(SqlDataAdapter adtr, string sorgu)
        {
            tablo = new DataTable();
            adtr = new SqlDataAdapter(sorgu, baglanti);
            adtr.Fill(tablo);
            baglanti.Close();
            return tablo;
        }
        public void Bos_Arabalar(ComboBox combo,string sorgu)
        {
            baglanti.Open ();
            SqlCommand komut = new SqlCommand(sorgu,baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                combo.Items.Add(read["plaka"].ToString());
            }
            baglanti.Close ();
        }
        public void TC_Ara(TextBox tc, TextBox isim, TextBox soyisim, TextBox telefon,TextBox e_sure,TextBox E_tipi, TextBox Yas, string sorgu)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand(sorgu, baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                isim.Text = read["M_Ad"].ToString();
                soyisim.Text = read["M_Soyad"].ToString();
                telefon.Text = read["M_TelNo"].ToString();
                e_sure.Text = read["M_EhliyetSure"].ToString();
                E_tipi.Text = read["M_EhliyetT"].ToString();
                Yas.Text = read["M_Yas"].ToString();

            }
            baglanti.Close();
        }
        public void UcretHesapla(ComboBox combokiraşekli,TextBox ucret, string sorgu)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand(sorgu, baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                if (combokiraşekli.SelectedIndex == 0) ucret.Text = (int.Parse(read["g_fiyat"].ToString()) * 1).ToString();
                if (combokiraşekli.SelectedIndex == 1) ucret.Text = (int.Parse(read["g_fiyat"].ToString())*0.80).ToString();
                if (combokiraşekli.SelectedIndex == 2) ucret.Text = (int.Parse(read["g_fiyat"].ToString()) * 0.70).ToString();




            }
            baglanti.Close();
        }
        public void CombodanGetir(ComboBox arabalar,TextBox marka, TextBox seri, TextBox yil, TextBox V_tipi, string sorgu)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand(sorgu, baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                marka.Text = read["marka"].ToString();
                seri.Text = read["seri"].ToString();
                yil.Text = read["model"].ToString();
                V_tipi.Text = read["v_tipi"].ToString();


            }
            baglanti.Close();
        }
        public void satışhesapla( Label lbl)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select sum(tutar) from satış",baglanti);
            lbl.Text = "Toplam Tutar=" + komut.ExecuteScalar() + "TL";
            baglanti.Close() ;


        }
    }
}
