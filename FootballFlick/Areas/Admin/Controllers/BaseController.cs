using FootballFlick.Common;
using FootballFlick;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FootballFlick.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        //User session
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var session = (UserLogin)Session[CommonConstants.USER_SESSION];
            if (session == null)
            {
                filterContext.Result = new RedirectToRouteResult(new
                    System.Web.Routing.RouteValueDictionary(new { Controller = "Login", Action = "Index", Areas = "Admin" }));
            }

            base.OnActionExecuting(filterContext);
        }

        //Alert method
        protected void SetAlert(string message, string type)
        {
            TempData["AlertMessage"] = message;
            if (type == "success")
            {
                TempData["AlertType"] = "alert-success";
            }
            else if (type == "warning")
            {
                TempData["AlertType"] = "alert-warning";
            }
            else if (type == "error")
            {
                TempData["AlertType"] = "alert-danger";
            }
        }

        /// <summary>
        /// SaoNM 07/06/2018 Popup notification
        /// </summary>
        /// <param name="message"></param>
        /// <param name="type"></param>
        protected void PopupNotification(string title, string message, string type)
        {
            TempData["NotificationMessage"] = message;
            if (title == "success")
            {
                TempData["NotificationTitle"] = "Success";
                TempData["NotificationType"] = "success";
            }
            else if (title == "warning")
            {
                TempData["NotificationTitle"] = "Warning";
                TempData["NotificationType"] = "warning";
            }
            else if (title == "error")
            {
                TempData["NotificationTitle"] = "Danger";
                TempData["NotificationType"] = "danger";
            }
        }

    }
}