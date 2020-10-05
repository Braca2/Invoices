using Invoices.Contexts;
using Invoices.Interfaces;
using Invoices.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invoices.Repositories
{
	public class CompanyRepository : ICompanyRepository
	{
		private readonly InvoiceContext context;

		public CompanyRepository(InvoiceContext context)
		{
			this.context = context;
		}

		public async Task<IEnumerable<Company>> Get()
		{
			return await context.Companies.ToListAsync();
		}

		public async Task<Company> Get(int id)
		{
			return await context.Companies.FindAsync(id);
		}

		public async Task Create(Company company)
		{
			context.Companies.Add(company);
			await context.SaveChangesAsync();
		}

		public async Task Update(int id, Company company)
		{
			context.Entry(company).State = EntityState.Modified;
			await context.SaveChangesAsync();
		}

		public async Task Delete(int id)
		{
			context.Companies.Remove(Get(id).Result);
			await context.SaveChangesAsync();
		}
	}
}
