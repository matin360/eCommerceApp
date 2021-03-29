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
		[StringLength(maximumLength: 50)]
		public string Picture { get; set; }
		public Customer()
		{
			Picture = "default.jpg";
		}
	}
}
