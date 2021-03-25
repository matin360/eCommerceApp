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
    [Obsolete]
    public class SignUpController : Controller
    {
        private TelecomStoreDbContext _tsdbcontxt;
        public SignUpController()
        {
            _tsdbcontxt = new TelecomStoreDbContext();
        }
        // GET: SignUp
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserModel model)
        {
            return View();
        }
    }
}