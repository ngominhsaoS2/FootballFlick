﻿using FootballFlick.Common;
using FootballFlick.Models;
using Model.Dao;
using Model.EntityFramework;
using Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FootballFlick.Controllers
{
    public class ClubController : Controller
    {
        // GET: Club
        public ActionResult Index(long ownerId, int pageIndex = 1, int pageSize = 10)
        {
            int totalRecord = 0;
            var model = new ClubDao().ListAllByOwnerID(ownerId, ref totalRecord, pageIndex, pageSize);

            ViewBag.Total = totalRecord;
            ViewBag.Page = pageIndex;
            ViewBag.OwnerID = ownerId;

            int maxPage = 5;
            int totalPage = 0;
            if (totalRecord % pageSize != 0)
            {
                totalPage = (int)(totalRecord / pageSize) + 1;
            }
            else
            {
                totalPage = (int)(totalRecord / pageSize);
            }

            ViewBag.TotalPage = totalPage;
            ViewBag.MaxPage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = totalPage;
            ViewBag.Next = pageIndex + 1;
            ViewBag.Prev = pageIndex - 1;

            return View(model);
        }

        //Create a new Club
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Club club)
        {
            if (ModelState.IsValid)
            {
                //Xử lý MetaTitle
                if (!string.IsNullOrEmpty(club.Name))
                {
                    club.MetaTitle = StringHelper.ToUnsignString(club.Name);
                }

                var userSession = (UserLogin)Session[FootballFlick.Common.CommonConstants.USER_SESSION];
                club.OwnerID = userSession.UserID;

                var dao = new ClubDao();
                if (dao.CheckCode(club.Code) == false)
                {
                    long id = dao.Insert(club);
                    if (id > 0)
                    {
                        //Tự động Insert level của Club vào ClubLevel
                        ClubLevel clubLevel = new ClubLevel() { ClubID = id, LevelID = 1, Date = DateTime.Now };
                        bool resLv = new ClubLevelDao().Insert(clubLevel);
                        if (resLv == false)
                        {
                            ModelState.AddModelError("", "Automatically create ClubLevel failed.");
                        }

                        ViewBag.Success = "Create your Club successfully";
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
            long ownerId = 0;
            if (club != null)
            {
                ownerId = (long)club.OwnerID;
            }
            ViewBag.OwnerID = ownerId;
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

                var result = new ClubDao().Update(club, 2);
                if (result)
                {
                    ViewBag.Success = "Edit this Club successfully";
                }
                else
                {
                    ModelState.AddModelError("", "Edit this Club failed.");
                }

            }
            
            return View(club);
        }

        //Rank all Clubs of the system
        public ActionResult Rank(int? levelId, string searchString, int pageIndex = 1, int pageSize = 10)
        {
            int totalRecord = 0;
            var model = new ClubDao().DisplayListRankedClub(levelId, searchString, ref totalRecord, pageIndex, pageSize);
            ViewBag.SearchString = searchString;

            Level selectedLevel = new Level();
            if(levelId != null)
            {
                selectedLevel = new LevelDao().GetByID((int)levelId);
            }
            ViewBag.SelectedLevel = selectedLevel;

            ViewBag.Total = totalRecord;
            ViewBag.Page = pageIndex;

            int maxPage = 5;
            int totalPage = 0;
            if (totalRecord % pageSize != 0)
            {
                totalPage = (int)(totalRecord / pageSize) + 1;
            }
            else
            {
                totalPage = (int)(totalRecord / pageSize);
            }

            ViewBag.TotalPage = totalPage;
            ViewBag.MaxPage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = totalPage;
            ViewBag.Next = pageIndex + 1;
            ViewBag.Prev = pageIndex - 1;

            return View(model);
        }

        //Dislay all information about the Club
        public ActionResult Detail(long id, int pageIndex = 1, int pageSize = 10)
        {
            var club = new ClubDao().GetViewModelByID(id);
            var rankInfor = new ClubDao().DisplayRankedClub(id);
            ViewBag.RankInfor = rankInfor;

            //Liệt kê danh sách các Player của Club
            var listPlayer = new ClubPlayerDao().ListClubPlayer(id);
            ViewBag.ListPlayer = listPlayer;

            //Phân trang cho bảng liệt kê các Matches
            int totalRecord = 0;
            var listMatch = new MatchDao().ListMatchesOftheClub(id, ref totalRecord, pageIndex, pageSize);
            ViewBag.ListMatch = listMatch;
            ViewBag.Total = totalRecord;
            ViewBag.Page = pageIndex;
            int maxPage = 5;
            int totalPage = 0;
            if (totalRecord % pageSize != 0)
            {
                totalPage = (int)(totalRecord / pageSize) + 1;
            }
            else
            {
                totalPage = (int)(totalRecord / pageSize);
            }

            ViewBag.TotalPage = totalPage;
            ViewBag.MaxPage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = totalPage;
            ViewBag.Next = pageIndex + 1;
            ViewBag.Prev = pageIndex - 1;

            return View(club);
        }

        









    }
}