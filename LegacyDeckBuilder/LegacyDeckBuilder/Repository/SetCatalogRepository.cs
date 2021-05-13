using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LegacyDeckBuilder.Models.Data;

namespace LegacyDeckBuilder.Repository
{
	/// <summary>
	///		Operations on the set Catalog Dynamo Table.
	/// </summary>
	public class SetCatalogRepository
	{
		/// <summary>
		///		Operations on the set Catalog Dynamo Table.
		/// </summary>
		public SetCatalogRepository()
		{
		}

		/// <summary>
		///		Get the full set catalog from dynamoDB.
		/// </summary>
		/// <returns></returns>
		public async Task<IEnumerable<SetReleases>> GetSetCatalog()
		{
			throw new NotImplementedException(
				"LegacyDeckBuilder.Repository.SetCatalogRepo.GetSetCatalog()"
			);
		}
	}
}
