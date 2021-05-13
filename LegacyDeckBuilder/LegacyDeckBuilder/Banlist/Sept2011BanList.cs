using System;
using System.Collections.Generic;
using DeckBuilderService.Banlist;
using LegacyDeckBuilder.Banlist.Interfaces;
using LegacyDeckBuilder.Models;

namespace LegacyDeckBuilder.Banlist
{
	/// <summary>
	///		Handles the banlist.
	/// </summary>
	/// <remarks>
	///		Effective: Sept 01, 2011 - March 01, 2012
	///		https://yugioh.fandom.com/wiki/September_2011_Lists_(TCG)
	/// </remarks>
	public class Sept2011BanList : IBanList
	{
		public List<BanlistCards> BanList { get; set; }

		/// <summary>
		///		Constructor for <see cref="Sept2011BanList"/>.
		/// </summary>
		public Sept2011BanList() { }

		public bool IsRestricted()
		{
			if(this.BanList == null) { this.BuildBanlist(); }

			throw new NotImplementedException(
				"LegacyDeckBuilder.Banlist.Sept2011BanList.IsRestricted()"
			);
		}

		/// <summary>
		///		Builds the banlist.
		/// </summary>
		public void BuildBanlist()
		{
			this.BanList = new List<BanlistCards>() { };

			// Banned cards
			this.PushCardToBanlist(82301904, Restrictions.Banned); // Chaos Emperor Dragon
			this.PushCardToBanlist(34124316, Restrictions.Banned); // Cyber Jar

			// Limited Cards

			// Semi-Limited cards

			throw new NotImplementedException(
				"Sept2011.cs - BuildBanlist(): Cards in banlist are incomplete."
			);
		}

		/// <summary>
		///		Adds a card to the ban list.
		/// </summary>
		private void PushCardToBanlist(int cardId, Restrictions restrictionStatus)
		{
			if (cardId < 1) { return; }
			if (this.BanList == null) { this.BanList = new List<BanlistCards>(); }

			BanlistCards cardToAdd = new BanlistCards()
			{
				Id = cardId,
				RestrictionStatus = restrictionStatus
			};

			this.BanList.Add(cardToAdd);
		}
	}
}
