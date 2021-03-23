using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TelecommunicationDevicesStore.WebUI.Models
{
	public class FeedbackIndexModel
	{
		public string UserName { get; set; }
		public string UserImage { get; set; }
		public int SlideNumber { get; set; }
		public string Message { get; set; }
		public DateTime WrittenDate { get; set; }
	}
}