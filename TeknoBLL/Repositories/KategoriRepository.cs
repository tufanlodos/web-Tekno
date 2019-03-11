using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeknoDAL.Context;

namespace TeknoBLL.Repositories
{
    public class KategoriRepository 
    {
        TeknoContext ent = new TeknoContext();
        public bool KategoriEkle(Kategori m)
        {
            throw new NotImplementedException();
        }
        public string KategoriAdiBul(int KategoriId)
        {
            return ent.Kategoriler.Where(k => k.Id == KategoriId).Select(k=>k.KategoriAdi).First();
        }
        public bool KategoriGuncelle()
        {
            throw new NotImplementedException();
        }

        public List<Kategori> KategoriListele()
        {
            return ent.Kategoriler.Where(m=>m.Silindi==false).ToList();
        }

        public bool KategoriSil(Kategori m)
        {
            throw new NotImplementedException();
        }

        public bool KategoriSil(int ID)
        {
            throw new NotImplementedException();
        }
    }
}
