using Invoices.Interfaces;
using Invoices.Models;
using System.Collections.Generic;
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
			//Check if already exists
			//if has the same First Name and Last Name or Company, ask if it is the same client
			//should I return OK or something?
			await clientRepository.Create(client);
		}

		public async Task Update(int id, Client client)
		{
			//check if exists
			//should I return OK or something?
			await clientRepository.Update(id, client);
		}

		public async Task Delete(int id)
		{
			await clientRepository.Delete(id);
		}
	}
}
