namespace DeckBuilderService.Banlist
{
    public enum Restrictions
    {
        /// <summary>
        ///     Card is not allowed in specified format.
        /// </summary>
        Banned = 1,

        /// <summary>
        ///     Up to one copy of a card is allowed in specified format.
        /// </summary>
        Limited = 2,

        /// <summary>
        ///     Up to two copies of a card is allowed in specified format.
        /// </summary>
        SemiLimited = 3,

        /// <summary>
        ///     Up to three copies of a card is allowed in a specified format.
        /// </summary>
        Unlimited = 4,

        /// <summary>
        ///     Card is not in the pool for a specified format.
        /// </summary>
        NotLegal = 5,

        /// <summary>
        ///     Konami has deemed the card is not allowed in play.
        /// </summary>
        Illegal = 6,

        /// <summary>
        ///     Card status is disputed.
        /// </summary>
        Disputed = 7
    }
}
