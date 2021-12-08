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

	}
}

