using Invoices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invoices.Interfaces
{
	public interface ICompanyRepository
	{
		Task<IEnumerable<Company>> Get();
		Task<Company> Get(int id);
		Task Create(Company company);
		Task Update(int id, Company company);
		Task Delete(int id);
	}
}
