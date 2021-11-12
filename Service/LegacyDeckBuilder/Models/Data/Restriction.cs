using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LegacyDeckBuilder.Banlist;

namespace LegacyDeckBuilder.Models.Data
{
	[Table("Restrictions")]
	public class Restriction
	{
		/// <summary>
		///		The RestrictionID.
		///		The ID for this wil match <see cref="Restrictions"/> enums.
		/// </summary>
		[Column("RestrictionID")]
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int RestrictionId { get; set; }

		[Column("Title"), MaxLength(50)]
		public string Title { get; set; }

		[Column("Summary"), MaxLength(200)]
		public string Summary { get; set; }
	}
}
