using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TelecommunicationDevicesStore.Domain.Data;
using TelecommunicationDevicesStore.WebUI.Infrastructure;

namespace TelecommunicationDevicesStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private TelecomStoreDbContext _tsdbcontxt;
        public ProductController()
        {
            _tsdbcontxt = new TelecomStoreDbContext();
        }
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PopularProduct()
        {
            return View(_tsdbcontxt.GetPopularProducts());
        }
    }
}