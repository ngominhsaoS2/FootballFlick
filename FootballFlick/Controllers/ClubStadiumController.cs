using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FootballFlick.Controllers
{
    public class ClubStadiumController : Controller
    {
        // GET: ClubStadium
        public ActionResult Index(long clubId, int pageIndex = 1, int pageSize = 10, int pageIndexStadium = 1)
        {
            int totalRecord = 0;
            int totalRecordStadium = 0;
            var dao = new ClubStadiumDao();
            var model = dao.ListClubStadiumPageList(clubId, ref totalRecord, pageIndex, pageSize);
            var listStadium = dao.ListAllPageList(ref totalRecordStadium, pageIndex, pageSize);
            ViewBag.ListStadium = listStadium;

            var club = new ClubDao().GetByID(clubId);
            ViewBag.OwnerID = club.OwnerID;
            ViewBag.ClubID = club.ID;
            ViewBag.ClubCode = club.Code;
            ViewBag.ClubName = club.Name;

            //Phân trang cho trang chính ClubStadium
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
       
            ////Phân trang cho trang modal Stadium
            //ViewBag.TotalStadium = totalRecordStadium;
            //ViewBag.PageStadium = pageIndexStadium;
            //int maxPageStadium = 5;
            //int totalPageStadium = 0;
            //if (totalRecordStadium % pageSize != 0)
            //{
            //    totalPageStadium = (int)(totalRecordStadium / pageSize) + 1;
            //}
            //else
            //{
            //    totalPageStadium = (int)(totalRecordStadium / pageSize);
            //}
            //ViewBag.TotalPageStadium = totalPageStadium;
            //ViewBag.MaxPageStadium = maxPageStadium;
            //ViewBag.FirstStadium = 1;
            //ViewBag.LastStadium = totalPageStadium;
            //ViewBag.NextStadium = pageIndexStadium + 1;
            //ViewBag.PrevStadium = pageIndexStadium - 1;



            return View(model);
        }









    }
}