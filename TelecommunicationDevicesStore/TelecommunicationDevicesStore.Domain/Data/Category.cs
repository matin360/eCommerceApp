using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelecommunicationDevicesStore.Domain.Data
{
	public class Category
	{
		[Required]
		public int Id { get; set; }
		[Required]
		[StringLength(maximumLength: 100, MinimumLength = 3)]
		public string Name { get; set; }
		public ICollection<Product> Products { get; set; }
		public Category()
		{
			Products = new HashSet<Product>();
		}
	}
}
