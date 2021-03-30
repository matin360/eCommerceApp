using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TelecommunicationDevicesStore.WebUI.Areas.Admin.Models
{
	public class ProductFullModel
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string MetaDescription { get; set; }
		public decimal Price { get; set; }
		public int StockCount { get; set; }
		public string CategoryName { get; set; }
	}
}