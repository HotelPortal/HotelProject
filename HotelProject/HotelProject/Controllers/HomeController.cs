﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelProject.Models;
using Models;

namespace BootstrapMvcSample.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private static List<HomeInputModel> _models = ModelIntializer.CreateHomeInputModels();

        private HotelDBContext db = ConnectionHelper.getContextInstance();

        public ActionResult Index()
        {

            var checkins = db.checkins.OrderByDescending(c => c.Data);
            return View(checkins.ToList());
        }
    }
}
