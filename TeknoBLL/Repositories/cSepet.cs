using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeknoDAL.Context;

namespace TeknoBLL.Repositories
{
    public class cSepet
    {
        public int SepetId { get; set; }
        public int UrunId { get; set; }
        public string UrunAdi { get; set; }
        public int Adet { get; set; }
        public decimal BirimFiyat { get; set; }
        public decimal Tutar { get; set; }
        public string ResimYolu { get; set; }
        public List<cSepet> BosSepet()
        {
            return new List<cSepet>();
        }
        public cSepet() //sepet idlerini primary key gibi otomatik attırtmak için
        {
            SepetId = Genel.SepeteId++;
        }
        public int ToplamAdet(List<cSepet> sepet)
        {
            int Adet = 0;
            foreach (cSepet Urun in sepet)
            {
                Adet += Urun.Adet;
            }
            return Adet;
        }
        public decimal ToplamTutar(List<cSepet> sepet)
        {
            decimal Tutar = 0;
            foreach (cSepet Urun in sepet)
            {
                Tutar += Urun.Tutar;
            }
            return Tutar;
        }
        //kaç adet ürün var, sepet tutarı ne kadar metotları
    }
}
