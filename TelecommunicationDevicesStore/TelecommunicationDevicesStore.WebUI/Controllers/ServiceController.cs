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
    public class ServiceController : Controller
    {
        private TelecomStoreDbContext _tsdbcontxt;
        public ServiceController()
        {
            _tsdbcontxt = new TelecomStoreDbContext();
        }
        // GET: Service
        public ActionResult Services() => View(_tsdbcontxt.GetAllServices());
    }
}