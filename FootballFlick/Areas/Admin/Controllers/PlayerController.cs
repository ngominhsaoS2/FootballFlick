using FootballFlick.Common;
using Model.Dao;
using Model.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FootballFlick.Areas.Admin.Controllers
{
    public class PlayerController : BaseController
    {
        ////Display, create, edit, delete Player
        //Index page of Player management
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new PlayerDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            ViewBag.PageSize = pageSize;
            return View(model);
        }

        //Create a new Player
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Player player)
        {
            if (ModelState.IsValid)
            {
                var dao = new PlayerDao();
                long id = dao.Insert(player);
                if (id > 0)
                {
                    SetAlert("Create a new player successfully.", "success");
                    return RedirectToAction("Index", "player");
                }
                else
                {
                    ModelState.AddModelError("", "Create a new player failed.");
                    return RedirectToAction("Create", "Player");
                }
            }
            return View(player);
        }

        //Edit an Player
        [HttpGet]
        public ActionResult Edit(long id)
        {
            var player = new PlayerDao().GetByID(id);
            return View(player);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Player player)
        {
            if (ModelState.IsValid)
            {
                var result = new PlayerDao().Update(player);
                if (result)
                {
                    SetAlert("Edit this player successfully.", "success");
                }
                else
                {
                    ModelState.AddModelError("", "Edit this player failed.");
                }

            }
            return View(player);
        }

        //Delete an Player
        [HttpDelete]
        public ActionResult Delete(long id)
        {
            new PlayerDao().Delete(id);
            return RedirectToAction("Index");
        }







        ////Other methods

        public JsonResult ListPlayer(string q)
        {
            var data = new PlayerDao().ListPlayer(q);
            return Json(new
            {
                data = data,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }














    }
}