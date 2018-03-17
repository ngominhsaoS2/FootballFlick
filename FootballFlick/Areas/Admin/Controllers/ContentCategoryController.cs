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
    public class ContentCategoryController : BaseController
    {
        ////Display, create, edit, delete ContentCategory
        //Index page of ContentCategory management
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new ContentCategoryDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            ViewBag.PageSize = pageSize;
            return View(model);
        }

        //Create a new ContentCategory
        [HttpGet]
        public ActionResult Create()
        {
            SetParentIDViewBag();
            return View();
        }

        [HttpPost]
        public ActionResult Create(ContentCategory contentCategory)
        {
            if (ModelState.IsValid)
            {
                //Xử lý MetaTitle
                if (string.IsNullOrEmpty(contentCategory.MetaTitle))
                {
                    contentCategory.MetaTitle = StringHelper.ToUnsignString(contentCategory.Name);
                }

                var dao = new ContentCategoryDao();
                long id = dao.Insert(contentCategory);
                if (id > 0)
                {
                    SetAlert("Create a new content category successfully.", "success");
                    return RedirectToAction("Index", "ContentCategory");
                }
                else
                {
                    ModelState.AddModelError("", "Create a new Content category failed.");
                    return RedirectToAction("Create", "ContentCategory");
                }
            }
            SetParentIDViewBag();
            return View(contentCategory);
        }

        //Edit an ContentCategory
        [HttpGet]
        public ActionResult Edit(long id)
        {
            var contentCategory = new ContentCategoryDao().GetByID(id);
            SetParentIDViewBag(contentCategory.ParentID);
            return View(contentCategory);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(ContentCategory contentCategory)
        {
            if (ModelState.IsValid)
            {
                contentCategory.MetaTitle = StringHelper.ToUnsignString(contentCategory.Name);

                var result = new ContentCategoryDao().Update(contentCategory);
                if (result)
                {
                    SetAlert("Edit this content category successfully.", "success");
                }
                else
                {
                    ModelState.AddModelError("", "Edit this content category failed.");
                }

            }
            SetParentIDViewBag(contentCategory.ParentID);
            return View(contentCategory);
        }


        //Delete an ContentCategory
        [HttpDelete]
        public ActionResult Delete(long id)
        {
            new ContentCategoryDao().Delete(id);
            return RedirectToAction("Index");
        }










        ////Other methods
        //Set ViewBag for ParentID options
        public void SetParentIDViewBag(long? selectedId = null)
        {
            var dao = new ContentCategoryDao();
            ViewBag.ParentID = new SelectList(dao.ListAll(), "ID", "Name", selectedId);
        }


    }
}