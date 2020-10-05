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
	public class ClientRepository : IClientRepository
	{
		private readonly InvoiceContext context;

		public ClientRepository(InvoiceContext context)
		{
			this.context = context;
		}

		public async Task<IEnumerable<Client>> Get()
		{
			return await context.Clients.ToListAsync();
		}

		public async Task<Client> Get(int id)
		{
			return await context.Clients.FindAsync(id);
		}

		public async Task Create(Client client)
		{
			context.Clients.Add(client);
			await context.SaveChangesAsync();
		}

		public async Task Update(int id, Client client)
		{
			context.Entry(client).State = EntityState.Modified;
			await context.SaveChangesAsync();
		}

		public async Task Delete(int id)
		{
			context.Clients.Remove(Get(id).Result);
			await context.SaveChangesAsync();
		}
	}
}
