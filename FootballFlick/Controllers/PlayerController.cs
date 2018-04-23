using Model.Dao;
using Model.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FootballFlick.Controllers
{
    public class PlayerController : Controller
    {
        //Rank all Players of the system
        public ActionResult Index(string searchString, int pageIndex = 1, int pageSize = 10)
        {
            int totalRecord = 0;
            var model = new PlayerDao().DisplayListRankedPlayer(searchString, ref totalRecord, pageIndex, pageSize);
            ViewBag.SearchString = searchString;

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

        //Dislay all information about the Player
        public ActionResult Detail(long id, int pageIndex = 1, int pageSize = 10)
        {
            var dao = new PlayerDao();
            var player = dao.GetViewModelByID(id);

            
            //Phân trang cho bảng liệt kê các Matches
            int totalRecord = 0;
            var listMatch = dao.ListPlayedMatches(id, ref totalRecord, pageIndex, pageSize);
            ViewBag.ListMatch = listMatch;
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
            return View(player);
        }

















    }
}