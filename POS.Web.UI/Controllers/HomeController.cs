using CodeezTech.POS.CommonProject;
using CodeezTech.POS.Web.BAL;
using CodeezTech.POS.Web.DAL.EntityDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace POS.Web.UI.Controllers
{
    public class HomeController : MasterController
    {
        BALUser _objBALUser = new BALUser();
        BALMenu objBALMenu = new BALMenu();
        public HomeController()
            : base()
        {
            RedirectToAction("Login", "Home");
        }   
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpGet]
        public ActionResult IndexAdmin()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet]
        public ActionResult IndexUser()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(POS_USER userModel)
        {
             POS_USER objUser = new POS_USER();
             try
             {
                 POS_USER _objUser = _objBALUser.Login(userModel);
                if (_objUser != null)
                {
                    objUser = _objUser;

                    if (objUser.NotifyMessage == "user")
                    {
                        Session[SessionVariables.Session_UserInfo] = _objUser;
                        SessionHandling.UserId = _objUser.USER_ID;
                        SessionHandling.LoginLevel = _objUser.LOGIN_TYPE;

                        ShowAlert(AlertType.Success, "Welcome " + SessionHandling.UserInformation.USERNAME);
                        return RedirectToAction("IndexUser", "Home");
                    }
                    else if (objUser.NotifyMessage == "admin" || objUser.NotifyMessage == "superadmin")
                    {
                        Session[SessionVariables.Session_UserInfo] = _objUser;
                        SessionHandling.UserId = _objUser.USER_ID;
                        SessionHandling.LoginLevel = _objUser.LOGIN_TYPE;

                        ShowAlert(AlertType.Success, "Welcome " + SessionHandling.UserInformation.USERNAME);
                        return RedirectToAction("IndexAdmin", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", userModel.NotifyMessage);
                    }
                }
                else
                {
                    ShowAlert(AlertType.Error, "Invalid user or password.");
                }
                 return View(userModel);
             }
             catch (Exception ex)
             {
                 throw ex;
             }
        }
       
    }
}