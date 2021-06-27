using System;
using System.Collections.Generic;
using System.Linq;
using LegacyDeckBuilder.Models.Data;
using LegacyDeckBuilder.Models.Response;

namespace LegacyDeckBuilder.Models.Adapter
{
	/// <summary>
	///		Converts primitive types, as long as it relates to the Sets.
	/// </summary>
	public static class CatalogAdapter
	{
		/// <summary>
		///		Converts a list of <see cref="CardSet"/>
		///		to a list list of <see cref="SetCatalog"/>.
		/// </summary>
		public static List<SetCatalog> ToData(this IEnumerable<CardSet> cardSets)
		{
			List<SetCatalog> catalog = new List<SetCatalog>();

			if (!cardSets.Any())
			{
				return catalog;
			}

			foreach(CardSet set in cardSets)
			{
				SetCatalog catalogItem = new SetCatalog()
				{
					SetCode = set.SetCode,
					SetName = set.SetName,
					CardCount = set.CardCount,
					ReleaseDate = Convert.ToDateTime(set.ReleaseDate)
			};

				catalog.Add(catalogItem);
			}

			return catalog;
		}
	}
}
