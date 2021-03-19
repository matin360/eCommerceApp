using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelecommunicationDevicesStore.Domain.Roles;

namespace TelecommunicationDevicesStore.Domain.Data
{
	public class SystemUser : User
	{
		[Required]
		public UserRole UserRole { get; set; }
	}
}
