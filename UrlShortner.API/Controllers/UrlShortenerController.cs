﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
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
		private readonly ResponseDto _response;

        public UrlShortenerController(IUrlShorteningService service)
        {
			_service = service;
			_response = new ResponseDto();
		}

		[HttpPost("shorten")]
		public async Task<IActionResult> ShortenUrl([FromBody] UrlRequest request)
		{
			try
			{
                var shortUrl = await _service.CreateShortUrlAsync(request.UserName, request.LongUrl, request.Length);
                Log.Information(shortUrl);
				_response.Result = new { ShortUrl = shortUrl };
                return Ok(_response);
            }
			catch (Exception ex)
			{
                Log.Error(ex, "An error occurred while creating the short URL for user {UserName}", request.UserName);
                return StatusCode(500, new { Message = "An unexpected error occurred while processing your request. Please try again later." });
            }
			
		}

		[HttpGet("{shortUrl}")]
		public async Task<IActionResult> RedirectToLongUrl(string shortUrl)
		{
			try
			{
                var entry = await _service.GetLongUrlAsync(shortUrl);
                if (entry == null)
                {
					_response.IsSuccess = false;
					_response.Message = "URL not found";
                    return NotFound(_response);
                }
                Log.Information(entry);
				_response.Result = new { LongUrl = entry };
                return Ok(_response);
            }
			catch (Exception ex)
			{
                Log.Error(ex, "An error occurred while redirecting short URL: {ShortUrl}", shortUrl);
                return StatusCode(500, new { Message = "An unexpected error occurred. Please try again later." });
            }
			
		}
	}
}
