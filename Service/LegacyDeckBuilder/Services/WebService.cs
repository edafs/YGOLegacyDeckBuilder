using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using LegacyDeckBuilder.Models.Response;

namespace LegacyDeckBuilder.Services
{
	/// <summary>
	///		Makes HTTP requests.
	/// </summary>
	public class WebService
	{
		/// <summary>
		///		An instance of <see cref="HttpClient"/>.
		/// </summary>
		public readonly HttpClient HttpWebClient;

		/// <summary>
		///		Instance of <see cref="WebServices"/>
		/// </summary>
		public WebService(HttpClient httpWebClient)
		{
			this.HttpWebClient = httpWebClient;
		}

		/// <summary>
		///		Sends a HTTP GET request to get the
		///		card sets from the YGOPRO Api.
		/// </summary>
		public async Task<List<T>> CardSetFromYGOService<T>(string uri)
		{
			if (string.IsNullOrWhiteSpace(uri))
			{
				return new List<T>();
			}

			string response = await this.HttpWebClient.GetStringAsync(uri);
			List<T> results = JsonSerializer.Deserialize<List<T>>(response);

			return results;
		}

		/// <summary>
		///		Sends a HTTP Get request to get the
		///		card catalog from the YGOPRO api.
		/// </summary>
		public async Task<List<CardInfo>> CardCatalogFromYgoService(string uri)
		{
			if (string.IsNullOrWhiteSpace(uri))
			{
				return new List<CardInfo>();
			}

			string response = await this.HttpWebClient.GetStringAsync(uri);
			var payload = JsonSerializer.Deserialize<CardInfoPayload>(response);

			if(payload.CardCatalog != null && payload.CardCatalog.Count != 0)
			{
				return payload.CardCatalog;
			}

			return new List<CardInfo>();
		}
	}
}
