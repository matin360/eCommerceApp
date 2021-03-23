using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TelecommunicationDevicesStore.WebUI.Models
{
	public class UserModel
	{
		public string UserName { get; set; }
		[Required]
		[StringLength(maximumLength: 50)]
		[EmailAddress]
		public string Email { get; set; }
		[Required]
		[StringLength(maximumLength: 20, MinimumLength = 6)]
		public string Password { get; set; }
	}
}