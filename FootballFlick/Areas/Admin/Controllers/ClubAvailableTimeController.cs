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
    public class ClubAvailableTimeController : Controller
    {
        ////Display, create, edit, delete ClubAvailableTime
        //Edit an ClubAvailableTime
        [HttpGet]
        public ActionResult Edit(long id)
        {
            var club = new ClubDao().GetByID(id);
            var listAvailableTime = new ClubAvailableTimeDao().ListClubAvailableTime(id);
            ViewBag.ListAvailableTime = listAvailableTime;
            return View(club);
        }

        public JsonResult AddRow(string row)
        {
            try
            {
                var json = new JavaScriptSerializer().Deserialize<ClubAvailableTime>(row);
                ClubAvailableTime clubAvailableTime = new ClubAvailableTime();
                clubAvailableTime.ClubID = json.ClubID;
                clubAvailableTime.Stt = json.Stt;
                clubAvailableTime.Day = json.Day;
                clubAvailableTime.StartTime = json.StartTime;
                clubAvailableTime.EndTime = json.EndTime;
                clubAvailableTime.Status = true;
                var dao = new ClubAvailableTimeDao();

                if (dao.CheckExistRow(json.ClubID, json.Day, (TimeSpan)json.StartTime, (TimeSpan)json.EndTime) == false)
                {
                    dao.Insert(clubAvailableTime);
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

        //Delete an ClubAvailableTime
        [HttpDelete]
        public ActionResult Delete(long clubId, int stt)
        {
            new ClubAvailableTimeDao().Delete(clubId, stt);
            return RedirectToAction("Index");
        }


















    }
}