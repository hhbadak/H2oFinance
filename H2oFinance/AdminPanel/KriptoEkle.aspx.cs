using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace H2oFinance.AdminPanel
{
    public partial class KriptoEkle : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbtn_ekle_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_isim.Text.Trim()))
            {
                if (dm.coinKontrol(tb_isim.Text.Trim()))
                {
                    Coinler coin = new Coinler();
                    coin.isim = tb_isim.Text;
                    coin.coinNick = tb_nick.Text;
                    coin.maxArz = Convert.ToInt32(tb_arz.Text);
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
                }
                else
                {
                    pnl_basarili.Visible = false;
                    pnl_basarisiz.Visible = true;
                    lbl_mesaj.Text = "Kripto Para Piyasada Mevcut";
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