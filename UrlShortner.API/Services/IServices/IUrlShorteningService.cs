namespace UrlShortner.API.Services.IServices
{
	public interface IUrlShorteningService
	{

		public string GenerateShortUrl(int length);
		Task<string> CreateShortUrlAsync(string userName, string longUrl, int length);
		Task<string> GetShortUrlAsync( string shortUrl);
	}
}
