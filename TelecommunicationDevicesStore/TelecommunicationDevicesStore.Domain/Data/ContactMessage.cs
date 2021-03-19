using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelecommunicationDevicesStore.Domain.Data
{
	public class ContactMessage
	{
		[Required]
		public int Id { get; set; }
		[Required]
		[StringLength(maximumLength: 70, MinimumLength = 2)]
		public string UserName { get; set; }
		[Required]
		[EmailAddress]
		public string UserEmail { get; set; }
		[Required]
		[Phone]
		public string UserPhoneNumber { get; set; }
		[Required]
		[StringLength(maximumLength: 300, MinimumLength = 5)]
		public string Message { get; set; }
		[Required]
		[DataType("smalldatetime")]
		public DateTime SubmittedDate { get; set; }
		public User User { get; set; }
		[Required]
		public int UserId { get; set; }
		
	}
}
