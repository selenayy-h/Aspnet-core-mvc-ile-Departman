using Microsoft.CodeAnalysis.Elfie.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using System.Collections.Generic;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;



//Bu, Entity Framework Core kütüphanesini projeye dahil eder. Bu kütüphane, Entity Framework Core sınıflarını ve DbContext gibi veritabanı işlemlerini kolaylaştıran yapıları sağlar.


//using System.Collections.Generic: List gibi generic koleksiyonları kullanabilmek için bu kütüphane eklenir.

namespace ProjeCore.Models
{
    public class Context : DbContext


		//Context sınıfı, Entity Framework’teki DbContext sınıfından türetilmiştir

	{
		//OnConfiguring metodu, DbContext sınıfının bir parçasıdır ve veritabanı yapılandırmalarının ayarlanması için kullanılır.Bu yöntemde bağlantı dizesi(connection string) belirlenir
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=LAPTOP-ACDH94DG\\SQLEXPRESS01;database=BirimDB;integrated security=true;TrustServerCertificate=True;");
        }

        public DbSet<Birim> Birims { get; set; }
        public DbSet<Personel> Personels { get; set; }

		public DbSet<Admin> Admins { get; set; }
		//Amaç: Admins koleksiyonuyla Admin tablosunda CRUD(Create, Read, Update, Delete) işlemleri yapabilmektir.


		//örneğn :Admin Kaydı Ekleme:var yeniAdmin = new Admin { Ad = "Ali", Sifre = "1234" };
		//context.Admins.Add(yeniAdmin);

	}
}
