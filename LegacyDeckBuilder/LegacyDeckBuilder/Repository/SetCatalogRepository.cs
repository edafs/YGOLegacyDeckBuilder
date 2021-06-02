using System.Collections.Generic;
using System.Threading.Tasks;
using LegacyDeckBuilder.Models;
using LegacyDeckBuilder.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace LegacyDeckBuilder.Repository
{
	/// <summary>
	///		Operations on the set Catalog Dynamo Table.
	/// </summary>
	public class SetCatalogRepository
	{
		private readonly YGOContext _ygoContext;

		/// <summary>
		///		Operations on the set Catalog Dynamo Table.
		/// </summary>
		public SetCatalogRepository(YGOContext context)
		{
			_ygoContext = context;
		}

		/// <summary>
		///		Get the full set catalog from dynamoDB.
		/// </summary>
		public async Task<List<SetCatalog>> GetSetCatalog()
		{
			List<SetCatalog> fullCatalog = new List<SetCatalog>();

			using (YGOContext context = _ygoContext)
			{
				fullCatalog = await context.SetCatalogs.AsNoTracking().ToListAsync();
			}

			return fullCatalog;
		}
	}
}
