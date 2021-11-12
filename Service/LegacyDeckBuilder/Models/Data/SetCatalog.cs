using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LegacyDeckBuilder.Models.Data
{
	/// <summary>
	///		The model for the table for the TCG sets.
	/// </summary>
	[Table("SetCatalog")]
	public class SetCatalog
	{
		/// <summary>
		///		The primary key Id.
		///		This can be set by the db.
		/// </summary>
		[Column("SetId")]
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int SetId { get; set; }

		/// <summary>
		///		The Konami Code for the set.
		/// </summary>
		[Column("SetCode"), MaxLength(15)]
		public string SetCode { get; set; }

		/// <summary>
		///		The name of the set.
		/// </summary>
		[Column("SetName"), MaxLength(15)]
		public string SetName { get; set; }

		/// <summary>
		///		The number of cards in this set.
		/// </summary>
		[Column("CardCount")]
		public int CardCount { get; set; }

		/// <summary>
		///		The day the set was released.
		/// </summary>
		[Column("ReleaseDate")]
		public DateTime ReleaseDate { get; set; }
	}
}
