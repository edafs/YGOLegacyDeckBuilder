namespace LegacyDeckBuilder.Banlist.Interfaces
{
	public interface IBanList
	{
		/// <summary>
		///		Builds the banlist
		/// </summary>
		public void BuildBanlist();

		/// <summary>
		///		Checks if the card is restricted
		/// </summary>
		public bool IsRestricted();
	}
}
