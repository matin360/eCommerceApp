using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TelecommunicationDevicesStore.WebUI.Models
{
	public class LoginModel
	{
		[Required]
		[EmailAddress]
		public string Email { get; set; }
		[Required]
		[DataType(DataType.Password)]
		[StringLength(maximumLength: 30, MinimumLength = 7)]
		public string Password { get; set; }
	}
}