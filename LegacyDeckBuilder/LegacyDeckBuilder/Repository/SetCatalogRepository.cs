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

		/// <summary>
		///		Adds items to the set catalog database.
		/// </summary>
		public async Task<bool> AddItems(List<SetCatalog> itemsToAdd)
		{
			using(YGOContext context = _ygoContext)
			{
				if(itemsToAdd.Count != 0)
				{
					await context.AddRangeAsync(itemsToAdd);
					await context.SaveChangesAsync();
				}
			}

			return true;
		}

		/// <summary>
		///		Removes all contents of the set catalog db.
		/// </summary>
		public async Task<bool> PurgeDb()
		{
			using (YGOContext context = _ygoContext)
			{
				// Remove all the old records.
				List<SetCatalog> oldRecords = await context.SetCatalogs.ToListAsync();

				if(oldRecords.Count != 0)
				{
					context.SetCatalogs.RemoveRange(oldRecords);
					await context.SaveChangesAsync();
				}
			}

			return true;
		}
	}
}
