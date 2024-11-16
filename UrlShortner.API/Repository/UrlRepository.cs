using Microsoft.EntityFrameworkCore;
using Serilog;
using UrlShortner.API.Data;
using UrlShortner.API.Models;
using UrlShortner.API.Repository.IRepository;

namespace UrlShortner.API.Repository
{
    public class UrlRepository : IUrlRepository
	{
		private readonly AppDbContext _db;

        public UrlRepository(AppDbContext db)
        {
                _db = db;
        }

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

                Log.Error("Error in CreateEntryAsync Method", ex.Message);
                return null;
            }
			
		}

		public async Task<UrlEntry> GetByLongUrlAsync(string longUrl)
		{
			try
			{
                return await _db.UrlEntries.FirstOrDefaultAsync(e => e.LongUrl == longUrl);
            }
			catch (Exception ex)
			{

                Log.Error("Error in GetByLongUrlAsync Method", ex.Message);
                return null;
            }
			
		}

		public async Task<UrlEntry> GetByShortUrlAsync(string shortUrl)
		{
			try
			{
                return await _db.UrlEntries.FirstOrDefaultAsync(e => e.ShortUrl == shortUrl);
            }
			catch (Exception ex)
			{

                Log.Error("Error in GetByLongUrlAsync Method", ex.Message);
				return null;
            }
			
		}
	}
}
