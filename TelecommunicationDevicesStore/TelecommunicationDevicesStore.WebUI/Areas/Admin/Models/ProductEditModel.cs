using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TelecommunicationDevicesStore.Domain.Data;

namespace TelecommunicationDevicesStore.WebUI.Areas.Admin.Models
{
	public class ProductEditModel
	{
		public int Id { get; set; }
		[Required]
		[StringLength(maximumLength: 100, MinimumLength = 3)]
		public string Name { get; set; }
		[Required]
		[StringLength(maximumLength: 500, MinimumLength = 20)]
		public string MetaDescription { get; set; }
		[Required]
		public decimal Price { get; set; }
		[Required]
		public int StockCount { get; set; }
		[Required]
		public string CategoryName { get; set; }
		public int CategoryId { get; set; }
		public byte[] ImageData { get; set; }
		public string ImageMimeType { get; set; }
		public IEnumerable<SelectListItem> Categories { get; set; }

		public ProductEditModel()
		{
			Categories = new TelecomStoreDbContext().Categories.Select(x => new SelectListItem
			{
				Text = x.Name,
				Disabled = false,
				Value = x.Name,
				Selected = true
			});
		}

		public ProductEditModel(int id, string metaDescription, string categoryname, string name, decimal price, int stockCount)
		{
			Id = id;
			MetaDescription = metaDescription;
			Price = price;
			StockCount = stockCount;
			CategoryName = categoryname;
			Name = name;
			Categories = new TelecomStoreDbContext().Categories.Select(x => new SelectListItem
			{
				Text = x.Name,
				Disabled = false,
				Value = x.Name,
				Selected = true
			});
		}
	}
}