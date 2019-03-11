using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeknoDAL.Context
{
    [Table("AltKategoriler")]
    public class AltKategori
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string AltKategoriAdi { get; set; }
        public int? KategoriId { get; set; }
        public string Aciklama { get; set; }
        [Required]
        public bool Silindi { get; set; }

        //Relations
        [ForeignKey("KategoriId")]
        public virtual Kategori Kategorisi { get; set; }
        public virtual List<Urun> Urunler { get; set; }
        public AltKategori()
        {
            Silindi = false;
        }
    }
}
