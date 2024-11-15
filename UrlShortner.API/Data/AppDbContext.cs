using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using UrlShortner.API.Models;

namespace UrlShortner.API.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<UrlEntry>().HasIndex(u => u.ShortUrl).IsUnique();
		}
		public DbSet<UrlEntry> UrlEntries { get; set; }

	}
}
