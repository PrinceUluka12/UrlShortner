using Microsoft.EntityFrameworkCore;
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
			_db.UrlEntries.Add(entry);
			await _db.SaveChangesAsync();
			return entry;
		}

		public async Task<UrlEntry> GetByLongUrlAsync(string longUrl)
		{
			return await _db.UrlEntries.FirstOrDefaultAsync(e => e.LongUrl == longUrl);
		}

		public async Task<UrlEntry> GetByShortUrlAsync(string shortUrl)
		{
			return await _db.UrlEntries.FirstOrDefaultAsync(e => e.ShortUrl == shortUrl);
		}
	}
}
