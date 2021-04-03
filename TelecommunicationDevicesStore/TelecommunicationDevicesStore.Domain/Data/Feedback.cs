using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelecommunicationDevicesStore.Domain.Data
{
	public class Feedback { 
		[Required]
		public int Id { get; set; }
		[Required]
		[StringLength(maximumLength: 70, MinimumLength = 2)]
		public string UserName { get; set; }
		[Required]
		[Range(0, 5)]
		public int SlideNumber { get; set; }
		[Required]
		[StringLength(maximumLength: 300, MinimumLength = 5)]
		public string Message { get; set; }
		[Required]
		[DataType("smalldatetime")]
		public DateTime WrittenDate { get; set; }
		public User Customer { get; set; }
		[Required]
		public int CustomerId { get; set; }
	}
}
