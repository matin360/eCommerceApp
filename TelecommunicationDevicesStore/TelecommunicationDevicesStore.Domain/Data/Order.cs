using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelecommunicationDevicesStore.Domain.Data
{
	public class Order
	{
		public int Id { get; set; }
        [Required()]
        [StringLength(maximumLength: 100, MinimumLength = 5)]
        public string Line1 { get; set; }
        [StringLength(maximumLength: 100, MinimumLength = 5)]
        public string Line2 { get; set; }
        [StringLength(maximumLength: 100, MinimumLength = 5)]
        public string Line3 { get; set; }
        [Required()]
        [StringLength(maximumLength: 100, MinimumLength = 2)]
        public string City { get; set; }
        [Required()]
        [StringLength(maximumLength: 100, MinimumLength = 2)]
        public string Country { get; set; }
        [DataType("varchar")]
        public bool GiftWrap { get; set; }
        [Required]
        public decimal TotalPrice { get; set; }
        public Customer User { get; set; }
        [Required]
        public int UserId { get; set; }

		public ICollection<CartLine> CartLines { get; set; }
	}
}
