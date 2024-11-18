using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using UrlShortner.API.Models;

namespace UrlShortner.API.Data
{
    // DbContext class for interacting with the database and managing entities
    public class AppDbContext : DbContext
	{
        // Constructor that takes DbContextOptions to configure the context
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }



        // Configuring the model and entity relationships when the model is created

        protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
            // Adding a unique index constraint on the ShortUrl property in the UrlEntry entity
            // This ensures that each ShortUrl is unique in the database

            modelBuilder.Entity<UrlEntry>().HasIndex(u => u.ShortUrl).IsUnique();
		}

        // Defining the UrlEntries DbSet which represents the UrlEntry table in the database

        public DbSet<UrlEntry> UrlEntries { get; set; }

	}
}
