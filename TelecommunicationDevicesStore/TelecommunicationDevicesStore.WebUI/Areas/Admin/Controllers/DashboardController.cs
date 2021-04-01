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
        //[SessionAuthorizationFilter("/Admin/Account/Login")]
        public ActionResult Index()
        {
            return View();
        }

		[HttpGet]
		[ActionName("Customers")]
		public async Task<ActionResult> CustomersAsync()
		{
			return View(await _tsdbcontxt.GetAllCustomers());
		}

		[HttpGet]
		[ActionName("UserMessages")]
		public async Task<ActionResult> UserMessagesAsync()
		{
			return View(await _tsdbcontxt.GetAllUserMessages());
		}
	}
}