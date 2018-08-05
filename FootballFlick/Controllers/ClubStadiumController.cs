using Model.Dao;
using Model.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FootballFlick.Controllers
{
    public class ClubStadiumController : Controller
    {
        public ActionResult Index(long clubId, int pageIndex = 1, int pageSize = 10)
        {
            int totalRecord = 0;
            var dao = new ClubStadiumDao();
            var model = dao.ListClubStadiumPageList(clubId, ref totalRecord, pageIndex, pageSize);

            //Thông tin của Club
            var club = new ClubDao().GetByID(clubId);
            ViewBag.OwnerID = club.OwnerID;
            ViewBag.ClubID = club.ID;
            ViewBag.ClubCode = club.Code;
            ViewBag.ClubName = club.Name;

            //Đưa ra list Stadium cho Modal
            var listStadium = new StadiumDao().ListRemain(clubId);
            ViewBag.ListStadium = listStadium;

            //Phân trang
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

        //Add one row to ClubStadium
        public JsonResult AddStadium(long clubId, long stadiumId)
        {
            //Insert thêm một dòng vào bảng ClubStadium
            ClubStadium clubStadium = new ClubStadium() { ClubID = clubId, StadiumID = stadiumId, Status = true };
            var dao = new ClubStadiumDao();
            if (dao.CheckExistRow(clubStadium.ClubID, clubStadium.StadiumID) == false)
            {
                dao.Insert(clubStadium);
                return Json(new
                {
                    status = true
                });
            }
            else
            {
                return Json(new
                {
                    status = false
                });
            }
        }

        //Delete an ClubStadium
        public JsonResult Delete(long clubId, int stadiumId)
        {
            var dao = new ClubStadiumDao();
            var resDel = dao.Delete(clubId, stadiumId);
            if (resDel)
            {
                return Json(new
                {
                    status = true
                });
            }
            else
            {
                return Json(new
                {
                    status = false
                });
            }
        }









    }
}