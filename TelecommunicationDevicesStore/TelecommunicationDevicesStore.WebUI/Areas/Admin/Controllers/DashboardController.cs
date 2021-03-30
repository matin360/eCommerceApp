﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TelecommunicationDevicesStore.Domain.Data;
using TelecommunicationDevicesStore.Domain.Filters;

namespace TelecommunicationDevicesStore.WebUI.Areas.Admin.Controllers
{
    public class DashboardController : Controller
    {
        private TelecomStoreDbContext _tsdbcontxt;
        public DashboardController()
        {
            _tsdbcontxt = new TelecomStoreDbContext();
        }
        // GET: Admin/Dashboard
        //[SessionAuthorizationFilter("/Admin/Account/Login")]
		public ActionResult Index()
        {
            return View();
        }


    }
}