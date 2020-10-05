using Invoices.Interfaces;
using Invoices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invoices.Services
{
	public class CompanyService : ICompanyService
	{
		private readonly ICompanyRepository companyRepository;

		public CompanyService(ICompanyRepository companyRepository)
		{
			this.companyRepository = companyRepository;
		}

		public async Task<IEnumerable<Company>> Get()
		{
			return await companyRepository.Get();
		}

		public async Task<Company> Get(int id)
		{
			return await companyRepository.Get(id);
		}

		public async Task Create(Company company)
		{
			await companyRepository.Create(company);
		}

		public async Task Update(int id, Company company)
		{
			await companyRepository.Update(id, company);
		}

		public async Task Delete(int id)
		{
			await companyRepository.Delete(id);
		}
	}
}
