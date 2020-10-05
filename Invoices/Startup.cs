using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Invoices.Contexts;
using Invoices.Interfaces;
using Invoices.Models;
using Invoices.Repositories;
using Invoices.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Invoices
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
			services.AddControllers();
			services.AddDbContext<InvoiceContext>(clients => clients.UseSqlServer(Configuration.GetConnectionString("AppConnection")));

			services.AddTransient<IClientService, ClientService>();
			services.AddTransient<ICompanyService, CompanyService>();

			services.AddTransient<IClientRepository, ClientRepository>();
			services.AddTransient<ICompanyRepository, CompanyRepository>();
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
		}
	}
}
