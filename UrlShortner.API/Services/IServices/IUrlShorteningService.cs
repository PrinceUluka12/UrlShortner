namespace UrlShortner.API.Services.IServices
{
	public interface IUrlShorteningService
	{

		public string GenerateShortUrl(int length);
		Task<string> CreateOrGetShortUrlAsync(string userName, string longUrl, int length);
	}
}
