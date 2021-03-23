using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TelecommunicationDevicesStore.Domain.Data;
using TelecommunicationDevicesStore.WebUI.Models;
using TelecommunicationDevicesStore.WebUI.Infrastructure;

namespace TelecommunicationDevicesStore.WebUI.Controllers
{

    public class AccountController : Controller
    {
        private TelecomStoreDbContext _tsdbcontxt;
        public AccountController()
        {
            _tsdbcontxt = new TelecomStoreDbContext();
        }
        // GET: Account
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(UserModel model)
        {
            return View();
        }
    }
}