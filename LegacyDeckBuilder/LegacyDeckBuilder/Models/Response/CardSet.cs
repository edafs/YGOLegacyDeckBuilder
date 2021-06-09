using System.Text.Json.Serialization;

namespace LegacyDeckBuilder.Models.Response
{
    /// <summary>
    ///     Response models for the card sets.
    /// </summary>
    /// <remarks>
    ///     https://db.ygoprodeck.com/api/v7/cardsets.php
    /// </remarks>
    public class CardSet
    {
        /// <summary>
        ///     The name of the set.
        /// </summary>
        [JsonPropertyName("set_name")]
        public string SetName { get; set; }

        /// <summary>
        ///     The set code.
        /// </summary>
        [JsonPropertyName("set_code")]
        public string SetCode { get; set; }

        /// <summary>
        ///     The number of cards in a set.
        /// </summary>
        [JsonPropertyName("num_of_cards")]
        public int CardCount { get; set; }

        /// <summary>
        ///     The release date of the TCG.
        /// </summary>
        [JsonPropertyName("tcg_date")]
        public string ReleaseDate { get; set; }
    }
}