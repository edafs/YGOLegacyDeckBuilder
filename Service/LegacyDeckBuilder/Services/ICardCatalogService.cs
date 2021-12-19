using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LegacyDeckBuilder.Models.Data;
using LegacyDeckBuilder.Models.Response;

namespace LegacyDeckBuilder.Services
{
    public interface ICardCatalogService
    {
        /// <summary>
		///		Refresh the card catalog.
		/// </summary>
		Task<bool> RefreshCardCatalog();

		/// <summary>
		///		Gets all the cards from the Card Catalog.
		/// </summary>
		Task<List<CardCatalog>> GetFullCardCatalog();

		/// <summary>
		///		Search for a card by it's Id.
		/// </summary>
		Task<CardCatalog> GetCardById(int cardId);

		/// <summary>
		///		Searchs for a card's by it's card name.
		/// </summary>
		Task<List<CardCatalog>> SearchByCardName(string query);
	}
}

