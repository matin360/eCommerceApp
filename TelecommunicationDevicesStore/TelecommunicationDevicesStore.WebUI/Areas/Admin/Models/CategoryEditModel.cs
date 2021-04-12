using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TelecommunicationDevicesStore.WebUI.Areas.Admin.Models
{
	public class CategoryEditModel
	{
		[Required]
		[StringLength(maximumLength: 100, MinimumLength = 3)]
		public string Name { get; set; }
	}
}