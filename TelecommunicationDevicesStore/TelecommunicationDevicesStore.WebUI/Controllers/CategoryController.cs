using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TelecommunicationDevicesStore.Domain.Data;
using TelecommunicationDevicesStore.WebUI.Infrastructure;

namespace TelecommunicationDevicesStore.WebUI.Controllers
{
    public class CategoryController : Controller
    {
        private TelecomStoreDbContext _tsdbcontxt;
        public CategoryController()
        {
            _tsdbcontxt = new TelecomStoreDbContext();
        }
        // GET: Category
        public ActionResult Categories()
        {
            return View(_tsdbcontxt.GetAllCategories());
        }
    }
}