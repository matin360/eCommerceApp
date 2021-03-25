using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TelecommunicationDevicesStore.WebUI.Models
{
	public class PageModel
	{
		public int Page { get; set; } = 1;
		public int ElementsCount { get; set; }
		public string ActionName { get; set; }
		public string ControllerName { get; set; }
		public string CategoryName { get; set; }
	}
}