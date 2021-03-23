using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TelecommunicationDevicesStore.Domain.Data;
using TelecommunicationDevicesStore.WebUI.Infrastructure;

namespace TelecommunicationDevicesStore.WebUI.Controllers
{
    public class MenuController : Controller
    {
        private TelecomStoreDbContext _tsdbcontxt;
        public MenuController()
        {
            _tsdbcontxt = new TelecomStoreDbContext();
        }
        // GET: Menu
        public ActionResult Menus()
        {
            return View(_tsdbcontxt.GetAllMenus());
        }
    }
}