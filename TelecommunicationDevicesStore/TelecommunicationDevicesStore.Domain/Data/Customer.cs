using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelecommunicationDevicesStore.Domain.Data
{
	public class Customer : User
	{
		[Required]
		[StringLength(maximumLength: 20, MinimumLength = 6)]
		public string Password { get; set; }
		public ICollection<Product> Products { get; set; }
		public Customer()
		{
			Products = new HashSet<Product>();
		}
	}
}
