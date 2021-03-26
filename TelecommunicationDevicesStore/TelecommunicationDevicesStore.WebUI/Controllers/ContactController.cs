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
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(ContactMessage model)
        {
			if (ModelState.IsValid)
			{
                model.SubmittedDate = DateTime.Now;
                _tsdbcontxt.ContactMessages.Add(model);
                await _tsdbcontxt.SaveChangesAsync();
                return View(nameof(Sent));
			}
            return View();
        }

        public ActionResult Sent()
        {
            return View();
        }
    }
}