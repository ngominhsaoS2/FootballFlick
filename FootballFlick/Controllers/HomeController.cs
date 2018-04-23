using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FootballFlick.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //Lấy ra list Banner
            var listBanner = new BannerDao().GetListBanner(3);
            ViewBag.ListBanner = listBanner;

            //Lấy ra top Match
            var listMatch = new MatchDao().ListRecentMatch(4);
            ViewBag.ListMatch = listMatch;

            return View();
        }

        [ChildActionOnly]
        public ActionResult Navigation()
        {
            var model = new MenuDao().ListMenu(0, 1);
            return PartialView(model);
        }

        [ChildActionOnly]
        public ActionResult Footer()
        {
            return PartialView();
        }







    }
}