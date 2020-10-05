using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Invoices.Models
{
	public class Company
	{
		[Required]
		public int Id { get; set; }
		[Required]
		public string CompanyName { get; set; }
		public string PhoneNumber { get; set; }
		public string Email { get; set; }
		public Address Address { get; set; }
		public string TaxName { get; set; }
		public int TaxNumber { get; set; }
	}
}
