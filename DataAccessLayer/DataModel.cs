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
                cmd.CommandText = "INSERT INTO Coinler(Isim,CoinNick,Max_Arz,Resim,Fiyat,Durum) VALUES(@isim,@coinNick,@maxArz,@resim,@fiyat,1)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@isim", coin.Isim);
                cmd.Parameters.AddWithValue("@coinNick", coin.CoinNick);
                cmd.Parameters.AddWithValue("@maxArz", coin.Max_Arz);
                cmd.Parameters.AddWithValue("@resim", coin.Resim);
                cmd.Parameters.AddWithValue("@fiyat", coin.Fiyat);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally { con.Close(); }
        }
        public bool coinSil(int id)
        {
            try
            {
                cmd.CommandText = "UPDATE Coinler SET Aktif=0 WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally { con.Close(); }
        }
        public List<Coinler> coinListele()
        {
            List<Coinler> coin = new List<Coinler>();
            try
            {
                cmd.CommandText = "SELECT ID,CoinNick,Isim,Max_Arz,Resim,Fiyat FROM Coinler WHERE Durum=1";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Coinler c = new Coinler();
                    c.ID = reader.GetInt32(0);
                    c.CoinNick = reader.GetString(1);
                    c.Isim = reader.GetString(2);
                    c.Max_Arz = reader.GetInt32(3);
                    c.Resim = !reader.IsDBNull(4) ? reader.GetString(4) : "none.png";
                    c.Fiyat = reader.GetDecimal(5);
                    coin.Add(c);
                }
                return coin;
            }
            catch
            {
                return null;
            }
            finally { con.Close(); }
        }
        public bool kriptoDuzenle(Coinler c)
        {
            try
            {
                cmd.CommandText = "UPDATE Coinler SET CoinNick = @cNick, Isim = @isim, Max_Arz = @mArz, Resim = @resim WHERE ID = @id ";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", c.ID);
                cmd.Parameters.AddWithValue("@isim", c.Isim);
                cmd.Parameters.AddWithValue("@cNick", c.CoinNick);
                cmd.Parameters.AddWithValue("@mArz", c.Max_Arz);
                cmd.Parameters.AddWithValue("@resim", c.Resim);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally { con.Close(); }
        }
        public Coinler kriptoGetir(int id)
        {
            try
            {
                cmd.CommandText = "SELECT Isim,CoinNick,Max_Arz,Resim FROM Coinler WHERE ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                Coinler c = new Coinler();
                while (reader.Read())
                {
                    c.Isim = reader.GetString(0);
                    c.CoinNick = reader.GetString(1);
                    c.Max_Arz = reader.GetInt32(2);
                    c.Resim = !reader.IsDBNull(3) ? reader.GetString(3) : "none.png";
                }
                return c;
            }
            catch
            {
                return null;
            }
            finally { con.Close(); }
        }
        #endregion
        #region NFT METOTLARI
        public bool nftKontrol(string isim)
        {
            try
            {
                cmd.CommandText = "SELECT COUNT(*) FROM NFT WHERE Isim = @isim";
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
        public bool nftEkle(NFT nft)
        {
            try
            {
                cmd.CommandText = "INSERT INTO NFT(Isim,Fiyat,Resim) VALUES(@isim,@fiyat,@resim)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@isim", nft.isim);
                cmd.Parameters.AddWithValue("@fiyat", nft.fiyat);
                cmd.Parameters.AddWithValue("@resim", nft.resim);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally { con.Close(); }
        }
        #endregion
        #region TALEP METOTLARI
        public List<Talepler> TalepListele(int d)
        {
            try
            {
                List<Talepler> list = new List<Talepler>();
                cmd.CommandText = "SELECT T.ID,T.Uye_ID,U.Isim,T.Yonetici_ID,Y.Isim,T.Miktar,T.Talep_Tarihi,T.Onay_Tarihi,T.Durum FROM Talepler AS T JOIN Uyeler AS U ON T.Uye_ID=U.ID JOIN Yoneticiler AS Y ON T.Yonetici_ID=Y.ID WHERE T.Durum=@durum";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@durum", d);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Talepler t = new Talepler();
                    t.ID = reader.GetInt32(0);
                    t.Uye_ID = reader.GetInt32(1);
                    t.Uye_Adi = reader.GetString(2);
                    t.Yonetici_ID = reader.GetInt32(3);
                    t.Yonetici_Adi = reader.GetString(4);
                    t.Miktar = reader.GetDecimal(5);
                    t.Talep_Tarihi = reader.GetDateTime(6);
                    t.Onay_Tarihi = !reader.IsDBNull(7) ? reader.GetDateTime(7) : reader.GetDateTime(6);
                    t.Durum = reader.GetByte(8);
                    list.Add(t);
                }
                return list;
            }
            catch
            {
                return null;
            }
            finally { con.Close(); }
        }

        public bool bakiyeOnay(Talepler t)
        {
            try
            {
                cmd.CommandText = "UPDATE Talepler SET Durum=2 WHERE ID=@id UPDATE Uyeler SET Bakiye=Bakiye+@miktar WHERE ID=@uyeID";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", t.ID);
                cmd.Parameters.AddWithValue("@miktar", t.Miktar);
                cmd.Parameters.AddWithValue("@uyeID", t.Uye_ID);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally { con.Close(); }
        }
        public Talepler talepGetir(int id)
        {
            Talepler t = new Talepler();
            try
            {
                cmd.CommandText = "SELECT T.ID,T.Uye_ID,U.Isim,T.Yonetici_ID,Y.Isim,T.Miktar,T.Talep_Tarihi,T.Onay_Tarihi,T.Durum FROM Talepler AS T JOIN Uyeler AS U ON T.Uye_ID=U.ID JOIN Yoneticiler AS Y ON T.Yonetici_ID=Y.ID WHERE T.ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    t.ID = reader.GetInt32(0);
                    t.Uye_ID = reader.GetInt32(1);
                    t.Uye_Adi = reader.GetString(2);
                    t.Yonetici_ID = reader.GetInt32(3);
                    t.Yonetici_Adi = reader.GetString(4);
                    t.Miktar = reader.GetDecimal(5);
                    t.Talep_Tarihi = reader.GetDateTime(6);
                    t.Onay_Tarihi = !reader.IsDBNull(7) ? reader.GetDateTime(7) : reader.GetDateTime(6);
                    t.Durum = reader.GetByte(8);

                }
                return t;
            }
            catch
            {

                return null;
            }
            finally { con.Close(); }
        }
        public void talepUpdate(Talepler t)
        {
            try
            {
                cmd.CommandText = "UPDATE Talepler SET Onay_Tarihi=@onay_tarihi, Yonetici_ID=@yid WHERE ID=@id ";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@onay_tarihi", t.Onay_Tarihi);
                cmd.Parameters.AddWithValue("@yid", t.Yonetici_ID);
                cmd.Parameters.AddWithValue("@id", t.ID);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            finally { con.Close(); }
        }
        public bool bakiyeRed(int id)
        {
            try
            {
                cmd.CommandText = "UPDATE Talepler Set Durum=3 WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
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
