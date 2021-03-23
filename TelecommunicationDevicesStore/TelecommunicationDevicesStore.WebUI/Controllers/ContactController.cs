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
    public class ContactController : Controller
    {
        private TelecomStoreDbContext _tsdbcontxt;
        public ContactController()
        {
            _tsdbcontxt = new TelecomStoreDbContext();
        }
        // GET: Contact
        public ActionResult Index()
        {
            return View();
        }
    }
}