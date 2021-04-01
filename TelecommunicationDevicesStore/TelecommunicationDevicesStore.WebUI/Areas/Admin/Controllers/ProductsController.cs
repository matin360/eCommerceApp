using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TelecommunicationDevicesStore.Domain.Data;
using TelecommunicationDevicesStore.WebUI.Areas.Admin.Models;
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

        [HttpGet]
        [ActionName("List")]
        public async Task<ActionResult> ListAsync()
        {
            return View( await _tsdbcontxt.GetAllProducts());
        }

        [HttpGet]
        [ActionName("Details")]
        public async Task<ActionResult> DetailsAsync(int productId)
        {
            return View(await _tsdbcontxt.GetProductDetailsAsync(productId));
        }
        [HttpGet]
        [ActionName("Add")]
        public ActionResult Add()
        {
            return View("Edit", new ProductEditModel());
        }

        [HttpGet]
        [ActionName("Edit")]
        public async Task<ActionResult> EditAsync(int productId)
        {
            ProductEditModel model = await _tsdbcontxt.Products.Select(p =>
               new ProductEditModel
               {
                   Id = p.Id,
                   MetaDescription = p.MetaDescription,
                   CategoryName = p.Category.Name,
                   Name = p.Name,
                   Price = p.Price,
                   StockCount = p.StockCount
               }).FirstOrDefaultAsync(p => p.Id == productId);
                                            
            return View(model);
        }

        [HttpPost]
        [ActionName("Edit")]
        public async Task<ActionResult> EditAsync(ProductEditModel model)
        {
            if (ModelState.IsValid)
            {
                await _tsdbcontxt.SaveProductAsync(model);
                TempData["message"] = string.Format("Changes in the product \"{0}\" were saved", model.Name);
                return RedirectToAction("List");
            }
            else
            {
                return View(model);
            }
        }

        [ActionName("Remove")]
        public async Task<ActionResult> RemoveAsync(int productId)
        {
            Product removedProduct = await _tsdbcontxt.RemoveProductAsync(productId);
            if (removedProduct != null)
            {
                TempData["message"] = string.Format("Игра \"{0}\" была удалена",
                    removedProduct.Name);
            }
            return RedirectToAction("List", "Products");
        }
    }
}