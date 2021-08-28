using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using LegacyDeckBuilder.Models.Response;
using LegacyDeckBuilder.Services;
using Xunit;

namespace LegacyDeckBuilder.Tests
{
	public class WebServicesTests
	{
		/// <summary>
		///		Gets an initialized instance of <see cref="WebServices"/>.
		/// </summary>
		public WebService WebService
		{
			get
			{
				HttpClient httpClient = new HttpClient();
				return new WebService(httpClient);
			}
		}

		[Fact]
		public void CanGetCardSets()
		{
			WebService service = this.WebService;

			List<CardSet> response = service
				.CardSetFromYGOService<CardSet>("https://db.ygoprodeck.com/api/v7/cardsets.php")
				.Result;

			CardSet cyberneticRevolution = response.FirstOrDefault(
				set => string.Equals(set.SetCode, "CRV", StringComparison.InvariantCultureIgnoreCase)
			);

			Assert.True(response.Count > 850);

			Assert.True(string.Equals(
				cyberneticRevolution.ReleaseDate,
				"2005-08-17",
				StringComparison.InvariantCultureIgnoreCase)
			);
		}

		[Fact]
		public void CanGetCardCatalog()
		{
			WebService service = this.WebService;

			List<CardInfo> response = service
				.CardCatalogFromYgoService("https://db.ygoprodeck.com/api/v7/cardinfo.php?archetype=Blue-Eyes")
				.Result;

			Assert.True(response.Count > 30);

			CardInfo blueEyes = response.FirstOrDefault(card =>
				string.Equals(card.Name, "Blue-Eyes White Dragon", StringComparison.InvariantCultureIgnoreCase)
			);

			Assert.Contains("https://storage.googleapis.com/ygoprodeck.com/pics_small/",
				blueEyes.Images.FirstOrDefault().Thumbnail);

			Assert.Contains("https://storage.googleapis.com/ygoprodeck.com/pics/",
				blueEyes.Images.FirstOrDefault().FullImage);
		}
	}
}
