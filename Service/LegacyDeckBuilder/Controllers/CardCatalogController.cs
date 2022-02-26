using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using LegacyDeckBuilder.Models.Data;
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
		public async Task<IActionResult> GetFullCatalog()
		{
			throw new NotImplementedException("To be completed...");
		}

		/// <summary>
        ///		Gets a card by it's card Id.
        /// </summary>
		[HttpGet, Route("GetCard/{cardId}")]
		public async Task<IActionResult> GetCard(int cardId)
        {
			if(cardId < 1)
            {
				return StatusCode((int)HttpStatusCode.BadRequest,
					"Please enter a valid card Id.");
            }

			CardCatalog card = await this.CardService.GetCardById(cardId);

			if(card == null)
            {
				return StatusCode((int)HttpStatusCode.InternalServerError,
					"Unable to find the queried card.");
            }

			return Ok(card);
        }

		/// <summary>
		///		Queries for a card based on it's card name.
		/// </summary>
		[HttpGet, Route("FindCard/{cardName}")]
		public async Task<IActionResult> FindCard(string cardName)
		{
			if(string.IsNullOrWhiteSpace(cardName))
            {
				return StatusCode((int)HttpStatusCode.BadRequest,
					"Enter a valid search.");
            }

            List<CardCatalog> searchedCards = await this.CardService.SearchByCardName(cardName);

			if(searchedCards != null && searchedCards.Count > 0)
            {
				return Ok(searchedCards);
            }

			return StatusCode((int)HttpStatusCode.NotFound,
				"No cards could be found.");
		}
	}
}
