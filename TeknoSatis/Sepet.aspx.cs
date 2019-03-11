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
    public partial class Sepet : System.Web.UI.Page
    {
        TeknoContext ent = new TeknoContext();
        UrunRepository repoUrun = new UrunRepository();
        cSepet spt = new cSepet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["sepet"] == null)
                {
                    Response.Redirect("Default.aspx");
                }
                else
                {
                    List<cSepet> sepet = (List<cSepet>)Session["sepet"];
                    foreach (cSepet Urun in sepet)
                    {
                        Urun.ResimYolu = ent.Urunler.Where(u => u.Id == Urun.UrunId).Select(u => u.ResimYolu0).First();
                    }
                    repSepet.DataSource = sepet;
                    repSepet.DataBind();
                }
            }
        }

        protected void btnTemizle_Click(object sender, EventArgs e)
        {
            Session["sepet"] = null;
            Session["toplamadet"] = null;
            Session["toplamtutar"] = null;
            Response.Redirect("Default.aspx");
        }

        protected void repSepet_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Urune")
            {
                int UrunId = Convert.ToInt32(e.CommandArgument);
                int KategoriId = repoUrun.KategoriIdBul(UrunId);
                int AltKategoriId = repoUrun.AltKategoriIdBul(UrunId);
                Response.Redirect("UrunDetay.aspx?KategoriId=" + KategoriId + "&AltKategoriId=" + AltKategoriId + "&UrunId=" + UrunId);
            }
            else if(e.CommandName == "sepettencikar")
            {
                int SepetId = Convert.ToInt32(e.CommandArgument);
                List<cSepet> sepet = (List<cSepet>)Session["sepet"];
                if (sepet.Count == 1)
                {
                    Session["sepet"] = null;
                    Session["toplamadet"] = null;
                    Session["toplamtutar"] = null;
                    Response.Redirect("Default.aspx");
                }
                cSepet cikar = sepet.Where(s => s.SepetId == SepetId).First();
                sepet.Remove(cikar);
                Session["sepet"] = sepet;
                Session["toplamadet"] = spt.ToplamAdet(sepet);
                Session["toplamtutar"] = spt.ToplamTutar(sepet);
                Response.Redirect("Sepet.aspx");
            }
            else if (e.CommandName == "Azalt")
            {
                int SepetId = Convert.ToInt32(e.CommandArgument);
                List<cSepet> sepet = (List<cSepet>)Session["sepet"];
                cSepet guncellenecek = sepet.Where(s => s.SepetId == SepetId).First();
                if (guncellenecek.Adet > 1)
                {
                    guncellenecek.Adet--;
                    guncellenecek.Tutar = guncellenecek.Adet * guncellenecek.BirimFiyat;
                    Session["sepet"] = sepet;
                    Session["toplamadet"] = spt.ToplamAdet(sepet);
                    Session["toplamtutar"] = spt.ToplamTutar(sepet);
                    Response.Redirect("Sepet.aspx");
                }
                else
                {
                    Button Azalt = e.Item.FindControl("Azalt") as Button;
                    Azalt.Enabled = false;
                }
            }
            else if (e.CommandName == "Arttir")
            {
                int SepetId = Convert.ToInt32(e.CommandArgument);
                List<cSepet> sepet = (List<cSepet>)Session["sepet"];
                cSepet guncellenecek = sepet.Where(sp => sp.SepetId == SepetId).First();
                int UrunId = guncellenecek.UrunId;
                int StokMiktari = ent.Urunler.Where(u => u.Id == UrunId).Select(u => u.Miktar).First();
                if (StokMiktari-(guncellenecek.Adet+1) >= 0)
                {
                    guncellenecek.Adet++;
                    guncellenecek.Tutar = guncellenecek.Adet * guncellenecek.BirimFiyat;
                    Session["sepet"] = sepet;
                    Session["toplamadet"] = spt.ToplamAdet(sepet);
                    Session["toplamtutar"] = spt.ToplamTutar(sepet);
                    Response.Redirect("Sepet.aspx");
                }
                else
                {
                    Button Arttır = e.Item.FindControl("Arttir") as Button;
                    Arttır.Enabled = false;
                }
                
            }
        }
    }
}