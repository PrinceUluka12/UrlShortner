using System.ComponentModel.DataAnnotations;

namespace UrlShortner.Web.Models
{
	public class UrlRequestModel
	{
		[Required]
		[StringLength(100, ErrorMessage = "User Name cannot be longer than 100 characters.")]
		public string UserName { get; set; }

		[Required]
		[Url(ErrorMessage = "Invalid URL format.")]
		public string LongUrl { get; set; }

		[Range(5, 50, ErrorMessage = "Length must be between 5 and 50 characters.")]
		public int Length { get; set; }
	}
}
