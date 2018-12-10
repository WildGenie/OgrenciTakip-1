namespace OgrenciTakip.Data.Context
{
    using Model;
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
        public DbSet<Filtre> Filtre { get; set; }
        public DbSet<AileBilgi> AileBilgi { get; set; }
        public DbSet<IptalNedeni> IptalNedeni { get; set; }
        public DbSet<YabanciDil> YabanciDil { get; set; }
        public DbSet<Tesvik> Tesvik { get; set; }
        public DbSet<Kontenjan> Kontenjan { get; set; }
        public DbSet<Rehber> Rehber { get; set; }
        public DbSet<SinifGrup> SinifGrup { get; set; }
        public DbSet<Meslek> Meslek { get; set; }
        public DbSet<Yakinlik> Yakinlik { get; set; }
        public DbSet<Isyeri> Isyeri { get; set; }
        public DbSet<Gorev> Gorev { get; set; }
        public DbSet<IndirimTuru> IndirimTuru { get; set; }
        public DbSet<Evrak> Evrak { get; set; }
        public DbSet<Donem> Donem { get; set; }
        public DbSet<Sube> Sube { get; set; }
        public DbSet<Promosyon> Promosyon { get; set; }
        public DbSet<Servis> Servis { get; set; }
        public DbSet<Sinif> Sinif { get; set; }
        public DbSet<HizmetTuru> HizmetTuru { get; set; }
        public DbSet<Hizmet> Hizmet { get; set; }
        public DbSet<OzelKod> OzelKod { get; set; }
        public DbSet<Kasa> Kasa { get; set; }
        public DbSet<Banka> Banka { get; set; }
        public DbSet<BankaSube> BankaSube { get; set; }
    }

}