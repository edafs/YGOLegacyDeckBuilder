using System.Collections.Generic;
using System.Threading.Tasks;
using LegacyDeckBuilder.Models.Data;

namespace LegacyDeckBuilder.Repository
{
    public interface ICardCatalogRepository
    {
        /// <summary>
		///		Adds card(s) to the card catalog database.
		///		Return whether or not the task was successful.
		/// </summary>
        Task<bool> AddItems(IEnumerable<CardCatalog> cardsToAdd);

        /// <summary>
		///		Gets all card results from the card catalog.
		/// </summary>
        Task<List<CardCatalog>> GetCatalog();

        /// <summary>
		///		Purges the DB.
		/// </summary>
		Task PurgeDb();

		/// <summary>
		///		Gets a particular card by it's Id.
		/// </summary>
		Task<CardCatalog> GetCardById(int cardId);

		/// <summary>
		///		Searches for a particular card.
		/// </summary>
		Task<List<CardCatalog>> SearchForCard(string query);
	}
}
