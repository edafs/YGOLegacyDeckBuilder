using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace LegacyDeckBuilder.Models.Response
{
	/// <summary>
	///		The information of a card from the YGODB.
	/// </summary>
	///	<remarks>
	///		https://db.ygoprodeck.com/api/v7/cardinfo.php
	/// </remarks>
	public class CardInfo
	{
		[JsonPropertyName("id")]
		public int Id { get; set; }

		[JsonPropertyName("name")]
		public string Name { get; set; }

		[JsonPropertyName("card_images")]
		public List<CardImages> Images {get;set;}
	}

	/// <summary>
	///		A nested body of images in a card.
	/// </summary>
	public class CardImages
	{
		[JsonPropertyName("id")]
		public int ImageId { get; set; }

		[JsonPropertyName("image_url")]
		public string FullImage { get; set; }

		[JsonPropertyName("image_url_small")]
		public string Thumbnail { get; set; }
	}
}
