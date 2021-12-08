using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using LegacyDeckBuilder.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LegacyDeckBuilder.Controllers
{
	/// <summary>
	///		The card catalog controller.
	/// </summary>
	[Route("api/CardCatalog")]
	public class CardCatalogController : Controller
	{
		/// <summary>
		///		Singleton instance of the Card Service.
		/// </summary>
		private readonly ICardCatalogService CardService;

		/// <summary>
		///		Constructor for <see cref="CardCatalogController"/>.
		/// </summary>
		public CardCatalogController(ICardCatalogService service)
		{
			this.CardService = service ??
				throw new ArgumentNullException("Card Catalog Service is not properly initialized.");
		}

		/// <summary>
		///		Refreshes the database.
		/// </summary>
		[HttpPut, Route("RefreshCatalog")]
		public async Task<IActionResult> RefreshCatalog()
		{
			bool wasTaskSuccessful = await this.CardService.RefreshCardCatalog();

			if (!wasTaskSuccessful)
			{
				return StatusCode((int)HttpStatusCode.InternalServerError,
					"Failed to refresh the card catalog. Try again later.");
			}

			return Ok("Card catalog has been refreshed.");
		}

		/// <summary>
		///		Returns all the cards in the card catalog.
		/// </summary>
		[HttpGet, Route("FullCatalog")]
		public Task<IActionResult> GetFullCatalog()
		{
			throw new NotImplementedException("To be completed...");
		}

		/// <summary>
		///		Queries for a card based on it's card name.
		/// </summary>
		[HttpGet, Route("FindCard/{cardName}")]
		public Task<IActionResult> FindCard(string cardName)
		{
			throw new NotImplementedException("To be completed...");
		}
	}
}
