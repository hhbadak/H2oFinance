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
    public partial class NftEkle : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        NFT nft = new NFT();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbtn_ekle_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_isim.Text.Trim()))
            {
                if (!string.IsNullOrEmpty(tb_fiyat.Text.Trim()))
                {
                    if (dm.nftKontrol(tb_isim.Text.Trim()))
                    {
                        nft.isim = tb_isim.Text;
                        nft.fiyat = Convert.ToDecimal(tb_fiyat.Text);
                    }
                    else
                    {
                        pnl_basarili.Visible = false;
                        pnl_basarisiz.Visible = true;
                        lbl_mesaj.Text = "NFT Piyasada Mevcut";
                    }
                    if (fu_resim.HasFile)
                    {
                        FileInfo fi = new FileInfo(fu_resim.FileName);
                        if (fi.Extension == ".jpg" || fi.Extension == ".png")
                        {
                            string uzanti = fi.Extension;
                            string isim = Guid.NewGuid().ToString();
                            nft.resim = isim + uzanti;
                            fu_resim.SaveAs(Server.MapPath("~/AdminPanel/Images/NftCoinImage/" + isim + uzanti));
                            if (dm.nftEkle(nft))
                            {
                                pnl_basarili.Visible = true;
                                pnl_basarisiz.Visible = false;
                                tb_fiyat.Text = tb_isim.Text = "";
                            }
                            else
                            {
                                pnl_basarili.Visible = false;
                                pnl_basarisiz.Visible = true;
                                lbl_mesaj.Text = "NFT Eklenirken Bir Hata Oluştu";
                            }
                            if (dm.nftEkle(nft))
                            {
                                pnl_basarili.Visible = true;
                                pnl_basarisiz.Visible = false;
                                tb_isim.Text = tb_fiyat.Text = "";
                            }
                            else
                            {
                                pnl_basarili.Visible = false;
                                pnl_basarisiz.Visible = true;
                                lbl_mesaj.Text = "NFT Ekleme Başarısız";
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
                else
                {
                    pnl_basarisiz.Visible = true;
                    pnl_basarili.Visible = false;
                    lbl_mesaj.Text = "Fiyat Alanı Boş Olamaz";
                }
            }
            else
            {
                pnl_basarisiz.Visible = true;
                pnl_basarili.Visible = false;
                lbl_mesaj.Text = "NFT Alanları Boş Olamaz";
            }
        }
    }
}