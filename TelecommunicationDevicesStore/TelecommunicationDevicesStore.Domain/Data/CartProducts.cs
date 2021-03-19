using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelecommunicationDevicesStore.Domain.Data
{
	public class CartProducts
	{
		[Required]
		public int Id { get; set; }
		public User User { get; set; }
		[Required]
		public int UserId { get; set; }
		public ICollection<Product> Products { get; set; }
		public CartProducts()
		{
			Products = new HashSet<Product>();
		}
	}
}
