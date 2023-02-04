using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace H2oFinance.AdminPanel
{
    public partial class CoinDelist : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            lv_coin.DataSource = dm.coinListele();
            lv_coin.DataBind();
        }

        protected void lv_coin_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            dm.coinSil(id);
            lv_coin.DataSource = dm.coinListele();
            lv_coin.DataBind();
        }
    }
}