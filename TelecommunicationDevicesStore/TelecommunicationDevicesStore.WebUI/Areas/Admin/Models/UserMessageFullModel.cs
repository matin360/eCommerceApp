using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TelecommunicationDevicesStore.WebUI.Areas.Admin.Models
{
	public class UserMessageFullModel
	{
		public int Id { get; set; }
		public string UserName { get; set; }
		public string UserEmail { get; set; }
		public string UserPhoneNumber { get; set; }
		public string Message { get; set; }
		public DateTime SubmittedDate { get; set; }
	}
}