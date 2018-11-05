namespace OgrenciTakip.Data.Context
{
    using Model.Entities;
    using OgrenciTakipMigration;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;

    public class OgrenciTakipContext : BaseDbContext<OgrenciTakipContext, Configuration>
    {
        public OgrenciTakipContext()
        {
            //Birbiriyle ili�kili tablolarda select i�lemlerinde ili�ki kay�tlar�n bilgilerinin gelmesini engelledik.True olursa o bilgilerde gelir.Buda sorgular�m�z�n yava� �al��mas�na sebep olur.
            Configuration.LazyLoadingEnabled = false;
        }

        public OgrenciTakipContext(string connectionString) : base(connectionString)
        {
            Configuration.LazyLoadingEnabled = false;
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Bu i�lem table isimlerini �o�ulla�t�r�r. Bizim Okul s�n�f�m�z� database e yollarken Okuls olarak yollar. O nedenle bunu devre d��� b�rak�oruz.
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //Bire �ok ili�kili tablolarda ona ba�l� verileri silmek i�in kullan�l�r.Ama biz devre d��� b�rak�oruz.��nk� b�t�n database �zerinde
            //ge�erli olucak o y�zden gerekti�i yerlerde costum olarak biz kendimiz yaz�caz.
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }

        public DbSet<Il> Il { get; set; }
        public DbSet<Ilce> Ilce { get; set; }
        public DbSet<Okul> Okul { get; set; }
    }

}