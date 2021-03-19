using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelecommunicationDevicesStore.Domain.Data
{
	public class Menu
	{
		[Required]
		public int Id { get; set; }
		[Required]
		[StringLength(maximumLength:40, MinimumLength =3)]
		public string Name { get; set; }
		[Required]
		[StringLength(maximumLength: 30, MinimumLength = 3)]
		public string ControllerName { get; set; }
		[Required]
		[StringLength(maximumLength: 30, MinimumLength = 3)]
		public string ActionName { get; set; }
		[Required]
		public bool IsActive { get; set; }
	}
}
