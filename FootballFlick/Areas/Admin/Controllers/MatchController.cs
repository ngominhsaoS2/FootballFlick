using FootballFlick.Common;
using Model.Dao;
using Model.EntityFramework;
using Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace FootballFlick.Areas.Admin.Controllers
{
    public class MatchController : BaseController
    {
        ////Display, create, edit, delete Match
        //Index page of Match management
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new MatchDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            ViewBag.PageSize = pageSize;
            return View(model);
        }

        //Create a new Match
        [HttpGet]
        public ActionResult Create()
        {
            SetStatusViewBag();
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Match match)
        {
            if (ModelState.IsValid)
            {
                //Xử lý MetaTitle
                if (!string.IsNullOrEmpty(match.Name))
                {
                    match.MetaTitle = StringHelper.ToUnsignString(match.Name);
                }

                var dao = new MatchDao();
                long id = dao.Insert(match);
                if (id > 0)
                {
                    SetAlert("Create a new match successfully.", "success");
                    return RedirectToAction("Index", "Match");
                }
                else
                {
                    ModelState.AddModelError("", "Create a new match failed.");
                    return RedirectToAction("Create", "Match");
                }
            }
            SetStatusViewBag();
            return View(match);
        }

        //Edit an Match
        [HttpGet]
        public ActionResult Edit(long id)
        {
            var match = new MatchDao().GetViewModelByID(id);
            SetStatusViewBag(match.Status);
            return View(match);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(MatchViewModel matchViewModel)
        {
            Match match = new Match();
            if (ModelState.IsValid)
            {
                match.ID = matchViewModel.ID;
                match.Code = matchViewModel.Code;
                match.Name = matchViewModel.Name;
                match.Description = matchViewModel.Description;
                match.Image = matchViewModel.Image;
                match.HomeClubID = matchViewModel.HomeClubID;
                match.VisitingClubID = matchViewModel.VisitingClubID;
                match.StadiumID = matchViewModel.StadiumID;
                match.Date = matchViewModel.Date;
                match.ExpectedStartTime = matchViewModel.ExpectedStartTime;
                match.ExpectedEndTime = matchViewModel.ExpectedEndTime;
                match.HoldAddress = matchViewModel.HoldAddress;
                match.Price = matchViewModel.Price;
                match.PromotionPrice = matchViewModel.PromotionPrice;
                match.ExpiredDateToSign = matchViewModel.ExpiredDateToSign;
                match.Detail = matchViewModel.Detail;
                match.RealStartTime = matchViewModel.RealStartTime;
                match.RealEndTime = matchViewModel.RealEndTime;
                match.HomeClubGoal = matchViewModel.HomeClubGoal;
                match.VisitingClubGoal = matchViewModel.VisitingClubGoal;
                match.Status = matchViewModel.Status;
                match.MetaKeywords = matchViewModel.MetaKeywords;
                match.MetaDescriptions = matchViewModel.MetaDescriptions;
                if (!string.IsNullOrEmpty(match.Name))
                {
                    match.MetaTitle = StringHelper.ToUnsignString(match.Name);
                }
                
                var result = new MatchDao().Update(match);
                if (result)
                {
                    SetAlert("Edit this match successfully.", "success");
                }
                else
                {
                    ModelState.AddModelError("", "Edit this match failed.");
                }

            }
            SetStatusViewBag(matchViewModel.Status);
            return View(matchViewModel);
        }

        //Result an Match
        [HttpGet]
        public ActionResult Result(long id)
        {
            var match = new MatchDao().GetViewModelByID(id);
            SetStatusViewBag(match.Status);
            return View(match);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Result(MatchViewModel matchViewModel)
        {
            Match match = new Match();
            if (ModelState.IsValid)
            {
                //Update kết quả của Match
                match.ID = matchViewModel.ID;
                match.Code = matchViewModel.Code;
                match.Name = matchViewModel.Name;
                match.Description = matchViewModel.Description;
                match.Image = matchViewModel.Image;
                match.HomeClubID = matchViewModel.HomeClubID;
                match.VisitingClubID = matchViewModel.VisitingClubID;
                match.StadiumID = matchViewModel.StadiumID;
                match.Date = matchViewModel.Date;
                match.ExpectedStartTime = matchViewModel.ExpectedStartTime;
                match.ExpectedEndTime = matchViewModel.ExpectedEndTime;
                match.HoldAddress = matchViewModel.HoldAddress;
                match.Price = matchViewModel.Price;
                match.PromotionPrice = matchViewModel.PromotionPrice;
                match.ExpiredDateToSign = matchViewModel.ExpiredDateToSign;
                match.Detail = matchViewModel.Detail;
                match.RealStartTime = matchViewModel.RealStartTime;
                match.RealEndTime = matchViewModel.RealEndTime;
                match.HomeClubGoal = matchViewModel.HomeClubGoal;
                match.VisitingClubGoal = matchViewModel.VisitingClubGoal;
                match.Status = matchViewModel.Status;
                match.MetaKeywords = matchViewModel.MetaKeywords;
                match.MetaDescriptions = matchViewModel.MetaDescriptions;
                if (!string.IsNullOrEmpty(match.Name))
                {
                    match.MetaTitle = StringHelper.ToUnsignString(match.Name);
                }

                var result = new MatchDao().Update(match);
                if (result)
                {
                    SetAlert("Result this match successfully.", "success");
                }
                else
                {
                    ModelState.AddModelError("", "Result this match failed.");
                }

                //Update ClubPoint cho cả hai đội
                ClubPoint homePoint = new ClubPoint();
                homePoint.MatchID = match.ID;
                homePoint.ClubID = (long)match.HomeClubID;
                homePoint.JoinPoint = CommonConstants.JoinPoint;
                homePoint.WinPoint = (match.HomeClubGoal > match.VisitingClubGoal == true ? CommonConstants.WinPoint : 0);
                homePoint.DrawPoint = (match.HomeClubGoal == match.VisitingClubGoal == true ? CommonConstants.DrawPoint : 0);
                homePoint.Status = true;

                ClubPoint visitingPoint = new ClubPoint();
                visitingPoint.MatchID = match.ID;
                visitingPoint.ClubID = (long)match.VisitingClubID;
                visitingPoint.JoinPoint = CommonConstants.JoinPoint;
                visitingPoint.WinPoint = (match.VisitingClubGoal > match.HomeClubGoal == true ? CommonConstants.WinPoint : 0);
                visitingPoint.DrawPoint = (match.VisitingClubGoal == match.HomeClubGoal == true ? CommonConstants.DrawPoint : 0);
                visitingPoint.Status = true;

                var homeLevel = new ClubLevelDao().GetBeforeDate(homePoint.ClubID, (DateTime)match.Date);
                var visitingLevel = new ClubLevelDao().GetBeforeDate(visitingPoint.ClubID, (DateTime)match.Date);
                homePoint.RivalLevelID = visitingLevel.LevelID;
                visitingPoint.RivalLevelID = homeLevel.LevelID;

                var dao = new ClubPointDao();

                if (dao.CheckExist(homePoint.MatchID, homePoint.ClubID) == true)
                {
                    dao.Update(homePoint);
                }
                else
                {
                    dao.Insert(homePoint);
                }

                if (dao.CheckExist(visitingPoint.MatchID, visitingPoint.ClubID) == true)
                {
                    dao.Update(visitingPoint);
                }
                else
                {
                    dao.Insert(visitingPoint);
                }


            }
            
            SetStatusViewBag(matchViewModel.Status);
            return View(matchViewModel);
        }


        //Delete an Match
        [HttpDelete]
        public ActionResult Delete(long id)
        {
            MatchDao matchDao = new MatchDao();
            MatchDetailDao detailDao = new MatchDetailDao();
            Match match = matchDao.GetByID(id);
            bool res = matchDao.Delete(id);
            bool resDetail = detailDao.DeleteAll(match.ID);
            return RedirectToAction("Index");
        }

        

        ////Other methods
        //Set ViewBag for Status options
        public void SetStatusViewBag(long? selectedId = null)
        {
            var dao = new StatusCategoryDao();
            ViewBag.Status = new SelectList(dao.ListStatus("Match", 1), "ID", "Name");
        }

        








    }
}