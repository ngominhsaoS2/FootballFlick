using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FootballFlick.Controllers
{
    public class LevelController : Controller
    {
        // GET: Level
        public ActionResult Index()
        {
            return View();
        }

        //Set options value for select list
        public JsonResult SetOption()
        {
            var dao = new LevelDao();
            var list = dao.ListAllForOption();
            if (list != null)
            {
                return Json(new
                {
                    data = list,
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