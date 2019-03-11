using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeknoDAL.Context
{
    [Table("Kullanıcılar")]
    public class Kullanici
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string KullaniciAdi { get; set; }
        [MaxLength(8),MinLength(8)]
        public string Sifre { get; set; }
        [Required]
        public bool Admin { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        [MaxLength(11),MinLength(11)]
        public string TCKimlikNo { get; set; }
        public string Telefon { get; set; }
        public string Adres { get; set; }
        [Required]
        public bool Silindi { get; set; }
        public Kullanici()
        {
            Silindi = false;
            Admin = false;
        }
        //Relations
    }
}
