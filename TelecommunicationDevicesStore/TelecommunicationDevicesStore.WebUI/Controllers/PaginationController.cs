﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TelecommunicationDevicesStore.Domain.Data;
using TelecommunicationDevicesStore.WebUI.Infrastructure;
using TelecommunicationDevicesStore.WebUI.Models;

namespace TelecommunicationDevicesStore.WebUI.Controllers
{
    public class PaginationController : Controller
    {
        private TelecomStoreDbContext _tsdbcontxt;
        public PaginationController()
        {
            _tsdbcontxt = new TelecomStoreDbContext();
        }
        // GET: Pagination

        public ActionResult Paging(PageModel model)
		{
            if (model.ElementsCount == 0)
                 model.ElementsCount = _tsdbcontxt.GetAllProductsNumber();
            return View(model);
		}
	}
}