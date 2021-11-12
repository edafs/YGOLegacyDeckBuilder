using System;
using System.Collections.Generic;
using System.Linq;
using LegacyDeckBuilder.Models.Data;
using LegacyDeckBuilder.Models.Response;

namespace LegacyDeckBuilder.Models.Adapter
{
	public static class CardAdapter
	{
		/// <summary>
		///		Converts a list of <see cref="CardInfo"/> cards from the YGODB api
		///		to a list of <see cref="CardCatalog"/> of our data type.
		/// </summary>
		public static List<CardCatalog> ToData(this IEnumerable<CardInfo> cards)
		{
			if(cards.Count() == 0)
			{
				return new List<CardCatalog>();
			}

			List<CardCatalog> convertedCards = new List<CardCatalog>();

			foreach(CardInfo card in cards)
			{
				CardCatalog convertedCard = new CardCatalog()
				{
					CardId = card.Id,
					CardName = card.Name,
					ImageUrl = card.Images.FirstOrDefault().Thumbnail
				};

				convertedCards.Add(convertedCard);
			}

			return convertedCards;
		}
	}
}
