using Model.Dao;
using Model.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Xml.Linq;

namespace FootballFlick.Areas.Admin.Controllers
{
    public class StadiumController : BaseController
    {
        ////Display, create, edit, delete Stadium
        //Index page of Stadium management
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new StadiumDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            ViewBag.PageSize = pageSize;
            return View(model);
        }

        //Create a new Stadium
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Stadium stadium)
        {
            if (ModelState.IsValid)
            {
                var dao = new StadiumDao();
                long id = dao.Insert(stadium);
                if (id > 0)
                {
                    SetAlert("Create a new stadium successfully.", "success");
                    return RedirectToAction("Index", "Stadium");
                }
                else
                {
                    ModelState.AddModelError("", "Create a new stadium failed.");
                    return RedirectToAction("Create", "Stadium");
                }
            }
            return View(stadium);
        }

        //Edit an Stadium
        [HttpGet]
        public ActionResult Edit(long id)
        {
            var stadium = new StadiumDao().GetByID(id);
            return View(stadium);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Stadium stadium)
        {
            if (ModelState.IsValid)
            {
                var result = new StadiumDao().Update(stadium);
                if (result)
                {
                    SetAlert("Edit this stadium successfully.", "success");
                }
                else
                {
                    ModelState.AddModelError("", "Edit this stadium failed.");
                }

            }
            return View(stadium);
        }


        //Delete an Stadium
        [HttpDelete]
        public ActionResult Delete(long id)
        {
            new StadiumDao().Delete(id);
            return RedirectToAction("Index");
        }






        ////Other methods
        public JsonResult SaveImages(long id, string images)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            var listImages = serializer.Deserialize<List<string>>(images);

            XElement xElement = new XElement("Images");

            foreach (var item in listImages)
            {
                var subStringItem = item.Substring(22);
                xElement.Add(new XElement("Image", subStringItem));
            }
            StadiumDao dao = new StadiumDao();
            try
            {
                dao.UpdateImages(id, xElement.ToString());
                return Json(new
                {
                    status = true
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    status = false
                });
            }

        }

        public JsonResult LoadImages(long id)
        {
            StadiumDao dao = new StadiumDao();
            var stadium = dao.GetByID(id);
            var images = stadium.MoreImages;
            if (images != null)
            {
                XElement xImages = XElement.Parse(images);
                List<string> listImagesReturn = new List<string>();

                foreach (XElement element in xImages.Elements())
                {
                    listImagesReturn.Add(element.Value);
                }

                return Json(new
                {
                    data = listImagesReturn
                }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                List<string> listImagesReturn = new List<string>();
                return Json(new
                {
                    data = listImagesReturn
                }, JsonRequestBehavior.AllowGet);
            }

        }







    }
}