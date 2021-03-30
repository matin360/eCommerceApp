using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TelecommunicationDevicesStore.Domain.Data;
using TelecommunicationDevicesStore.WebUI.Infrastructure;

namespace TelecommunicationDevicesStore.WebUI.Areas.Admin.Controllers
{
    public class ProductsController : Controller
    {
        private TelecomStoreDbContext _tsdbcontxt;
        public ProductsController()
        {
            _tsdbcontxt = new TelecomStoreDbContext();
        }
        // GET: Admin/Product
        [ActionName("List")]
        public async Task<ActionResult> ListAsync()
        {
            return View( await _tsdbcontxt.GetAllProducts());
        }
    }
}