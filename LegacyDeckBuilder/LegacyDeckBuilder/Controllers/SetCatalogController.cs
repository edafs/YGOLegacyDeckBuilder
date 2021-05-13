using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using LegacyDeckBuilder.Services;
using Microsoft.AspNetCore.Mvc;

namespace LegacyDeckBuilder.Controllers
{
	/// <summary>
	///		The Set Catalog Controller
	/// </summary>
	[Route("SetCatalog")]
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
