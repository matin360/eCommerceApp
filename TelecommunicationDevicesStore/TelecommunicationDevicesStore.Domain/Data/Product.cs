﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelecommunicationDevicesStore.Domain.Data
{
	public class Product
	{
		[Required]
		public int Id { get; set; }
		[Required]
		[StringLength(maximumLength:100, MinimumLength =3)]
		public string Name { get; set; }
		[Required]
		[StringLength(maximumLength: 500, MinimumLength = 20)]
		public string MetaDescription { get; set; }
		[Required]
		[Range(0.1, 10000.00,
			ErrorMessage = "Price must be between 0.01 and 10000.00")]
		public decimal Price { get; set; }
		[Required]
		public byte[] ImageData { get; set; }
		public string ImageMimeType { get; set; }
		[Required]
		[Range(0, 100000,
			ErrorMessage = "Number of products must be between 0 and 100000")]
		public int StockCount { get; set; }
		public Category Category { get; set; }
		[Required]
		public int CategoryId { get; set; }
	}
}
