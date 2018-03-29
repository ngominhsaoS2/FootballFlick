using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FootballFlick.Controllers
{
    public class MatchController : Controller
    {
        // GET: Match
        public ActionResult Index(int pageIndex = 1, int pageSize = 10)
        {
            int totalRecord = 0;
            var model = new MatchDao().ListAll(ref totalRecord, pageIndex, pageSize);
            ViewBag.Total = totalRecord;
            ViewBag.Page = pageIndex;

            int maxPage = 5;
            int totalPage = 0;
            if (totalRecord % pageSize != 0)
            {
                totalPage = (int)(totalRecord / pageSize) + 1;
            }
            else
            {
                totalPage = (int)(totalRecord / pageSize);
            }

            ViewBag.TotalPage = totalPage;
            ViewBag.MaxPage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = totalPage;
            ViewBag.Next = pageIndex + 1;
            ViewBag.Prev = pageIndex - 1;

            return View(model);
        }

        public ActionResult Detail(long id)
        {
            var match = new MatchDao().GetViewModelByID(id);
            var listDetail = new MatchDetailDao().ListMatchDetailViewModel(id);
            var recentMatches = new MatchDao().ListRecentMatch(10);
            ViewBag.ListDetail = listDetail;
            ViewBag.RecentMatches = recentMatches;
            return View(match);
        }




















    }
}