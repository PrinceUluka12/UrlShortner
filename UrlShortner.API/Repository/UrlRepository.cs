using Microsoft.EntityFrameworkCore;
using Serilog;
using UrlShortner.API.Data;
using UrlShortner.API.Models;
using UrlShortner.API.Repository.IRepository;

namespace UrlShortner.API.Repository
{
    // Repository class that implements the IUrlRepository interface
    // Responsible for handling data access logic for UrlEntry entities
    public class UrlRepository : IUrlRepository
	{
        // Private field to hold the AppDbContext instance
        private readonly AppDbContext _db;

        // Constructor to inject the AppDbContext dependency
        public UrlRepository(AppDbContext db)
        {
            // Initialize the database context
            _db = db;
        }
        // Method to create a new UrlEntry in the database
        public async Task<UrlEntry> CreateEntryAsync(UrlEntry entry)
		{
			try
			{
                _db.UrlEntries.Add(entry);
                await _db.SaveChangesAsync();
                return entry;
            }
			catch (Exception ex)
			{
                // Log any errors that occur during the operation
                Log.Error("Error in CreateEntryAsync Method", ex.Message);
                return null;
            }
			
		}
        // Method to get a UrlEntry by its long URL
        public async Task<UrlEntry> GetByLongUrlAsync(string longUrl)
		{
			try
			{
                // Find and return the first UrlEntry that matches the long URL
                return await _db.UrlEntries.FirstOrDefaultAsync(e => e.LongUrl == longUrl);
            }
			catch (Exception ex)
			{
                // Log any errors that occur during the operation
                Log.Error("Error in GetByLongUrlAsync Method", ex.Message);
                return null;
            }
			
		}
        // Method to get a UrlEntry by its short URL
        public async Task<UrlEntry> GetByShortUrlAsync(string shortUrl)
		{
			try
			{
                // Find and return the first UrlEntry that matches the short URL
                return await _db.UrlEntries.FirstOrDefaultAsync(e => e.ShortUrl == shortUrl);
            }
			catch (Exception ex)
			{
                // Log any errors that occur during the operation
                Log.Error("Error in GetByLongUrlAsync Method", ex.Message);
				return null;
            }
			
		}
	}
}
