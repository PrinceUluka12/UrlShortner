using Serilog;
using UrlShortner.API.Models;
using UrlShortner.API.Repository.IRepository;
using UrlShortner.API.Services.IServices;

namespace UrlShortner.API.Services
{
	public class UrlShorteningService : IUrlShorteningService
	{
		private readonly IUrlRepository _repository;
		private const string Characters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        public UrlShorteningService(IUrlRepository repository)
        {
			_repository = repository;
		}

        public async Task<string> CreateShortUrlAsync(string userName, string longUrl, int length)
		{
			try
			{
                var existingEntry = await _repository.GetByLongUrlAsync(longUrl);
                if (existingEntry != null)
                {
                    Log.Debug("Long Url Already exixts in database");
                    return existingEntry.ShortUrl;
                }

                string shortUrl;
                do
                {
                    shortUrl = GenerateShortUrl(length);
                } while (await _repository.GetByShortUrlAsync(shortUrl) != null);

                var newEntry = new UrlEntry
                {
                    UserName = userName,
                    LongUrl = longUrl,
                    ShortUrl = shortUrl,
                    ShortUrlLength = length,
                    CreatedAt = DateTime.UtcNow
                };

                await _repository.CreateEntryAsync(newEntry);
                return shortUrl;
            }
			catch (Exception ex )
			{

                Log.Error("Error in CreateShortUrlAsync Method", ex.Message);
                return null;
    
			}
			
		}
	

		public string GenerateShortUrl(int length)
		{
			var random = new Random();
			return new string(Enumerable.Repeat(Characters, length)
				.Select(s => s[random.Next(s.Length)]).ToArray());
		}

        public async Task<string> GetLongUrlAsync(string shortUrl)
        {
            try
            {
                var existingEntry = await _repository.GetByShortUrlAsync(shortUrl);
                if (existingEntry != null)
                {
                    return existingEntry.LongUrl;
                }
                else
                {

                    Log.Error($"Short Url {shortUrl} does not exist");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Log.Error("Error in GetShortUrlAsync Method", ex.Message);
                return null;
            }
           
        }
    }
}
