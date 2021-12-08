using System.Collections.Generic;
using System.Threading.Tasks;
using LegacyDeckBuilder.Models.Data;

namespace LegacyDeckBuilder.Repository
{
    public interface ISetCatalogRepository
    {
		/// <summary>
		///		Get the full set catalog from dynamoDB.
		/// </summary>
		Task<List<SetCatalog>> GetCatalog();

		/// <summary>
		///		Adds items to the set catalog database.
		/// </summary>
		Task AddItems(List<SetCatalog> itemsToAdd);

		/// <summary>
		///		Removes all contents of the set catalog db.
		/// </summary>
		Task PurgeDb();
	}
}
