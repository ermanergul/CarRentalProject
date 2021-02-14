using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    //NuGet Packages'den entityframeworksql eklendi . Artık entityframework eklenebilir
    //Entity Framework Sürecindeki ilk aşama : Veri tabanı nesneleri ile yani veritabanıyola benim kendi nesnelerimi ilişkilendirmem gerekiyor.
    //Bu ilişkilendirme işlemini için context dosyası oluşturuldu
    
    //Context:  Db taboları ile proje classlarını ilişkilendirme(bağlamak)
    public class RentACarContext:DbContext
    {
        //ovveride configuring : projenin hangi veritabanı ile ilişkiyi belirttiğimiz işlem
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //@ : \ c#'da bir anlamı var. \ kullanılacağı zaman \\ kullanılır. @ bunu gidermek için
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=RentACar;Trusted_Connection=true");
        }
        //Car nesnesini veribanındaki Cars ile bağla
        public DbSet<Car> Cars { get; set; }
        //Color nesnesini veribanındaki Colors ile bağla
        public DbSet<Color> Colors { get; set; }
        //Brand nesnesini veribanındaki Brands ile bağla
        public DbSet<Brand> Brands { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        
    }
}
