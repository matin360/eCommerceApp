using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TelecommunicationDevicesStore.Domain.Filters;

namespace TelecommunicationDevicesStore.WebUI.Areas.Admin.Controllers
{
    public class DashboardController : Controller
    {
		// GET: Admin/Dashboard
		[SessionAuthorizationFilter("/Admin/Account/Login")]
		public ActionResult Index()
        {
            return View();
        }
    }
}