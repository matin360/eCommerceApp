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
		public decimal Price { get; set; }
		public byte[] ImageData { get; set; }
		public string ImageMimeType { get; set; }
		public string CategoryName { get; set; }
	}
}