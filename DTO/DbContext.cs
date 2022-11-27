using Entity.Conc;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
	public class DBContext : DbContext
	{
		public DbSet<Linkler> linklers { get; set; }
		public DbSet<Haber> Haberler { get; set; }

		public DbSet<HaberSitesiModel> HaberSiteleri { get; set; }

		public DbSet<Kategoriler> Kategoriler { get; set; }

		public DBContext(DbContextOptions options) : base(options)
		{

		}
		public DBContext() : base()
		{

		}
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlite("Data Source=database.db"); // veritabanının yolunu belirliyoruz.
		}
	}
}
