using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LegacyDeckBuilder.Models;
using LegacyDeckBuilder.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace LegacyDeckBuilder.Repository
{
	public class CardCatalogRepository : ICardCatalogRepository
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
		public async Task<bool> AddItems(IEnumerable<CardCatalog> cardsToAdd)
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
		///		Gets all card results from the card catalog.
		/// </summary>
		public async Task<List<CardCatalog>> GetCatalog()
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

            IQueryable<CardCatalog> allCards = this.Context.CardCatalogs.AsNoTracking();
			if (allCards.Count() != 0)
			{
				this.Context.RemoveRange(allCards);
				await this.Context.SaveChangesAsync();
			}
		}

		/// <summary>
        ///		Gets a particular card by it's Id.
        /// </summary>
		public async Task<CardCatalog> GetCardById(int cardId)
        {
			if(cardId < 0)
            {
				return null;
            }

            CardCatalog searchedCard = await this.Context.CardCatalogs.AsNoTracking()
				.FirstOrDefaultAsync(card => card.CardId == cardId);

			return searchedCard;
        }

		/// <summary>
		///		Searches for cards through it's name.
		/// </summary>
		public async Task<List<CardCatalog>> SearchForCard(string cardQuery)
		{
            if (string.IsNullOrWhiteSpace(cardQuery))
            {
				return null;
            }

			List<CardCatalog> searchedCards = await this.Context.CardCatalogs.AsNoTracking()
				.Where(cards => cards.CardName.Contains(cardQuery))
				.ToListAsync();

			if (searchedCards != null && searchedCards.Count() > 0)
			{
				return searchedCards;
			}

			return null;
		}

	}
}
