using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TelecommunicationDevicesStore.WebUI.Areas.Admin.Models
{
	public class CategoryFullModel
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int ProductsCount { get; set; }
	}
}