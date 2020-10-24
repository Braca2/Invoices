using Invoices.Contexts;
using Invoices.Interfaces;
using Invoices.Repositories;
using Invoices.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
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
			services.AddCors(options =>
			{
				options.AddDefaultPolicy(
						builder =>
						{
							builder.WithOrigins("http://localhost:8080",
								"http://127.0.0.1:8080");
						});
			});

			services.AddControllers();
			services.AddDbContext<InvoiceContext>(clients => clients.UseSqlServer(Configuration.GetConnectionString("AppConnection")));

			//services.AddSingleton<IPlaceInfoService, PlaceInfoService>();
			services.AddSwaggerGen(options =>
			{
				options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
				{
					Title = "Invoices API",
					Version = "v1",
					Description = "Invoices backend",
				});
			});

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

			app.UseDefaultFiles();
			app.UseStaticFiles();

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseCors();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});

			app.UseSwagger();
			app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v1/swagger.json", "Invoice Services"));
		}
	}
}
