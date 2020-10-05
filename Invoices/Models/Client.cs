﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Invoices.Models
{
	public class Client
	{
		[Required]
		public int Id { get; set; }
		[Required]
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Company { get; set; }
		public Address Address { get; set; }
	}
}
