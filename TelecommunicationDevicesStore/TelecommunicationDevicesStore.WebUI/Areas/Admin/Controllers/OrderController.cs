using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TelecommunicationDevicesStore.Domain.Data;
using TelecommunicationDevicesStore.WebUI.Infrastructure;

namespace TelecommunicationDevicesStore.WebUI.Areas.Admin.Controllers
{
    public class OrderController : Controller
    {
        private TelecomStoreDbContext _tsdbcontxt;
        public OrderController()
        {
            _tsdbcontxt = new TelecomStoreDbContext();
        }
        // GET: Admin/Order

        [HttpGet]
        [ActionName("List")]
        public async Task<ActionResult> OrdersAsync() => View(await _tsdbcontxt.GetAllOrders());

        [HttpGet]
        [ActionName("Details")]
        public async Task<ActionResult> DetailsAsync(int productId) => View(await _tsdbcontxt.GetOrderDetailsAsync(productId));
    }
}