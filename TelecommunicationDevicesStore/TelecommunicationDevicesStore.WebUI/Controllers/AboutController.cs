using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TelecommunicationDevicesStore.Domain.Data;

namespace TelecommunicationDevicesStore.WebUI.Controllers
{
    public class AboutController : Controller
    {
        private TelecomStoreDbContext _tsdbcontxt;
        public AboutController()
        {
            _tsdbcontxt = new TelecomStoreDbContext();
        }
        // GET: About
        public ActionResult Index() => View();
    }
}