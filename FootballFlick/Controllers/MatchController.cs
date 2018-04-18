using FootballFlick.Common;
using Model.Dao;
using Model.EntityFramework;
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
        public ActionResult Index(int? matchStatus, string searchString, int pageIndex = 1, int pageSize = 10)
        {
            int totalRecord = 0;
            var model = new MatchDao().ListAll(matchStatus, searchString, ref totalRecord, pageIndex, pageSize);
            ViewBag.SearchString = searchString;

            StatusCategory selectedMatchStatus = new StatusCategory() { Stt = 0, Name = "---Select one---" };
            if (matchStatus != null)
            {
                selectedMatchStatus = new StatusCategoryDao().GetByStt("Match", (int)matchStatus);
            }
            ViewBag.SelectedMatchStatus = selectedMatchStatus;

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

        //Display the Match and its detail
        public ActionResult Detail(long id)
        {
            var match = new MatchDao().GetViewModelByID(id);
            var listDetail = new MatchDetailDao().ListMatchDetailViewModel(id);
            var recentMatches = new MatchDao().ListRecentMatch(10);
            ViewBag.ListDetail = listDetail;
            ViewBag.RecentMatches = recentMatches;
            return View(match);
        }

        //Create a new Match
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Match match)
        {
            if (ModelState.IsValid)
            {
                //Xử lý MetaTitle
                if (!string.IsNullOrEmpty(match.Name))
                {
                    match.MetaTitle = StringHelper.ToUnsignString(match.Name);
                }

                var userSession = (UserLogin)Session[FootballFlick.Common.CommonConstants.USER_SESSION];
                match.CreatedBy = userSession.UserName;

                var dao = new MatchDao();
                if (dao.CheckCode(match.Code) == false)
                {
                    long id = dao.Insert(match);
                    if (id > 0)
                    {
                        ViewBag.Success = "Create your match successfully";
                    }
                    else
                    {
                        ModelState.AddModelError("", "Create a new match failed.");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "The Code already exists. Please try another Code.");
                }

            }
            return View(match);
        }

        //Thay đổi linh tinh ở đây xem có gì không nào
















    }
}
