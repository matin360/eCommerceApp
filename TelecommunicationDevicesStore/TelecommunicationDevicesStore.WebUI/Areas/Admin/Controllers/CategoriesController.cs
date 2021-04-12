using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TelecommunicationDevicesStore.Domain.Data;
using TelecommunicationDevicesStore.Domain.Filters;
using TelecommunicationDevicesStore.WebUI.Areas.Admin.Models;
using TelecommunicationDevicesStore.WebUI.Infrastructure;

namespace TelecommunicationDevicesStore.WebUI.Areas.Admin.Controllers
{
    public class CategoriesController : Controller
    {
        private TelecomStoreDbContext _tsdbcontxt;
        public CategoriesController()
        {
            _tsdbcontxt = new TelecomStoreDbContext();
        }
        // GET: Admin/Category
        [ActionName("List")]
        [SessionAuthorizationFilter("/Admin/Account/Login")]
        public async Task<ActionResult> ListAsync() => View( await _tsdbcontxt.GetAllFullCategories());

        [HttpGet]
        [ActionName("Add")]
        [SessionAuthorizationFilter("/Admin/Account/Login")]
        public ActionResult Add() => View(new CategoryEditModel());

		[HttpPost]
		[ActionName("Add")]
		public async Task<ActionResult> AddAsync(CategoryEditModel model)
		{
            await _tsdbcontxt.AddCategoryAsync(model);
            return View();
		}

        [ActionName("Remove")]
        public async Task<ActionResult> RemoveAsync(int productId)
        {
            Category removedCategory = await _tsdbcontxt.RemoveCategoryAsync(productId);

            if (removedCategory != null)
                TempData["message"] = string.Format("Category \"{0}\" was removed", removedCategory.Name);

            return RedirectToAction("List", "Categories");
        }
    }
}