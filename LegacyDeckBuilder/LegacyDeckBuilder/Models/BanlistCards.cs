using DeckBuilderService.Banlist;

namespace LegacyDeckBuilder.Models
{
	public class BanlistCards
	{
		/// <summary>
		///		The YGODB id of the card.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		///		Restricted status of the card.
		/// </summary>
		public Restrictions RestrictionStatus { get; set; }
	}
}
