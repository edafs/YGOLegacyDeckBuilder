using System;
namespace LegacyDeckBuilder.Models.Data
{
	/// <summary>
	///		The model for the table for the TCG sets.
	/// </summary>
	public class SetReleases
	{

		/// <summary>
		///		The primary key.
		/// </summary>
		public int Key { get; set; }

		/// <summary>
		///		The Konami Code for the set.
		/// </summary>
		public string SetCode { get; set; }

		/// <summary>
		///		The number of cards in this set.
		/// </summary>
		public int CardCount { get; set; }

		/// <summary>
		///		The day the set was released.
		/// </summary>
		public DateTime ReleaseDate { get; set; }
	}
}
