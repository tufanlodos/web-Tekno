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
    public partial class Satis : System.Web.UI.MasterPage
    {
        KategoriRepository repoKategori = new KategoriRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                foreach (Kategori Kategori in repoKategori.KategoriListele())
                {
                    MenuItem mitm = new MenuItem();
                    mitm.Text = Kategori.KategoriAdi;
                    mitm.Value = Kategori.Id.ToString();
                    mnuKategoriler.Items.Add(mitm);
                    foreach (AltKategori AltKategori in Kategori.AltKategoriler)
                    {
                        MenuItem citm = new MenuItem();
                        citm.Text = AltKategori.AltKategoriAdi;
                        citm.Value = AltKategori.Id.ToString();
                        mitm.ChildItems.Add(citm);
                    }
                }
            }
        }

        protected void mnuKategoriler_MenuItemClick(object sender, MenuEventArgs e)
        {
            string[] Idler = e.Item.ValuePath.Split('/');
            string KategoriId = Idler[0];
            string AltKategoriId = "0";
            if (Idler.Length > 1)
            {
                AltKategoriId = Idler[1];
            }
            Response.Redirect("Default.aspx?KategoriId=" + KategoriId + "&AltKategoriId=" + AltKategoriId);

        }
    }
}