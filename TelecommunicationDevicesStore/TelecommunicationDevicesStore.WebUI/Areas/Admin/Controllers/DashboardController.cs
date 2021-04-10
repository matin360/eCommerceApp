using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TelecommunicationDevicesStore.Domain.Data;
using TelecommunicationDevicesStore.Domain.Filters;
using TelecommunicationDevicesStore.WebUI.Infrastructure;

namespace TelecommunicationDevicesStore.WebUI.Areas.Admin.Controllers
{
    public class DashboardController : Controller
    {
        private TelecomStoreDbContext _tsdbcontxt;
        public DashboardController()
        {
            _tsdbcontxt = new TelecomStoreDbContext();
        }
        // GET: Admin/Dashboard
        [HttpGet]
		[SessionAuthorizationFilter("/Admin/Account/Login")]
		public ActionResult Index() => View(_tsdbcontxt.GetElementsCounts());

		[HttpGet]
		[SessionAuthorizationFilter("/Admin/Account/Login")]
		[ActionName("Customers")]
		public async Task<ActionResult> CustomersAsync() => View(await _tsdbcontxt.GetAllCustomers());

		[HttpGet]
		[SessionAuthorizationFilter("/Admin/Account/Login")]
		[ActionName("UserMessages")]
		public async Task<ActionResult> UserMessagesAsync() => View(await _tsdbcontxt.GetAllUserMessages());
	}
}