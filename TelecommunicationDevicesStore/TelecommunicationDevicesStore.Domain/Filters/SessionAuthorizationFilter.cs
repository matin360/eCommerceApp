using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace TelecommunicationDevicesStore.Domain.Filters
{
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
	public class SessionAuthorizationFilter : FilterAttribute, IAuthorizationFilter
	{
		private readonly string _url;
		public SessionAuthorizationFilter(string url)
		{
			_url = url;
		}
		public void OnAuthorization(AuthorizationContext filterContext)
		{
			if (filterContext.HttpContext.Session["user"] == null)
				filterContext.HttpContext.Response.Redirect(_url);
		}
	}
}
