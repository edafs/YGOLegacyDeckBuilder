using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LegacyDeckBuilder.Models.Adapter;
using LegacyDeckBuilder.Models.Data;
using LegacyDeckBuilder.Models.Response;
using LegacyDeckBuilder.Repository;

namespace LegacyDeckBuilder.Services
{
    public class CardCatalogService : ICardCatalogService
	{
		/// <summary>
		///		Singleton instance of <see cref="ICardCatalogRepository"/> for this class.
		/// </summary>
		public readonly ICardCatalogRepository CardRepository;

		/// <summary>
		///		Singleton instance of <see cref="WebServices"/> for this class. 
		/// </summary>
		public readonly WebService WebServices;

		/// <summary>
		///		Default constructor for <see cref="CardCatalogService"/>.
		/// </summary>
		public CardCatalogService(ICardCatalogRepository cardCatalogRepo, WebService webServices)
		{
			this.CardRepository = cardCatalogRepo;
			this.WebServices = webServices;
		}

		/// <summary>
		///		Gets all the cards from the YGODB api.
		/// </summary>
		private async Task<List<CardInfo>> GetAllCards()
		{
			List<CardInfo> allCards = await this.WebServices
				.CardCatalogFromYgoService("https://db.ygoprodeck.com/api/v7/cardinfo.php");

			if (allCards.Count != 0)
			{
				return allCards;
			}

			return new List<CardInfo>();
		}

		/// <summary>
		///		Refresh the card catalog.
		/// </summary>
		public async Task<bool> RefreshCardCatalog()
		{
			List<CardInfo> allCards = this.GetAllCards().Result;

			if (!allCards.Any())
			{
				return false;
			}

			await this.CardRepository.PurgeDb();
			return await this.CardRepository.AddItems(allCards.ToData());
		}

		/// <summary>
		///		Gets all the cards from the Card Catalog.
		/// </summary>
		public async Task<List<CardCatalog>> GetFullCardCatalog()
		{
			List<CardCatalog> allCardsFromCatalog = await this.CardRepository.GetCatalog();

			if (allCardsFromCatalog == null)
			{
				return new List<CardCatalog>();
			}

			return allCardsFromCatalog;
		}

		/// <summary>
		///		Search for a card by it's Id.
		/// </summary>
		public async Task<CardCatalog> GetCardById(int cardId)
		{
            CardCatalog card = await this.CardRepository.GetCardById(cardId);
			return card;
		}

		/// <summary>
        ///		Searchs for a card's by it's card name.
        /// </summary>
		public async Task<List<CardCatalog>> SearchByCardName(string query)
		{
            if (string.IsNullOrWhiteSpace(query))
            {
				return null;
            }

            List<CardCatalog> cardList = await this.CardRepository.SearchForCard(query);

			if (cardList != null && cardList.Count > 0)
            {
				return cardList;
            }

			return null;
		}
	}
}
