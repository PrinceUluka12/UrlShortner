using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UrlShortner.API.Models;
using UrlShortner.API.Services;
using UrlShortner.API.Services.IServices;

namespace UrlShortner.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UrlShortenerController : ControllerBase
	{
		private readonly IUrlShorteningService _service;

        public UrlShortenerController(IUrlShorteningService service)
        {
			_service = service;
		}

		[HttpPost("shorten")]
		public async Task<IActionResult> ShortenUrl([FromBody] UrlRequest request)
		{
			var shortUrl = await _service.CreateOrGetShortUrlAsync(request.UserName, request.LongUrl, request.Length);
			return Ok(new { ShortUrl = shortUrl });
		}

		/*[HttpGet("{shortUrl}")]
		public async Task<IActionResult> RedirectToLongUrl(string shortUrl)
		{
			var entry = await _service.CreateOrGetShortUrlAsync(shortUrl);
			if (entry == null)
			{
				return NotFound("URL not found");
			}

			return Redirect(entry.LongUrl);
		}*/
	}
}
