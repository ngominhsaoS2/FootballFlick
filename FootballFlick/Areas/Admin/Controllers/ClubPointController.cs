using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FootballFlick.Areas.Admin.Controllers
{
    public class ClubPointController : Controller
    {
        ////Display, create, edit, delete ClubPoint
        //Index page of ClubPoint management
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new ClubPointDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            ViewBag.PageSize = pageSize;
            return View(model);
        }















    }
}