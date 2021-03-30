using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace TelecommunicationDevicesStore.Domain.Filters
{
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
	public class UserAuthorizationFilter : FilterAttribute, IAuthorizationFilter
	{
		public void OnAuthorization(AuthorizationContext filterContext)
		{
			if (filterContext.HttpContext.Session["customer"] == null)
				(filterContext.Controller as Controller).ModelState.AddModelError("login", "You have to sign in before!");
		}
	}
}
