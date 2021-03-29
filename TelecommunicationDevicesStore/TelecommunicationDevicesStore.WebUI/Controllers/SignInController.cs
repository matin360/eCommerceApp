using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TelecommunicationDevicesStore.Domain.Data;
using TelecommunicationDevicesStore.WebUI.Models;
using TelecommunicationDevicesStore.WebUI.Infrastructure;
using System.Threading.Tasks;

namespace TelecommunicationDevicesStore.WebUI.Controllers
{
    public class SignInController : Controller
    {
        private TelecomStoreDbContext _tsdbcontxt;
        public SignInController()
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
        [ValidateAntiForgeryToken]
        [ActionName("Login")]
        public async Task<ActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                if (ModelState.IsValid)
                {
                    var user = await _tsdbcontxt.Customers.GetUserAsync(model);

                    if (user == null)
                    {
                        ModelState.AddModelError("", "This user does not exist! Email or password is wrong!");
                        return View();
                    }
                    else
                    {
                        Session.Add("customer", user.Id);
                        return RedirectToAction("Index", "Home");
                    }
                }
                return View();
            }
            return View();
        }
    }
}