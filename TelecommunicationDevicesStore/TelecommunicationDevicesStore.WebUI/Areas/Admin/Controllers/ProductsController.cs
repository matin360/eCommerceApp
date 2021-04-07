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
        public async Task<ActionResult> ListAsync() => View(await _tsdbcontxt.GetAllProducts());

        [HttpGet]
        [ActionName("Details")]
        public async Task<ActionResult> DetailsAsync(int productId) => View(await _tsdbcontxt.GetProductDetailsAsync(productId));
        [HttpGet]
        [ActionName("Add")]
        public ActionResult Add() =>  View("Edit", new ProductEditModel());

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
               // constructor add               
            return View(model);
        }

        [HttpPost]
        [ActionName("Edit")]
        public async Task<ActionResult> EditAsync(ProductEditModel model, HttpPostedFileBase image = null)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    model.ImageMimeType = image.ContentType;
                    model.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(model.ImageData, 0, image.ContentLength);
                }
                await _tsdbcontxt.SaveProductAsync(model);
                TempData["message"] = string.Format("Changes in the product \"{0}\" were saved", model.Name);
                return RedirectToAction("List");
            }
            else
            {
                // smth went wrong
                return View(model);
            }
        }
        public FileContentResult GetImage(int id)
        {
            Product game = _tsdbcontxt.Products.GetProduct(id);

            if (game != null)
                return File(game.ImageData, game.ImageMimeType);
            else
                return null;
        }

        [ActionName("Remove")]
        public async Task<ActionResult> RemoveAsync(int productId)
        {
            Product removedProduct = await _tsdbcontxt.RemoveProductAsync(productId);

            if (removedProduct != null)
                    TempData["message"] = string.Format("Игра \"{0}\" was removed", removedProduct.Name);

            return RedirectToAction("List", "Products");
        }
    }
}