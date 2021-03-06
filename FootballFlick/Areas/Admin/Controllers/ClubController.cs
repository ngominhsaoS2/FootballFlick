﻿using FootballFlick.Common;
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
    public class ClubController : BaseController
    {
        ////Display, create, edit, delete Club
        //Index page of Club management
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new ClubDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            ViewBag.PageSize = pageSize;
            return View(model);
        }

        //Create a new Club
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Club club)
        {
            if (ModelState.IsValid)
            {
                //Xử lý MetaTitle
                if (!string.IsNullOrEmpty(club.Name))
                {
                    club.MetaTitle = StringHelper.ToUnsignString(club.Name);
                }

                var dao = new ClubDao();
                if (dao.CheckCode(club.Code) == false)
                {
                    //Insert Club vào database
                    long id = dao.Insert(club);
                    if (id > 0)
                    {
                        //Tự động Insert level của Club vào ClubLevel
                        ClubLevel clubLevel = new ClubLevel() { ClubID = id, LevelID = 1, Date = DateTime.Now};
                        bool resLv = new ClubLevelDao().Insert(clubLevel);
                        if (resLv == false)
                        {
                            ModelState.AddModelError("", "Automatically create ClubLevel failed.");
                        }

                        //Thông báo tạo mới thành công
                        SetAlert("Create a new club successfully.", "success");
                        return RedirectToAction("Index", "Club");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Create a new club failed.");
                    }

                    
                }
                else
                {
                    ModelState.AddModelError("", "The Code already exists. Please try another Code.");
                }
                
            }
            return View(club);
        }

        //Edit an Club
        [HttpGet]
        public ActionResult Edit(long id)
        {
            var club = new ClubDao().GetByID(id);
            return View(club);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Club club)
        {
            if (ModelState.IsValid)
            {
                if (!string.IsNullOrEmpty(club.Name))
                {
                    club.MetaTitle = StringHelper.ToUnsignString(club.Name);
                }

                var result = new ClubDao().Update(club, 1);
                if (result)
                {
                    SetAlert("Edit this club successfully.", "success");
                }
                else
                {
                    ModelState.AddModelError("", "Edit this club failed.");
                }

            }
            return View(club);
        }


        //Delete an Club
        [HttpDelete]
        public ActionResult Delete(long id)
        {
            new ClubDao().Delete(id);
            return RedirectToAction("Index");
        }





        ////Other methods
        //Save MoreImages
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
            ClubDao dao = new ClubDao();
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

        //Load MoreImages
        public JsonResult LoadImages(long id)
        {
            ClubDao dao = new ClubDao();
            var club = dao.GetByID(id);
            var images = club.MoreImages;
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

        //List all Club when having a keyword
        public JsonResult ListClub(string q)
        {
            var data = new ClubDao().ListClub(q);
            return Json(new
            {
                data = data,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }







    }
}