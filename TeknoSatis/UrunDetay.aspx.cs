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
    public partial class UrunDetay : System.Web.UI.Page
    {
        TeknoContext ent = new TeknoContext();
        KategoriRepository repoKate = new KategoriRepository();
        AltKategoriRepository repoAltKate = new AltKategoriRepository();
        UrunRepository repoUrun = new UrunRepository();
        cSepet spt = new cSepet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                int KategoriId =Convert.ToInt32(Request.QueryString["KategoriId"]);
                int AltKategoriId = Convert.ToInt32(Request.QueryString["AltKategoriId"]);
                int UrunId = Convert.ToInt32(Request.QueryString["UrunId"]);
                TelefonUrunDetay tel = new TelefonUrunDetay();
                Urun urn = ent.Urunler.Where(u => u.Id == UrunId && u.KategoriId == KategoriId && u.AltKategoriId == AltKategoriId).FirstOrDefault();
                tel.Id = UrunId;
                tel.UrunAdi = urn.UrunAdi;
                tel.KategoriAdi = repoKate.KategoriAdiBul(urn.KategoriId);
                tel.AltKategoriAdi = repoAltKate.AltKategoriAdiBul(urn.AltKategoriId);
                tel.Miktar = urn.Miktar;
                tel.Fiyat = urn.Fiyat;
                tel.ResimYolu0 = urn.ResimYolu0;
                string[] Ozellikler = urn.UrunBilgisi.Split('$');
                tel.UrunRenk = Ozellikler[0];
                tel.UrunHafiza = Ozellikler[1];
                tel.Ram = Ozellikler[2];
                tel.EkranBoyut = Ozellikler[3];
                tel.Kamera = Ozellikler[4];
                tel.Pil = Ozellikler[5];
                List<TelefonUrunDetay> telef = new List<TelefonUrunDetay>();
                telef.Add(tel);
                Repeater1.DataSource = telef;
                Repeater1.DataBind();
            }
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
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
                TextBox Adet = (TextBox)e.Item.FindControl("txtAdet");
                Label Fiyat = (Label)e.Item.FindControl("lblFiyat");
                yeni.Adet = Convert.ToInt32(Adet.Text);
                yeni.UrunAdi = repoUrun.UrunAdiBul(yeni.UrunId);
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
            else if(e.CommandName == "Kate")
            {
                int UrunId = Convert.ToInt32(e.CommandArgument);
                int KategoriId = repoUrun.KategoriIdBul(UrunId);
                int AltKategoriId = 0;
                Response.Redirect("Default.aspx?KategoriId=" + KategoriId + "&AltKategoriId=" + AltKategoriId);
            }
            else if(e.CommandName == "AltKate")
            {
                int UrunId = Convert.ToInt32(e.CommandArgument);
                int KategoriId = repoUrun.KategoriIdBul(UrunId);
                int AltKategoriId = repoUrun.AltKategoriIdBul(UrunId);
                Response.Redirect("Default.aspx?KategoriId=" + KategoriId + "&AltKategoriId=" + AltKategoriId);
            }
        }
    }
}