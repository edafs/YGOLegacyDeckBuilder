using LegacyDeckBuilder.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace LegacyDeckBuilder.Models
{
	public class YGOContext : DbContext
	{
		public YGOContext()
		{
		}

		public YGOContext(DbContextOptions<YGOContext> options) : base(options) { }

		public DbSet<SetCatalog> SetCatalogs { get; set; }

		public DbSet<CardCatalog> CardCatalogs { get; set; }

		public DbSet<Restriction> Restrictions { get; set; }
    }
}