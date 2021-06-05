using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LegacyDeckBuilder.Models.Data
{
	[Table("CardCatalog")]
	public class CardCatalog
	{
		/// <summary>
		///		The YGOProDeck Identifier for the card.
		///		We will define this ID.
		/// </summary>
		[Column("CardID")]
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int CardId { get; set; }

		/// <summary>
		///		The name of the card.
		/// </summary>
		[Column("CardName"), MaxLength(75)]
		public string CardName { get; set; }

		/// <summary>
		///		The URL of the card's image.
		/// </summary>
		[Column("ImageUrl"), MaxLength(125)]
		public string ImageUrl { get; set; }

		#region Formats

		/// <summary>
		///		Legality Status in Sept 2011 format.
		/// </summary>
		[Column("Format_Sept2011")]
		public int Sept2011 { get; set; }

		/// <summary>
		///		Legality Status in Edison Format.
		/// </summary>
		[Column("Format_Edison")]
		public int Edison { get; set; }

		#endregion
	}
}
