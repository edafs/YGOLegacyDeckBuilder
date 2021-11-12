using System;
using Microsoft.AspNetCore.Mvc;

namespace LegacyDeckBuilder.Controllers
{
	[Route("api/echo")]
	public class EchoController : Controller
	{
		/// <summary>
		///		Verify this is working.
		/// </summary>
		public IActionResult Index()
		{
			return Ok($"{DateTime.Now.ToLongTimeString()}: This is alive.");
		}
	}
}
