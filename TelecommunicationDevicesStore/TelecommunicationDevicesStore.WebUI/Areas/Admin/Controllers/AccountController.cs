using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TelecommunicationDevicesStore.Domain.Data;
using TelecommunicationDevicesStore.WebUI.Areas.Admin.Data;
using TelecommunicationDevicesStore.WebUI.Infrastructure;

namespace TelecommunicationDevicesStore.WebUI.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        private TelecomStoreDbContext _tsdbcontxt;
        public AccountController()
        {
            _tsdbcontxt = new TelecomStoreDbContext();
        }
        // GET: Admin/Account
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Login")]
        public async Task<ActionResult> LoginAsync(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                if (ModelState.IsValid)
                {
                    var user = await _tsdbcontxt.SystemUsers.GetUserAsync(model);

                    if (user == null)
                    {
                        ModelState.AddModelError("", "This user does not exist! Email or password is wrong!");
                        return View();
                    }
                    else
                    {
                        Session.Add("user", user.Id);
                        return RedirectToAction("Index", "Dashboard");
                    }
                }
                return View();
            }
            return View();
        }

        [HttpGet]
        public ActionResult Logout()
        {
            Session.Remove("user");
            return RedirectToAction(nameof(Login));
        }
    }
}