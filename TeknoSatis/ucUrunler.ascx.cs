using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TeknoBLL.Repositories;
using TeknoDAL.Context;

namespace TeknoSatis
{
    public partial class ucUrunler : System.Web.UI.UserControl
    {
        UrunRepository repoUrun = new UrunRepository();
        cSepet spt = new cSepet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string KategoriId = Request.QueryString["KategoriId"];
                string AltKategoriID = Request.QueryString["AltKategoriId"];
                if (string.IsNullOrEmpty(KategoriId) && string.IsNullOrEmpty(AltKategoriID))
                {
                    List <Urun> Urunler = repoUrun.UrunListele();
                    dlstUrunler.DataSource = Urunler;
                }
                else if (AltKategoriID=="0")
                {
                    int kategoriId = Convert.ToInt32(KategoriId);
                    List<Urun> Urunler = repoUrun.KategoriyeGoreUrunListele(kategoriId);
                    dlstUrunler.DataSource = Urunler;
                }
                else
                {
                    int kategoriId = Convert.ToInt32(KategoriId);
                    int AltKategoriId = Convert.ToInt32(AltKategoriID);
                    List<Urun> Urunler = repoUrun.KategoriVeAltKategoriyeGoreUrunListele(kategoriId,AltKategoriId);
                    dlstUrunler.DataSource = Urunler;
                }
                dlstUrunler.DataBind();
            }
        }

        protected void dlstUrunler_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "sepet")
            {
                if (Session["sepet"] == null)
                {
                    Session["sepet"] = spt.BosSepet();
                }
                List<cSepet> sepet = (List<cSepet>)Session["sepet"];
                cSepet yeni = new cSepet();
                yeni.UrunId = Convert.ToInt32(e.CommandArgument);
                Label Fiyat = (Label)e.Item.FindControl("lblFiyat");
                TextBox Adet = (TextBox)e.Item.FindControl("txtAdet");
                yeni.UrunAdi = repoUrun.UrunAdiBul(yeni.UrunId);
                yeni.Adet = Convert.ToInt32(Adet.Text);
                yeni.BirimFiyat = Convert.ToDecimal(Fiyat.Text);
                yeni.Tutar = yeni.Adet * yeni.BirimFiyat;
                bool Varmi = false;
                foreach (cSepet mevcut in sepet)
                {
                    if (mevcut.UrunId == yeni.UrunId)
                    {
                        Varmi = true;
                        mevcut.Adet += yeni.Adet;
                        mevcut.Tutar += yeni.Tutar;
                        break;
                    }
                }
                if (!Varmi)
                {
                    sepet.Add(yeni);
                }
                Session["sepet"] = sepet;
                Session["toplamadet"] = spt.ToplamAdet(sepet);
                Session["toplamtutar"] = spt.ToplamTutar(sepet);
            }
            else if (e.CommandName == "UrunId")
            {
                int UrunIdsi = Convert.ToInt32(e.CommandArgument);
                int KategoriId = (int)repoUrun.KategoriIdBul(UrunIdsi);
                int AltKategoriId = (int)repoUrun.AltKategoriIdBul(UrunIdsi);
                Response.Redirect("UrunDetay.aspx?KategoriId=" + KategoriId + "&AltKategoriId=" + AltKategoriId + "&UrunId=" + UrunIdsi);
            }
             
        }
    }
}