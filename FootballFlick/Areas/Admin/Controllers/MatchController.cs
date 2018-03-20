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


        //Delete an Match
        [HttpDelete]
        public ActionResult Delete(long id)
        {
            MatchDao matchDao = new MatchDao();
            MatchDetailDao detailDao = new MatchDetailDao();
            Match match = matchDao.GetByID(id);
            bool res = matchDao.Delete(id);
            bool resDetail = detailDao.Delete(match.Code);
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