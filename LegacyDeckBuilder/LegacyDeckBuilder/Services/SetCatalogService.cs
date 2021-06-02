using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LegacyDeckBuilder.Models.Data;
using LegacyDeckBuilder.Repository;

namespace LegacyDeckBuilder.Services
{
	/// <summary>
	///		Operations on the set Catalog Dynamo Table.
	/// </summary>
	/// <remarks>
	///		Data Model: <see cref="SetReleases"/>.
	/// </remarks>
	public class SetCatalogService
	{
		/// <summary>
		///		Singleton instance of <see cref="SetCatalogRepository"/>.
		/// </summary>
		public readonly SetCatalogRepository SetCatalogRepo;

		/// <summary>
		///		Constructor for <see cref="SetCatalogService"/>.
		/// </summary>
		public SetCatalogService(SetCatalogRepository setCatalogRepo)
		{
			this.SetCatalogRepo = setCatalogRepo ??
				throw new ArgumentNullException("SetCatalogRepo not initialized.");
		}

		/// <summary>
		///		Returns all the sets released by Konami.
		/// </summary>
		public async Task<IEnumerable<SetCatalog>> GetSetCatalog()
		{
			IEnumerable<SetCatalog> setCatalog = await this.SetCatalogRepo.GetSetCatalog();

			if(setCatalog == null)
			{
				return null;
			}
			else
			{
				return setCatalog;
			}
		}
	}
}
