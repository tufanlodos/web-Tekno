using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeknoDAL.Context;

namespace TeknoBLL.Repositories
{
    public class AltKategoriRepository
    {
        TeknoContext ent = new TeknoContext();
        public bool AltKategoriEkle(AltKategori m)
        {
            throw new NotImplementedException();
        }
        public string AltKategoriAdiBul(int AltKategoriId)
        {
            return ent.AltKategoriler.Where(k => k.Id == AltKategoriId).Select(k => k.AltKategoriAdi).First();
        }
        public bool AltKategoriGuncelle()
        {
            throw new NotImplementedException();
        }

        public List<AltKategori> AltKategoriListele()
        {
            return ent.AltKategoriler.Where(m => m.Silindi == false).ToList();
        }

        public bool AltKategoriSil(AltKategori m)
        {
            throw new NotImplementedException();
        }

        public bool AltKategoriSil(int ID)
        {
            throw new NotImplementedException();
        }
    }
}
