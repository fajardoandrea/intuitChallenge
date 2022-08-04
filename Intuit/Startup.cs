using Intuit.Business;
using Intuit.Business.Contracts;
using Intuit.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.OpenApi.Models;

namespace Intuit
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<DBConnection>(options => options.UseSqlServer(Configuration.GetConnectionString("Intuit")));
			services.AddScoped<IClientService, ClientService>();
			services.AddControllers();
			services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
			AddSwagger(services);
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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

			app.UseSwagger();
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "Intuit Challenge API V1");
			});
		}

		private void AddSwagger(IServiceCollection services)
		{
			services.AddSwaggerGen(options =>
			{
				var groupName = "v1";

				options.SwaggerDoc(groupName, new OpenApiInfo
				{
					Title = $"Intuit Challenge {groupName}",
					Version = groupName,
					Description = "Intuit Challenge API"
				});
			});
		}
	}
}
