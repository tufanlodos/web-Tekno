using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeknoDAL.Migrations;

namespace TeknoDAL.Context
{
    public class TeknoContext: DbContext
    {
        public TeknoContext() : base("TeknoContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TeknoContext, Configuration>("TeknoContext"));
        }
        public virtual DbSet<Kategori> Kategoriler { get; set; }
        public virtual DbSet<AltKategori> AltKategoriler { get; set; }
        public virtual DbSet<Urun> Urunler { get; set; }
        public virtual DbSet<Kullanici> Kullanicilar { get; set; }


    }
}
