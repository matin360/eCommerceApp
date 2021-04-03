using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelecommunicationDevicesStore.Domain.Data
{
    [Table("CartProductsQuantity")]
    public class CartLine
    {
        public int Id { get; set; }
        //public Product Product { get; set; }
        //[Required]
        //public int ProductId { get; set; }
        public Order Order { get; set; }
        [Required]
        public int OrderId { get; set; }
        [Required]
        public int Quantity { get; set; }
	}
}
