using Model.Dao;
using Model.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace FootballFlick.Areas.Admin.Controllers
{
    public class MatchDetailController : Controller
    {
        // GET: Admin/MatchDetail
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Display all detail statistic (store in MatchDetail table) of the Match
        /// </summary>
        /// <param name="matchId"></param>
        /// <param name="clubId"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Statistic(long matchId, long clubId)
        {
            var detail = new MatchDetailDao().ListMatchDetailViewModel(clubId, matchId);
            var match = new MatchDao().GetByID(matchId);
            var club = new ClubDao().GetViewModelByID(clubId);
            ViewBag.Match = match;
            ViewBag.Club = club;
            return View(detail);
        }

        //Delete a MatchDetail
        [HttpDelete]
        public ActionResult Delete(long matchId, long clubId, int playerId)
        {
            new MatchDetailDao().Delete(matchId, clubId, playerId);
            return RedirectToAction("Index");
        }

        //Add a new row to MatchDetail table
        public JsonResult AddRow(string row)
        {
            try
            {
                //Tạo dữ liệu MatchDetail
                var json = new JavaScriptSerializer().Deserialize<MatchDetail>(row);
                MatchDetail detail = new MatchDetail();
                detail.MatchID = json.MatchID;
                detail.ClubID = json.ClubID;
                detail.PlayerID = json.PlayerID;
                detail.Goal = json.Goal == null ? 0 : json.Goal;
                detail.Assist = json.Assist == null ? 0 : json.Assist;
                detail.RedCard = json.RedCard == null ? 0 : json.RedCard;
                detail.YellowCard = json.YellowCard == null ? 0 : json.YellowCard;
                detail.Status = true;

                //Insert vào bảng MatchDetail và bảng PlayerPoint
                var detailDao = new MatchDetailDao();
                if (detailDao.CheckExistRow(detail.MatchID, detail.ClubID, detail.PlayerID) == false)
                {
                    detailDao.Insert(detail);
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
            catch (Exception ex)
            {
                return Json(new
                {
                    status = false
                });
            }
        }






    }
}