using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DataModel
    {
        SqlConnection con; SqlCommand cmd;

        public DataModel()
        {
            con = new SqlConnection(ConnectionStrings.H2Ocon);
            cmd = con.CreateCommand();
        }
        #region YONETICI METOTLARI
        public Yoneticiler YoneticiGiris(string mail, string sifre)
        {
            try
            {
                cmd.CommandText = "SELECT COUNT(*) FROM Yoneticiler WHERE Mail = @mail AND Sifre = @sifre";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@mail", mail);
                cmd.Parameters.AddWithValue("@sifre", sifre);
                con.Open();
                int sayi = Convert.ToInt32(cmd.ExecuteScalar());
                if (sayi > 0)
                {
                    cmd.CommandText = "SELECT ID,Isim,Soyisim,Mail,Sifre,Telefon FROM Yoneticiler WHERE Mail=@mail AND Sifre=@sifre";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@mail", mail);
                    cmd.Parameters.AddWithValue("@sifre", sifre);
                    SqlDataReader reader = cmd.ExecuteReader();
                    Yoneticiler y = new Yoneticiler();
                    while (reader.Read())
                    {
                        y.ID = reader.GetInt32(0);
                        y.isim = reader.GetString(1);
                        y.soyIsim = reader.GetString(2);
                        y.mail = reader.GetString(3);
                        y.sifre = reader.GetString(4);
                        y.telefon = reader.GetString(5);
                    }
                    return y;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
            finally { con.Close(); }
        }
        #endregion
        #region COIN METOTLARI
        public bool coinKontrol(string isim)
        {
            try
            {
                cmd.CommandText = "SELECT COUNT(*) FROM Coinler WHERE Isim = @isim";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@isim", isim);
                con.Open();
                int sayi = Convert.ToInt32(cmd.ExecuteScalar());
                if (sayi == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            finally { con.Close(); }
        }
        public bool coinEkle(Coinler coin)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Coinler(Isim,CoinNick,Max_Arz) VALUES(@isim,@coinNick,@maxArz)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@isim", coin.isim);
                cmd.Parameters.AddWithValue("@coinNick", coin.coinNick);
                cmd.Parameters.AddWithValue("@maxArz", coin.maxArz);
                con.Open();
                int sayi = Convert.ToInt32(cmd.ExecuteScalar());
                return true;
            }
            catch
            {
                return false;
            }
            finally { con.Close(); }
        }
        #endregion
    }
}
