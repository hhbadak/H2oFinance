using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace H2oFinance.AdminPanel
{
    public partial class KriptoDuzenle : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Count != 0)
            {
                if (!IsPostBack)
                {
                    int id = Convert.ToInt32(Request.QueryString["mid"]);
                    dm.coinListele();
                    Coinler c = dm.kriptoGetir(id);
                    tb_coinAdi.Text = c.Isim;
                    tb_coinKisaltma.Text = c.CoinNick;
                    tb_mArz.Text = c.Max_Arz.ToString();
                }

            }
            else
            {
                Response.Redirect("KriptoListele.aspx");
            }
        }

        protected void lbtn_duzenle_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["mid"]);
            Coinler c = dm.kriptoGetir(id);
            c.Isim = tb_coinAdi.Text;
            c.CoinNick = tb_coinKisaltma.Text;
            c.Max_Arz = Convert.ToInt32(tb_mArz.Text);
            if (fu_resim.HasFile)
            {
                FileInfo fi = new FileInfo(fu_resim.FileName);
                if (fi.Extension == ".jpg" || fi.Extension == ".png")
                {
                    string uzanti = fi.Extension;
                    string isim = Guid.NewGuid().ToString();
                    c.Resim = isim + uzanti;
                    fu_resim.SaveAs(Server.MapPath("../Images/NftCoinImage/" + isim + uzanti));
                }
                else
                {
                    pnl_basarisiz.Visible = true;
                    pnl_basarili.Visible = false;
                    lbl_mesaj.Text = "Resim uzantısı sadece .jpg veya .png olmalıdır";
                }
            }
            if (dm.kriptoDuzenle(c))
            {
                pnl_basarisiz.Visible = false;
                pnl_basarili.Visible = true;
                tb_coinAdi.Text = tb_coinKisaltma.Text = tb_mArz.Text = "";
            }
            else
            {
                pnl_basarisiz.Visible = true;
                pnl_basarili.Visible = false;
                lbl_mesaj.Text = "Kripto Düzenleme Başarısız";
            }
        }

    }
}