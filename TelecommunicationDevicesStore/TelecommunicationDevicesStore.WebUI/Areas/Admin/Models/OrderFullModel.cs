using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TelecommunicationDevicesStore.Domain.Data;

namespace TelecommunicationDevicesStore.WebUI.Areas.Admin.Models
{
	public class OrderFullModel
	{
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public decimal TotalPrice { get; set; }
    }
}