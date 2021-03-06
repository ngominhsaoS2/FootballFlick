﻿using BotDetect.Web.Mvc;
using FootballFlick.Common;
using FootballFlick.Models;
using Model.Dao;
using Model.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FootballFlick.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [CaptchaValidation("CaptchaCode", "registerCapcha", "Confirmed code is not right. Please try again.")]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                if (dao.CheckUserName(model.UserName))
                {
                    ModelState.AddModelError("", "The UserName is already used by another person");
                }
                else if (dao.CheckEmail(model.Email))
                {
                    ModelState.AddModelError("", "The Email is already used by another person");
                }
                else
                {
                    //Tạo User mới
                    var user = new User();
                    user.UserName = model.UserName;
                    user.Password = Encryptor.MD5Hash(model.Password);
                    user.GroupID = "MEMBER";
                    user.Name = model.Name;
                    user.Address = model.Address;
                    user.Email = model.Email;
                    user.Phone = model.Phone;
                    user.CreatedDate = DateTime.Now;
                    user.Status = true;
                    var resUser = dao.Insert(user);

                    //Tạo Player mới theo User
                    var player = new Player();
                    player.Name = model.UserName;
                    player.Identification = model.Email;
                    player.Address = model.Address;
                    player.Email = model.Email;
                    player.Phone = model.Phone;
                    player.Image = model.Image;
                    player.CreatedDate = DateTime.Now;
                    player.Status = true;
                    var resPlayer = new PlayerDao().Insert(player);

                    if (resUser > 0)
                    {
                        ViewBag.Success = "Register successfully";
                        model = new RegisterModel();
                    }
                    else
                    {
                        ModelState.AddModelError("", "Register failed");
                    }

                    

                    if (resPlayer > 0)
                    {
                        
                    }
                    else
                    {
                        ModelState.AddModelError("", "Create a new player failed");
                    }

                }
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();

                var result = dao.Login(model.UserName, Encryptor.MD5Hash(model.Password));
                if (result == 1)
                {
                    var user = dao.GetByUserName(model.UserName);

                    var userSession = new UserLogin();
                    userSession.UserName = user.UserName;
                    userSession.UserID = user.ID;
                    userSession.GroupID = user.GroupID;
                    userSession.Image = user.Image;
                    //Add vào User Session
                    Session.Add(FootballFlick.Common.CommonConstants.USER_SESSION, userSession);

                    //Add vào Permission Session
                    var listPermission = dao.GetListPermission(user.UserName);
                    Session.Add(CommonConstants.PERMISSIONS_SESSION, listPermission);

                    return RedirectToAction("Index", "Home");
                }
                else if (result == 0)
                {
                    ModelState.AddModelError("", "This account does not exist");
                }
                else if (result == -1)
                {
                    ModelState.AddModelError("", "This account is locked");
                }
                else if (result == -2)
                {
                    ModelState.AddModelError("", "Wrong password");
                }
                else
                {
                    ModelState.AddModelError("", "Login failed");
                }
            }
            return View(model);
        }


        public ActionResult Logout()
        {
            Session[FootballFlick.Common.CommonConstants.USER_SESSION] = null;
            return Redirect("/");
        }










    }
}