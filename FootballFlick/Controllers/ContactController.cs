using Model.Dao;
using Model.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FootballFlick.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {
            var model = new ContactDao().GetActiveContent();
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(Feedback feed)
        {
            if (ModelState.IsValid)
            {
                var dao = new FeedbackDao();
                long result = dao.Insert(feed);
                if (result > 0)
                {
                    ViewBag.Success = "Feedback sent successfully";
                }
                else
                {
                    ModelState.AddModelError("", "Sending feedback failed");
                }
            }
            return View(feed);
        }










    }
}