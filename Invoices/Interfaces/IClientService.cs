using Invoices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invoices.Interfaces
{
	public interface IClientService
	{
		Task<IEnumerable<Client>> Get();
		Task<Client> Get(int id);
		Task Create(Client client);
		Task Update(int id, Client client);
		Task Delete(int id);
	}
}
