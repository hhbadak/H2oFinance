using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace H2oFinance.AdminPanel
{
    public partial class BakiyeOnay : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbtn_onayBekleyen_Click(object sender, EventArgs e)
        {
            lv_onaylanmis.Visible = false;
            lv_talep.Visible = true;
            lv_reddedilmis.Visible = false;
            lv_talep.DataSource = dm.TalepListele(1);
            lv_talep.DataBind();
        }

        protected void lbtn_onaylanan_Click(object sender, EventArgs e)
        {
            lv_onaylanmis.Visible = true;
            lv_talep.Visible = false;
            lv_reddedilmis.Visible = false;
            lv_onaylanmis.DataSource = dm.TalepListele(2);
            lv_onaylanmis.DataBind();
        }

        protected void lbtn_reddedilen_Click(object sender, EventArgs e)
        {
            lv_onaylanmis.Visible = false;
            lv_talep.Visible = false;
            lv_reddedilmis.Visible = true;
            lv_onaylanmis.DataSource = dm.TalepListele(3);
            lv_onaylanmis.DataBind();
        }

        protected void lv_talep_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            Talepler t = new Talepler();
            Yoneticiler y = (Yoneticiler)Session["yonetici"];
            if (e.CommandName == "onayla")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                t = dm.talepGetir(id);
                t.Yonetici_ID = y.ID;
                t.Onay_Tarihi = DateTime.Now;
                dm.talepUpdate(t);
                if (dm.bakiyeOnay(t))
                {
                    lv_talep.DataSource = dm.TalepListele(1);
                    lv_talep.DataBind();
                }

            }
            if (e.CommandName == "reddet")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                t = dm.talepGetir(id);
                t.Yonetici_ID = y.ID;
                t.Onay_Tarihi = DateTime.Now;
                dm.talepUpdate(t);
                if (dm.bakiyeRed(id))
                {
                    lv_talep.DataSource = dm.TalepListele(1);
                    lv_talep.DataBind();
                }
            }
        }
    }
}