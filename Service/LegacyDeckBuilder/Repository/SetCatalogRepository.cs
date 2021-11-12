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
	public class SetCatalogRepository : ISetCatalogRepository
	{
		private readonly YGOContext Context;

		/// <summary>
		///		Operations on the set Catalog Dynamo Table.
		/// </summary>
		public SetCatalogRepository(YGOContext context)
		{
			this.Context = context;
		}

		/// <summary>
		///		Get the full set catalog from dynamoDB.
		/// </summary>
		public async Task<List<SetCatalog>> GetCatalog()
		{
			List<SetCatalog> fullCatalog = await this.Context
				.SetCatalogs.AsNoTracking().ToListAsync();

			return fullCatalog;
		}

		/// <summary>
		///		Adds items to the set catalog database.
		/// </summary>
		public async Task AddItems(List<SetCatalog> itemsToAdd)
		{
			if (itemsToAdd.Count != 0)
			{
				await this.Context.AddRangeAsync(itemsToAdd);
				await this.Context.SaveChangesAsync();
			}

			return;
		}

		/// <summary>
		///		Removes all contents of the set catalog db.
		/// </summary>
		public async Task PurgeDb()
		{
			// Remove all the old records.
			List<SetCatalog> oldRecords = await this.Context
				.SetCatalogs.ToListAsync();

			if (oldRecords.Count != 0)
			{
				this.Context.SetCatalogs.RemoveRange(oldRecords);
				await this.Context.SaveChangesAsync();
			}

			return;
		}
	}
}