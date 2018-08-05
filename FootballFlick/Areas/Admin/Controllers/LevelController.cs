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
    public class LevelController : BaseController
    {
        ////Display, create, edit, delete Level
        //Index page of Level management
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new LevelDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            ViewBag.PageSize = pageSize;
            return View(model);
        }

        //Create a new Level
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Level level)
        {
            if (ModelState.IsValid)
            {
                //Xử lý MetaTitle
                if (!string.IsNullOrEmpty(level.Name))
                {
                    level.MetaTitle = StringHelper.ToUnsignString(level.Name);
                }

                var dao = new LevelDao();
                long id = dao.Insert(level);
                if (id > 0)
                {
                    PopupNotification("success", "Create a new Level successfully.", "success");
                    return RedirectToAction("Create", "Level");
                }
                else
                {
                    PopupNotification("error", "Create a new Level failed.", "danger");
                    return RedirectToAction("Create", "Level");
                }
            }

            return View(level);
        }

        //Edit an Level
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var level = new LevelDao().GetByID(id);
            return View(level);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Level level)
        {
            if (ModelState.IsValid)
            {
                if (!string.IsNullOrEmpty(level.Name))
                {
                    level.MetaTitle = StringHelper.ToUnsignString(level.Name);
                }

                var result = new LevelDao().Update(level);
                if (result)
                {
                    PopupNotification("success", "Edit this Level successfully.", "success");
                }
                else
                {
                    PopupNotification("error", "Edit this Level failed.", "danger");
                }
            }

            return View(level);
        }


        //Delete a Level
        [HttpDelete]
        public ActionResult Delete(long id)
        {
            new LevelDao().Delete(id);
            return RedirectToAction("Index");
        }

        












    }
}