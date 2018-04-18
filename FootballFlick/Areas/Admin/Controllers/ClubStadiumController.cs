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
    public class ClubStadiumController : BaseController
    {
        ////Display, create, edit, delete ClubStadium
        //Edit an ClubStadium
        [HttpGet]
        public ActionResult Edit(long id)
        {
            var club = new ClubDao().GetByID(id);
            var listStadium = new ClubStadiumDao().ListClubStadium(id);
            ViewBag.ListStadium = listStadium;
            return View(club);
        }

        //Delete an ClubStadium
        [HttpDelete]
        public ActionResult Delete(long clubId, long stadiumId)
        {
            new ClubStadiumDao().Delete(clubId, stadiumId);
            return RedirectToAction("Index");
        }

        public JsonResult AddRow(string row)
        {
            try
            {
                var json = new JavaScriptSerializer().Deserialize<ClubStadium>(row);
                ClubStadium clubStadium = new ClubStadium();
                clubStadium.ClubID = json.ClubID;
                clubStadium.StadiumID = json.StadiumID;
                clubStadium.Status = true;
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