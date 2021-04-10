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
    public class CategoriesController : Controller
    {
        private TelecomStoreDbContext _tsdbcontxt;
        public CategoriesController()
        {
            _tsdbcontxt = new TelecomStoreDbContext();
        }
        // GET: Admin/Category
        [ActionName("List")]
        public async Task<ActionResult> ListAsync() => View( await _tsdbcontxt.GetAllFullCategories());
    }
}