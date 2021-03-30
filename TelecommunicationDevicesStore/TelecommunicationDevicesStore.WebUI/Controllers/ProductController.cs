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
        public async Task<ViewResult> IndexAsync(PageModel model)
        {
            return View(await _tsdbcontxt.GetPaginatableProductsAsync(_itemsPerPage, model));
        }

        public ActionResult PopularProduct()
        {
            return View(_tsdbcontxt.GetPopularProducts(8));
        }

        [HttpGet]
        [ActionName("GategoryProducts")]
		public async Task<ViewResult> GategoryProductsAsync(PageModel model)
		{
            return View(await _tsdbcontxt.GetProductsWithCategory(_itemsPerPage, model));
		}

        [HttpGet]
        [ActionName("Details")]
        public async Task<ViewResult> DetailsAsync(int productId)
		{
            var product = await _tsdbcontxt.GetProductAsync(productId);

            if (product == null)
                return View("Error");

            ProductDetailsModel model = new ProductDetailsModel
            {
                Id = product.Id,
                Name = product.Name,
                Category = new CategoryIndexModel { 
                    Name = product.Category.Name,
                    ProductsCount = product.Category.Products.Count()
                },
                MetaDescription = product.MetaDescription,
                ImagePath = product.ImagePath,
                Price = product.Price,
                StockCount = product.StockCount
            };

            return View(model);
		}
	}
}