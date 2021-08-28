using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LegacyDeckBuilder.Models.Adapter;
using LegacyDeckBuilder.Models.Data;
using LegacyDeckBuilder.Models.Response;
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
		///		An instance of <see cref="SetCatalogRepository"/>.
		/// </summary>
		public readonly SetCatalogRepository SetCatalogRepo;

		/// <summary>
		///		An instance of <see cref="WebServices"/>.
		/// </summary>
		public readonly WebService WebServices;

		/// <summary>
		///		Constructor for <see cref="SetCatalogService"/>.
		/// </summary>
		public SetCatalogService(SetCatalogRepository setCatalogRepo, WebService webService)
		{
			this.SetCatalogRepo = setCatalogRepo ??
				throw new ArgumentNullException("SetCatalogRepo not initialized.");

			this.WebServices = webService ??
				throw new ArgumentNullException("WebService was not initialized.");
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

		/// <summary>
		///		Removes all the content in the database and reloads the data
		///		from the card sets in the YGO api call.
		/// </summary>
		public async Task<bool> RefreshCatalog()
		{
			List<CardSet> allSets = await GetAllCardSets();

			if (allSets.Count == 0)
			{
				return false;
			}

			await this.SetCatalogRepo.PurgeDb();
			await this.SetCatalogRepo.AddItems(allSets.ToData());

			return true;
		}

		/// <summary>
		///		Gets all the card sets from the YGO.
		/// </summary>
		private async Task<List<CardSet>> GetAllCardSets()
		{
			List<CardSet> response = await WebServices
				.CardSetFromYGOService<CardSet>("https://db.ygoprodeck.com/api/v7/cardsets.php");

			if(response.Count > 0)
			{
				return response;
			}
			else
			{
				return new List<CardSet>();
			}
		}
	}
}
