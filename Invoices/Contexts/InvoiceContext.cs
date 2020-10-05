using Invoices.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invoices.Contexts
{
	public class InvoiceContext : DbContext
	{
		public InvoiceContext(DbContextOptions<InvoiceContext> options) : base(options)
		{
		}

		public DbSet<Client> Clients { get; set; }
		public DbSet<Company> Companies { get; set; }

	}
}
