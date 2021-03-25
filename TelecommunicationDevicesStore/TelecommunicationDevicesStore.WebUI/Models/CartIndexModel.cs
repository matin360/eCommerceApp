using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TelecommunicationDevicesStore.Domain.Data;

namespace TelecommunicationDevicesStore.WebUI.Models
{
	public class CartIndexModel
	{
		public Cart Cart { get; set; }
		public string ReturnUrl { get; set; }
	}
}