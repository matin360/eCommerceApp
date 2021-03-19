using System.ComponentModel.DataAnnotations;

namespace TelecommunicationDevicesStore.Domain.Data
{
	public class User
	{
		[Required]
		public int Id { get; set; }
		[Required]
		[StringLength(maximumLength: 70, MinimumLength = 2)]
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