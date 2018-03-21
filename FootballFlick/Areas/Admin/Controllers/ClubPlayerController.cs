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
    public class ClubPlayerController : BaseController
    {
        ////Display, create, edit, delete ClubPlayer
        //Edit an ClubPlayer
        [HttpGet]
        public ActionResult Edit(long id)
        {
            var club = new ClubDao().GetByID(id);
            var listPlayer = new ClubPlayerDao().ListClubPlayer(id);
            ViewBag.ListPlayer = listPlayer;
            return View(club);
        }

        //Delete an ClubPlayer
        [HttpDelete]
        public ActionResult Delete(long clubId, long playerId)
        {
            new ClubPlayerDao().Delete(clubId, playerId);
            return RedirectToAction("Index");
        }


        public JsonResult AddRow(string row)
        {
            try
            {
                var json = new JavaScriptSerializer().Deserialize<ClubPlayer>(row);
                ClubPlayer clubPlayer = new ClubPlayer();
                clubPlayer.ClubID = json.ClubID;
                clubPlayer.PlayerID = json.PlayerID;
                clubPlayer.Status = true;
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