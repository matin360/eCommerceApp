using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelecommunicationDevicesStore.Domain.Data
{
	public class Service
	{
		[Required]
		public int Id { get; set; }
		[Required]
		[StringLength(maximumLength:50, MinimumLength = 3)]
		public string Name { get; set; }
		[Required]
		[StringLength(maximumLength: 200, MinimumLength = 10)]
		public string Description { get; set; }
		[Required]
		[StringLength(maximumLength: 50, MinimumLength = 3)]
		public string ImagePath { get; set; }
	}
}
