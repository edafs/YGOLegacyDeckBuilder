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
		public WebServices WebService
		{
			get
			{
				HttpClient httpClient = new HttpClient();
				return new WebServices(httpClient);
			}
		}

		[Fact]
		public void SendCanGetCardSets()
		{
			WebServices service = this.WebService;

			List<CardSet> response = service
				.SendGetRequest<CardSet>("https://db.ygoprodeck.com/api/v7/cardsets.php")
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
	}
}
