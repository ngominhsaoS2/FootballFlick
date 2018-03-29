using Model.Dao;
using Model.EntityFramework;
using Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace FootballFlick.Controllers
{
    public class ClubPlayerController : Controller
    {
        // GET: ClubPlayer
        public ActionResult Index(long clubId, int pageIndex = 1, int pageSize = 10)
        {
            int totalRecord = 0;
            var model = new ClubPlayerDao().ListClubPlayerPageList(clubId, ref totalRecord, pageIndex, pageSize);
            ViewBag.Total = totalRecord;
            ViewBag.Page = pageIndex;

            var club = new ClubDao().GetByID(clubId);
            ViewBag.OwnerID = club.OwnerID;
            ViewBag.ClubID = club.ID;
            ViewBag.ClubCode = club.Code;
            ViewBag.ClubName = club.Name;

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

        public JsonResult AddPlayer(string clubPlayerViewModel)
        {
            var json = new JavaScriptSerializer().Deserialize<ClubPlayerViewModel>(clubPlayerViewModel);

            //Insert thêm một Player mới vào bảng Player
            Player player = new Player() { Name = json.PlayerName, Identification = json.PlayerIdentification, Address = json.PlayerAddress, Email = json.PlayerEmail, Phone = json.PlayerPhone, Image = json.PlayerImage};
            long playerId = new PlayerDao().Insert(player);

            //Insert thêm một dòng vào bảng ClubPlayer
            ClubPlayer clubPlayer = new ClubPlayer() { ClubID = json.ClubID, PlayerID = playerId, Status = true };
            var dao = new ClubPlayerDao();
            if (dao.CheckExistRow(clubPlayer.ClubID, clubPlayer.PlayerID) == false)
            {
                dao.Insert(clubPlayer);
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

        //Delete an ClubPlayer
        public JsonResult Delete(long clubId, int stt)
        {
            var dao = new ClubPlayerDao();
            var resDel = dao.Delete(clubId, stt);
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