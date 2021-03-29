using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelecommunicationDevicesStore.WebUI.Models
{
	public class ShippingDetails
	{
        [Required(ErrorMessage = "Indicate your address")]
        [Display(Name = "First line for an address")]
        public string Line1 { get; set; }
        [Display(Name = "Second line for an address")]
        public string Line2 { get; set; }
        [Display(Name = "Third line for an address")]
        public string Line3 { get; set; }

        [Required(ErrorMessage = "Indicate your city")]
        [Display(Name = "City")]
        public string City { get; set; }

        [Required(ErrorMessage = "Indicate your country")]
        [Display(Name = "Country")]
        public string Country { get; set; }

        public bool GiftWrap { get; set; }
		public int UserId { get; set; }
	}
}
