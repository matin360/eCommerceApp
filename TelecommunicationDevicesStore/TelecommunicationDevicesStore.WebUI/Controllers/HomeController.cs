using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TelecommunicationDevicesStore.Domain.Data;
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
            var menus = _tsdbcontxt.Menus.Where(m => m.IsActive).Select(m => new MenuIndexModel
            {
                Name = m.Name,
                ControllerName = m.ControllerName,
                ActionName = m.ActionName
            }).ToList();
            return View(menus);
		}

        public ActionResult Categories()
		{
            var categories = _tsdbcontxt.Categories.Select(cat => new CategoryIndexModel
            {
                Name = cat.Name
            }).ToList();
            return View(categories);
		}
    }
}