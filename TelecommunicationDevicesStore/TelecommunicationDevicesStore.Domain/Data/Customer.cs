﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelecommunicationDevicesStore.Domain.Data
{
	public class Customer : User
	{
		public ICollection<Product> Products { get; set; }
		public Customer()
		{
			Products = new HashSet<Product>();
		}
	}
}
