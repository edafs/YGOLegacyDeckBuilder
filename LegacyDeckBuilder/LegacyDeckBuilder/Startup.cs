using Amazon;
using Amazon.Extensions.NETCore.Setup;
using LegacyDeckBuilder.Models;
using LegacyDeckBuilder.Repository;
using LegacyDeckBuilder.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LegacyDeckBuilder
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		/// <summary>
		///		This method gets called by the runtime. Use this method to add services to the container.
		/// </summary>
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers();

			// Set Catalog dependencies.
			services.AddTransient<SetCatalogService>();
			services.AddTransient<SetCatalogRepository>();

			// Register Http Clients.
			services.AddHttpClient<WebServices>();

			ConfigureAws(services);
			ConfigureDb(services);
		}

		/// <summary>
		///		This method gets called by the runtime.
		///		Use this method to configure the HTTP request pipeline.
		/// </summary>
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseHttpsRedirection();
			app.UseRouting();
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}

		/// <summary>
		///		Configure some AWS stuff.
		/// </summary>
		private void ConfigureAws(IServiceCollection services)
		{
			services.AddDefaultAWSOptions(
				new AWSOptions
				{
					Region = RegionEndpoint.GetBySystemName("us-east-2")
				}
			); ;
		}

		/// <summary>
		///		Configure database.
		/// </summary>
		private void ConfigureDb(IServiceCollection services)
		{
			string ygoDbConnectionStr = Configuration.GetConnectionString("YgoDbConnection");
			services.AddDbContext<YGOContext>(options =>
			   options.UseMySql(ygoDbConnectionStr, ServerVersion.AutoDetect(ygoDbConnectionStr))
			);
		}
	}
}
