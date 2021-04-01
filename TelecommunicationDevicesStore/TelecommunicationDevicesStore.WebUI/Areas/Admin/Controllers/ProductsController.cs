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
        // GET: Admin/Product
        [ActionName("List")]
        public async Task<ActionResult> ListAsync()
        {
            return View( await _tsdbcontxt.GetAllProducts());
        }

        [ActionName("Add")]
        public async Task<ActionResult> AddAsync()
        {
            return View();
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
                   StockCount = p.StockCount,
                   Categories = _tsdbcontxt.Categories.Select(x => new SelectListItem
				   {
                       Text = x.Name,
                       Disabled = false,
                       Value = x.Name,
                       Selected = true
				   })
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
                // Что-то не так со значениями данных
                return View(model);
            }
        }
    }
}