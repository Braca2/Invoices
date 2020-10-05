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
	public class ClientController : ControllerBase
	{
		private readonly IClientService clientService;

		public ClientController(IClientService clientService)
		{
			this.clientService = clientService;
		}

		// GET: api/<ClientController>
		[HttpGet]
		public async Task<IEnumerable<Client>>Get()
		{
			return await clientService.Get();
		}

		// GET api/<ClientController>/5
		[HttpGet("{id}")]
		public async Task<Client> Get(int id)
		{
			return await clientService.Get(id);
		}

		// POST api/<ClientController>
		[HttpPost]
		public async Task Create([FromBody] Client client)
		{
			await clientService.Create(client);
		}

		// PUT api/<ClientController>/5
		[HttpPut("{id}")]
		public async Task Update(int id, [FromBody] Client client)
		{
			await clientService.Update(id, client);
		}

		// DELETE api/<ClientController>/5
		[HttpDelete("{id}")]
		public async Task Delete(int id)
		{
			await clientService.Delete(id);
		}
	}
}
