using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TelecommunicationDevicesStore.Domain.Data;
using TelecommunicationDevicesStore.WebUI.Infrastructure;
using TelecommunicationDevicesStore.WebUI.Models;

namespace TelecommunicationDevicesStore.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private TelecomStoreDbContext _tsdbcontxt;
		public HomeController()
		{
            _tsdbcontxt = new TelecomStoreDbContext();
		}
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Menus()
		{
            return View(_tsdbcontxt.GetAllMenus());
		}

        public ActionResult Categories()
		{
            return View(_tsdbcontxt.GetAllCategories());
		}
    }
}