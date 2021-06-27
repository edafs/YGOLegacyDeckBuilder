using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace LegacyDeckBuilder.Services
{
	/// <summary>
	///		Makes HTTP requests.
	/// </summary>
	public class WebServices
	{
		/// <summary>
		///		An instance of <see cref="HttpClient"/>.
		/// </summary>
		public readonly HttpClient HttpWebClient;

		/// <summary>
		///		Instance of <see cref="WebServices"/>
		/// </summary>
		public WebServices(HttpClient httpWebClient)
		{
			this.HttpWebClient = httpWebClient;
		}

		/// <summary>
		///		Sends a HTTP GET request.
		/// </summary>
		public async Task<List<T>> SendGetRequest<T>(string uri)
		{
			if (string.IsNullOrWhiteSpace(uri))
			{
				return new List<T>();
			}

			string response = await this.HttpWebClient.GetStringAsync(uri);
			List<T> results = JsonSerializer.Deserialize<List<T>>(response);

			return results;
		}
	}
}
