using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TelecommunicationDevicesStore.Domain.Data;

namespace TelecommunicationDevicesStore.WebUI.Models
{
	public class ProductIndexModel
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string ShorDescription { get; set; }
		public decimal Price { get; set; }
		public string ImagePath { get; set; }
		public int CustomersCount { get; set; }
	}
}