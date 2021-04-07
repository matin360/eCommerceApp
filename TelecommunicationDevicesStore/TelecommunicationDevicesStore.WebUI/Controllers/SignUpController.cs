using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TelecommunicationDevicesStore.Domain.Data;
using TelecommunicationDevicesStore.WebUI.Infrastructure;
using TelecommunicationDevicesStore.WebUI.Models;

namespace TelecommunicationDevicesStore.WebUI.Controllers
{
    public class SignUpController : Controller
    {
        private TelecomStoreDbContext _tsdbcontxt;
        public SignUpController()
        {
            _tsdbcontxt = new TelecomStoreDbContext();
        }
        // GET: SignUp
        [HttpGet]
        public ActionResult Register() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Register")]
        public async Task<ActionResult> RegisterAsync(UserModel model)
        {
			if (ModelState.IsValid)
			{
                User user = new User
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    Password = model.Password
                };
                
                if(_tsdbcontxt.Customers.UserExists(user.Email))
				{
                    ModelState.AddModelError("", "User with this email already exists!");
				}
				else
				{
                    await _tsdbcontxt.AddUserAsync(user);
                    return View(nameof(Completed));
                }
			}
            return View();
        }

        public ViewResult Completed() => View();
    }
}