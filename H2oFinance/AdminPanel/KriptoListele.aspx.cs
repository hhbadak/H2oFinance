using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace H2oFinance.AdminPanel
{
    public partial class KriptoListele : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            lv_coinList.DataSource = dm.coinListele();
            lv_coinList.DataBind();
        }

        protected void lv_coinList_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
        }
    }
}