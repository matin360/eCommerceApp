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
    public class ContactController : Controller
    {
        private TelecomStoreDbContext _tsdbcontxt;
        public ContactController()
        {
            _tsdbcontxt = new TelecomStoreDbContext();
        }
        // GET: Contact
        [HttpGet]
        public ActionResult Index() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Index")]
        public async Task<ActionResult> IndexAsync(ContactMessage model)
        {
			if (ModelState.IsValid)
			{
                await _tsdbcontxt.AddContactMessageAsync(model);
                return View(nameof(Sent));
			}
            return View();
        }

        public ActionResult Sent() => View();
    }
}