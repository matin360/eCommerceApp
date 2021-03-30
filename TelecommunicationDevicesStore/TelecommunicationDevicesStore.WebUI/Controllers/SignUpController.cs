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
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Register")]
        public async Task<ActionResult> RegisterAsync(UserModel model)
        {
			if (ModelState.IsValid)
			{
                Customer user = new Customer
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    Password = model.Password
                };
                
                if(_tsdbcontxt.Customers.Any( x => x.Email == user.Email))
				{
                    ModelState.AddModelError("", "User with this email already exists!");
				}
				else
				{
                    _tsdbcontxt.Customers.Add(user);
                    await _tsdbcontxt.SaveChangesAsync();
                    return View(nameof(Completed));
                }
			}
            return View();
        }

        public ViewResult Completed()
		{
            return View();
		}
    }
}