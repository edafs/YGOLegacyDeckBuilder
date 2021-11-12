using System;
using System.Net;
using System.Threading.Tasks;
using LegacyDeckBuilder.Services;
using Microsoft.AspNetCore.Mvc;

namespace LegacyDeckBuilder.Controllers
{
	/// <summary>
	///		The Set Catalog Controller
	/// </summary>
	[Route("api/SetCatalog")]
	public class SetCatalogController : Controller
	{
		/// <summary>
		///     Singleton instance of <see cref="SetCatalogService"/>.
		/// </summary>
		private readonly SetCatalogService CatalogService;

		/// <summary>
		///		Constructor for <see cref="SetCatalogController"/>.
		/// </summary>
		/// <param name="service"></param>
		public SetCatalogController(SetCatalogService service)
		{
			this.CatalogService = service ??
				throw new ArgumentNullException("SetCatalogService not initialized.");
		}

		[HttpPut, Route("RefreshCatalog")]
		public async Task<IActionResult> RefreshCatalog()
		{
			bool wasTaskSucessful = await this.CatalogService.RefreshCatalog();

			if (wasTaskSucessful == false)
			{
				return StatusCode((int)HttpStatusCode.InternalServerError,
					"Unable to refresh the catalog. Please try again another time.");
			}

			return Ok("The set list has been refreshed.");
		}

		/// <summary>
		///		Returns the full set catalog.
		/// </summary>
		[HttpGet, Route("FullSetCatalog")]
		public async Task<IActionResult> GetSetCatalog()
		{
			var setCatalog = await this.CatalogService.GetSetCatalog();

			if (setCatalog == null)
			{
				return StatusCode((int)HttpStatusCode.ServiceUnavailable);
			}

			return Ok(setCatalog);
		}
	}
}
