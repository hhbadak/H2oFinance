using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace H2oFinance.AdminPanel
{
    public partial class KriptoEkle : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        Coinler coin = new Coinler();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbtn_ekle_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_isim.Text.Trim()))
            {
                if (!string.IsNullOrEmpty(tb_nick.Text.Trim()))
                {
                    if (!string.IsNullOrEmpty(tb_arz.Text.Trim()))
                    {
                        if (!string.IsNullOrEmpty(tb_fiyat.Text.Trim()))
                        {
                            if (dm.coinKontrol(tb_isim.Text.Trim()))
                            {
                                coin.Isim = tb_isim.Text;
                                coin.CoinNick = tb_nick.Text;
                                coin.Max_Arz = Convert.ToInt32(tb_arz.Text);
                                coin.Fiyat = Convert.ToDecimal(tb_fiyat.Text);
                            }
                            else
                            {
                                pnl_basarili.Visible = false;
                                pnl_basarisiz.Visible = true;
                                lbl_mesaj.Text = "Kripto Para Piyasada Mevcut";
                            }
                            if (fu_resim.HasFile)
                            {
                                FileInfo fi = new FileInfo(fu_resim.FileName);
                                if (fi.Extension == ".jpg" || fi.Extension == ".png")
                                {
                                    string uzanti = fi.Extension;
                                    string isim = Guid.NewGuid().ToString();
                                    coin.Resim = isim + uzanti;
                                    fu_resim.SaveAs(Server.MapPath("~/AdminPanel/Images/NftCoinImage/" + isim + uzanti));
                                    if (dm.coinEkle(coin))
                                    {
                                        pnl_basarili.Visible = true;
                                        pnl_basarisiz.Visible = false;
                                        tb_isim.Text = "";
                                        tb_nick.Text = "";
                                        tb_arz.Text = "";
                                    }
                                    else
                                    {
                                        pnl_basarili.Visible = false;
                                        pnl_basarisiz.Visible = true;
                                        lbl_mesaj.Text = "Kripto Eklenirken Bir Hata Oluştu";
                                    }
                                    if (dm.coinEkle(coin))
                                    {
                                        pnl_basarisiz.Visible = false;
                                        pnl_basarili.Visible = true;
                                        tb_isim.Text = tb_nick.Text = tb_arz.Text = "";
                                    }
                                    else
                                    {
                                        pnl_basarili.Visible = false;
                                        pnl_basarisiz.Visible = true;
                                        lbl_mesaj.Text = "Coin Ekleme Başarısız";
                                    }
                                }
                                else
                                {
                                    pnl_basarisiz.Visible = true;
                                    pnl_basarili.Visible = false;
                                    lbl_mesaj.Text = "Resim uzantısı sadece .jpg veya .png olmalıdır";
                                }
                            }
                            else
                            {
                                pnl_basarisiz.Visible = true;
                                pnl_basarili.Visible = false;
                                lbl_mesaj.Text = "Resim Eklemeniz Gerekmektedir";
                            }
                        }
                    }
                    else
                    {
                        pnl_basarili.Visible = false;
                        pnl_basarisiz.Visible = true;
                        lbl_mesaj.Text = "Max Arz Boş Olamaz";
                    }
                }
                else
                {
                    pnl_basarili.Visible = false;
                    pnl_basarisiz.Visible = true;
                    lbl_mesaj.Text = "Kripto Kısaltması Boş Olamaz";
                }
            }
            else
            {
                pnl_basarili.Visible = false;
                pnl_basarisiz.Visible = true;
                lbl_mesaj.Text = "Kripto Alanları Boş Olamaz";
            }
        }
    }
}