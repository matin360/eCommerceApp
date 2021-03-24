using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TelecommunicationDevicesStore.Domain.Data;
using TelecommunicationDevicesStore.WebUI.Infrastructure;

namespace TelecommunicationDevicesStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private TelecomStoreDbContext _tsdbcontxt;
        private int _itemsPerPage;
        public ProductController()
        {
            _tsdbcontxt = new TelecomStoreDbContext();
            _itemsPerPage = 12;
        }
        // GET: Product
        [HttpGet]
        [ActionName("Index")]
        public async Task<ActionResult> IndexAsync(int page = 1)
        {
            return View(await _tsdbcontxt.GetPaginatableProductsAsync(_itemsPerPage, page));
        }

        public ActionResult PopularProduct()
        {
            return View(_tsdbcontxt.GetPopularProducts(8));
        }

  //      public ActionResult GategoryProducts()
		//{

		//}
    }
}