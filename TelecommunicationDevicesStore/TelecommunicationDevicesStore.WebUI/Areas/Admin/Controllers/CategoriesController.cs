using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TelecommunicationDevicesStore.Domain.Data;

namespace TelecommunicationDevicesStore.WebUI.Areas.Admin.Controllers
{
    public class CategoriesController : Controller
    {
        private TelecomStoreDbContext _tsdbcontxt;
        public CategoriesController()
        {
            _tsdbcontxt = new TelecomStoreDbContext();
        }
        // GET: Admin/Category
        public ActionResult Index() => View();
    }
}