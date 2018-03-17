﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FootballFlick.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Logout()
        {
            Session[FootballFlick.Common.CommonConstants.USER_SESSION] = null;
            return Redirect("/Admin/Login");
        }







    }
}