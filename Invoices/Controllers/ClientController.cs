using Invoices.Interfaces;
using Invoices.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Invoices.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ClientController : ControllerBase
	{
		private readonly IClientService clientService;

		public ClientController(IClientService clientService)
		{
			this.clientService = clientService;
		}

		// GET: api/client
		[HttpGet]
		public async Task<IEnumerable<Client>> Get()
		{
			return await clientService.Get();
		}

		// GET api/client/5
		[HttpGet("{id}")]
		public async Task<Client> Get(int id)
		{
			return await clientService.Get(id);
		}

		// POST api/client
		[HttpPost]
		public async Task Create([FromBody] Client client)
		{
			await clientService.Create(client);
		}

		// PUT api/client/5
		[HttpPut("{id}")]
		public async Task Update(int id, [FromBody] Client client)
		{
			await clientService.Update(id, client);
		}

		// DELETE api/client/5
		[HttpDelete("{id}")]
		public async Task Delete(int id)
		{
			await clientService.Delete(id);
		}
	}
}
