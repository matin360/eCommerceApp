﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TelecommunicationDevicesStore.WebUI.Models
{
	public class ProductDetailsModel
	{
		public string Name { get; set; }
		public string MetaDescription { get; set; }
		public decimal Price { get; set; }
		public string ImagePath { get; set; }
		public int StockCount { get; set; }
		public string CategoryName { get; set; }
	}
}