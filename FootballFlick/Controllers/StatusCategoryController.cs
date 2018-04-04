using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FootballFlick.Controllers
{
    public class StatusCategoryController : Controller
    {
        // GET: StatusCategory
        public ActionResult Index()
        {
            return View();
        }

        //Set options value for select list
        public JsonResult SetOption(string forTable, int type)
        {
            var dao = new StatusCategoryDao();
            var list = dao.ListStatus(forTable, type);
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