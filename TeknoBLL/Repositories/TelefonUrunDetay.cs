using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeknoBLL.Repositories
{
    public class TelefonUrunDetay
    {
        public int Id { get; set; }
        public string UrunAdi { get; set; }
        public string KategoriAdi { get; set; }
        public string AltKategoriAdi { get; set; }
        public int Miktar { get; set; }
        public decimal Fiyat { get; set; }
        public string ResimYolu0 { get; set; }
        public string ResimYolu1 { get; set; }
        public string UrunRenk { get; set; }
        public string UrunHafiza { get; set; }
        public string Ram { get; set; }
        public string EkranBoyut { get; set; }
        public string Kamera { get; set; }
        public string Pil { get; set; }
    }
}
