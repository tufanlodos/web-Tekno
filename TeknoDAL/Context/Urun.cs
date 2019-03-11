using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeknoDAL.Context
{
    [Table("Ürünler")]
    public class Urun
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string UrunAdi { get; set; }
        public int KategoriId { get; set; }
        public int AltKategoriId { get; set; }
        [Required]
        public int Miktar { get; set; }
        [Required]
        public decimal Fiyat { get; set; }
        [StringLength(100)]
        public string ResimYolu0 { get; set; }
        [StringLength(100)]
        public string ResimYolu1 { get; set; }
        public string UrunBilgisi { get; set; }
        [Required]
        public bool Silindi { get; set; }
       
        //relations
        [ForeignKey("KategoriId")]
        public virtual Kategori Kategorisi { get; set; }
        [ForeignKey("AltKategoriId")]
        public virtual AltKategori AltKategorisi { get; set; }
        public Urun()
        {
            Silindi = false;
            Miktar = 0;
            Fiyat = 0;
        }

    }
}
