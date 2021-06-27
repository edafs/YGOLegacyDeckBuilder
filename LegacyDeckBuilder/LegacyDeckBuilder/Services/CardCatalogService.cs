using System.Collections.Generic;
using System.Threading.Tasks;
using LegacyDeckBuilder.Models.Response;
using LegacyDeckBuilder.Repository;

namespace LegacyDeckBuilder.Services
{
	public class CardCatalogService
	{
		/// <summary>
		///		Singleton instance of <see cref="CardCatalogRepository"/> for this class.
		/// </summary>
		public readonly CardCatalogRepository CardRepository;

		/// <summary>
		///		Singleton instance of <see cref="WebServices"/> for this class. 
		/// </summary>
		public readonly WebService WebServices;

		/// <summary>
		///		Default constructor for <see cref="CardCatalogService"/>.
		/// </summary>
		public CardCatalogService(CardCatalogRepository cardCatalogRepo, WebService webServices)
		{
			this.CardRepository = cardCatalogRepo;
			this.WebServices = webServices;
		}

		/// <summary>
		///		Gets all the cards.
		/// </summary>
		public async Task<List<CardInfo>> GetAllCards()
		{
			List<CardInfo> cardsFromApi = await this.WebServices
				.SendGetRequest<CardInfo>("https://db.ygoprodeck.com/api/v7/cardinfo.php");

			if(cardsFromApi.Count > 0)
			{
				return cardsFromApi;
			}

			return new List<CardInfo>();
		}
	}
}
