using Microsoft.AspNetCore.Mvc;
using UrlShortner.Web.Models;

namespace UrlShortner.Web.Controllers
{
	public class UrlShortenerController : Controller
	{
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		/*[HttpPost]
		public async Task<IActionResult> Index(UrlRequestModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			var shortUrl = await _service.CreateOrGetShortUrlAsync(model.UserName, model.LongUrl, model.Length);
			ViewBag.ShortUrl = shortUrl;
			return View();
		}

		[HttpGet("redirect/{shortUrl}")]
		public async Task<IActionResult> RedirectToLongUrl(string shortUrl)
		{
			var entry = await _service.GetByShortUrlAsync(shortUrl);
			if (entry == null)
			{
				return NotFound("URL not found");
			}

			return Redirect(entry.LongUrl);
		}*/
	}
}
