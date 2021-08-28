using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LegacyDeckBuilder.Models;
using LegacyDeckBuilder.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace LegacyDeckBuilder.Repository
{
	public class CardCatalogRepository
	{
		/// <summary>
		///		Database context.
		/// </summary>
		private readonly YGOContext Context;

		/// <summary>
		///		Constructor for <see cref="CardCatalogRepository"/>.
		/// </summary>
		/// <param name="context"></param>
		public CardCatalogRepository(YGOContext context)
		{
			this.Context = context;
		}

		/// <summary>
		///		Adds card(s) to the card catalog database.
		///		Return whether or not the task was successful.
		/// </summary>
		public async Task<bool> AddCardsToCatalog(IEnumerable<CardCatalog> cardsToAdd)
		{
			if (cardsToAdd.Count() != 0)
			{
				try
				{
					await this.Context.CardCatalogs.AddRangeAsync(cardsToAdd);
					await this.Context.SaveChangesAsync();
				}
				catch
				{
					// This should really only happen if the card already exists.
					return false;
				}
			}

			return true;
		}

		/// <summary>
		///		
		/// </summary>
		public async Task<List<CardCatalog>> GetCardCatalog()
		{
			List<CardCatalog> fullCardCatalog = await this.Context
				.CardCatalogs.AsNoTracking()
				.ToListAsync();

			return fullCardCatalog;
		}

		/// <summary>
		///		Purges the DB.
		/// </summary>
		public async Task PurgeDb()
		{
			/*
			 *	TODO:
			 *	Enumerating over .RemoveRange() is not performant.
			 *	There are more than 10k cards, which can blowup this EF query.
			 */

			var allCards = this.Context.CardCatalogs.AsNoTracking();
			if (allCards.Count() != 0)
			{
				this.Context.RemoveRange(allCards);
				await this.Context.SaveChangesAsync();
			}
		}

		public List<CardCatalog> SearchForCard()
		{
			throw new System.NotImplementedException("Search For Card Not Yet Implemented.");
		}
	}
}
