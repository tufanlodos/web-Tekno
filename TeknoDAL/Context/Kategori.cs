using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeknoDAL.Context
{
    [Table("Kategoriler")]
    public class Kategori
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string KategoriAdi { get; set; }
        public string Aciklama { get; set; }
        [Required]
        public bool Silindi { get; set; }
        
        //Relations
        public virtual List<AltKategori> AltKategoriler { get; set; }
        public virtual List<Urun> Urunler { get; set; }
        public Kategori()
        {
            Silindi = false;
        }

    }
}
