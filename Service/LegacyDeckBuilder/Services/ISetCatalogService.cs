using System.Collections.Generic;
using System.Threading.Tasks;
using LegacyDeckBuilder.Models.Data;
using LegacyDeckBuilder.Models.Response;

namespace LegacyDeckBuilder.Services
{
    /// <summary>
    ///     Interface for the service layer for card sets.
    /// </summary>
    public interface ISetCatalogService
    {
        /// <summary>
		///		Returns all the sets released by Konami.
		/// </summary>
		Task<List<SetCatalog>> GetSetCatalog();

        /// <summary>
		///		Removes all the content in the database and reloads the data
		///		from the card sets in the YGO api call.
		/// </summary>
		Task<bool> RefreshCatalog();
	}
}
