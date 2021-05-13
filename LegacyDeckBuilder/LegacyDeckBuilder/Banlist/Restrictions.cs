namespace DeckBuilderService.Banlist
{
    public enum Restrictions
    {
        /// <summary>
        ///     Card is not allowed in specified format.
        /// </summary>
        Banned = 0,

        /// <summary>
        ///     Up to one copy of a card is allowed in specified format.
        /// </summary>
        Limited = 1,

        /// <summary>
        ///     Up to two copies of a card is allowed in specified format.
        /// </summary>
        SemiLimited = 2,

        /// <summary>
        ///     Up to three copies of a card is allowed in a specified format.
        /// </summary>
        Unlimited = 3,

        /// <summary>
        ///     Card is not in the pool for a specified format.
        /// </summary>
        NotLegal = 4,

        /// <summary>
        ///     Konami has deemed the card is not allowed in play.
        /// </summary>
        Illegal = 5,

        /// <summary>
        ///     Card status is disputed.
        /// </summary>
        Disputed = 6
    }
}
