using Invoices.Interfaces;
using Invoices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invoices.Services
{
	public class ClientService : IClientService
	{
		private readonly IClientRepository clientRepository;

		public ClientService(IClientRepository clientRepository)
		{
			this.clientRepository = clientRepository;
		}

		public async Task<IEnumerable<Client>> Get()
		{
			return await clientRepository.Get();
		}

		public async Task<Client> Get(int id)
		{
			return await clientRepository.Get(id);
		}

		public async Task Create(Client client)
		{
			await clientRepository.Create(client);
		}

		public async Task Update(int id, Client client)
		{
			await clientRepository.Update(id, client);
		}

		public async Task Delete(int id)
		{
			await clientRepository.Delete(id);
		}
	}
}
