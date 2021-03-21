using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TelecommunicationDevicesStore.WebUI.Models
{
	public class CarouselItemIndexModel
	{
		public string ImagePath { get; set; }
		public string Heading { get; set; }
		public string Description { get; set; }
		public string TextLink { get; set; }
		public string ActionLink { get; set; }
		public string ControllerLink { get; set; }
		public string SlideNumber { get; set; }
	}
}