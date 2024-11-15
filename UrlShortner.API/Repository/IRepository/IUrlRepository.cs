using UrlShortner.API.Models;

namespace UrlShortner.API.Repository.IRepository
{
    public interface IUrlRepository
    {
        Task<UrlEntry> GetByShortUrlAsync(string shortUrl);
        Task<UrlEntry> CreateEntryAsync(UrlEntry entry);
        Task<UrlEntry> GetByLongUrlAsync(string longUrl);
    }
}
