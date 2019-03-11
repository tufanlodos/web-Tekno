using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeknoDAL.Context;

namespace TeknoBLL.Repositories
{
    public class UrunRepository
    {
        TeknoContext ent = new TeknoContext();
        public List<Urun> UrunListele()
        {
            return ent.Urunler.Where(m => m.Silindi == false).ToList();
        }
        public List<Urun> KategoriyeGoreUrunListele(int KategoriId)
        {
            return ent.Urunler.Where(m => m.Silindi == false && m.KategoriId==KategoriId).ToList();
        }
        public List<Urun> KategoriVeAltKategoriyeGoreUrunListele(int KategoriId, int AltKategoriId)
        {
            return ent.Urunler.Where(m => m.Silindi == false && m.KategoriId==KategoriId && m.AltKategoriId==AltKategoriId).ToList();
        }
        public int KategoriIdBul(int UrunId)
        {
            return ent.Urunler.Where(u => u.Id == UrunId).Select(u => u.KategoriId).First();
        }
        public int AltKategoriIdBul(int UrunId)
        {
            return ent.Urunler.Where(u => u.Id == UrunId).Select(u => u.AltKategoriId).First();
        }
        public string UrunAdiBul(int UrunId)
        {
            return ent.Urunler.Where(u => u.Id == UrunId).Select(u => u.UrunAdi).First();
        }
        public bool UrunEkle(Urun u)
        {
            throw new NotImplementedException();
        }

        public bool UrunGuncelle()
        {
            throw new NotImplementedException();
        }

        public bool UrunSil(Urun u)
        {
            throw new NotImplementedException();
        }

        public bool UrunSil(int ID)
        {
            throw new NotImplementedException();
        }
    }
}
