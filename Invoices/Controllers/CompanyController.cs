using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Invoices.Interfaces;
using Invoices.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Invoices.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CompanyController : ControllerBase
	{
		private readonly ICompanyService companyService;

		public CompanyController(ICompanyService companyService)
		{
			this.companyService = companyService;
		}

		// GET: api/<CompanyController>
		[HttpGet]
		public async Task<IEnumerable<Company>> Get()
		{
			return await companyService.Get();
		}

		// GET api/<CompanyController>/5
		[HttpGet("{id}")]
		public async Task<Company> Get(int id)
		{
			return await companyService.Get(id);
		}

		// POST api/<CompanyController>
		[HttpPost]
		public async Task Create([FromBody] Company company)
		{
			await companyService.Create(company);
		}

		// PUT api/<CompanyController>/5
		[HttpPut("{id}")]
		public async Task Update(int id, [FromBody] Company company)
		{
			await companyService.Update(id, company);
		}

		// DELETE api/<CompanyController>/5
		[HttpDelete("{id}")]
		public async void Delete(int id)
		{
			await companyService.Delete(id);
		}
	}
}
