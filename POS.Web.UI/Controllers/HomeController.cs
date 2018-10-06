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
        BALCompany _objBALCompBranch = new BALCompany();
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
                POS_BRANCH objBranchDetail = _objBALCompBranch.GetBranchInfo(Convert.ToInt32(_objUser.BRANCH_ID));
                 objUser = _objUser;
                 if (objUser.NotifyMessage == "user")
                 {
                     Session[SessionVariables.Session_UserInfo] = _objUser;
                    Session[SessionVariables.Session_BranchInfo] = objBranchDetail;
                     SessionHandling.UserId = _objUser.USER_ID;
                     SessionHandling.LoginLevel = _objUser.LOGIN_TYPE;
                     
                     ShowAlert(AlertType.Success, "Welcome " + SessionHandling.UserInformation.USERNAME);
                     return RedirectToAction("IndexUser", "Home");
                 }
                 else if (objUser.NotifyMessage == "admin" || objUser.NotifyMessage == "superadmin")
                 {
                     Session[SessionVariables.Session_UserInfo] = _objUser;
                    Session[SessionVariables.Session_BranchInfo] = objBranchDetail;
                    SessionHandling.UserId = _objUser.USER_ID;
                     SessionHandling.LoginLevel = _objUser.LOGIN_TYPE;
                 
                     ShowAlert(AlertType.Success, "Welcome " + SessionHandling.UserInformation.USERNAME);
                     return RedirectToAction("IndexAdmin", "Home");
                 }
                 else
                 {
                     ModelState.AddModelError("", userModel.NotifyMessage);
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