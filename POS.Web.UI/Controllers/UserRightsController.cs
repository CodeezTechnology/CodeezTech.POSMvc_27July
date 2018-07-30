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
    public class UserRightsController : MasterController
    {
        Notify mobjNotify = new Notify();
        BALMenu mobjBALMenu = new BALMenu();
        BALUser mobjBALUser = new BALUser();

        public ActionResult UserList()
        {
            List<POS_USER> objListUser = new List<POS_USER>();
            try
            {
                if (Session[SessionVariables.Session_UserInfo] != null)
                {
                    objListUser = mobjBALUser.List();
                    return View(objListUser);
                }
                else
                {
                    return RedirectToAction("Login", "Home");
                }
            }
            catch (Exception ex)
            {
                if (ex is BALException)
                    throw ex;
                else
                    ExceptionLogger.WriteExceptionInDB(ex, ExceptionLevel.UI, ExceptionType.Error);
                throw new UIException("User Rights Info not completed in UI Layer");
            }
        }


        //
        // GET: /UserRights/
        [HttpGet]
        public ActionResult Index(long id)
        {
            POS_MENU objMenu = new POS_MENU();
            try
            {
                TempData["UserId"] = id;
                if (Session[SessionVariables.Session_UserInfo] != null)
                {
                    objMenu.MenuRightsList = mobjBALMenu.GetMenuRightsByUserId(id);
                    objMenu.ReportRightsList = mobjBALMenu.GetReportRightsByUserId(id);
                    return View(objMenu);
                }
                else
                {
                    return RedirectToAction("Login", "Home");
                }
            }
            catch (Exception ex)
            {
                if (ex is BALException)
                    throw ex;
                else
                    ExceptionLogger.WriteExceptionInDB(ex, ExceptionLevel.UI, ExceptionType.Error);
                throw new UIException("User Rights Info not completed in UI Layer");
            }
        }
        //
        // POST: /UserRights/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(POS_MENU menuModel)
        {
            try
            {
                if (Session[SessionVariables.Session_UserInfo] != null)
                {
                    long id = (long)TempData["UserId"];
                    foreach (var item in menuModel.MenuRightsList)
                    {
                        if (item.INSERTION_FLAG == true || item.UPDATION_FLAG == true || item.DELETION_FLAG == true || item.SELECTION_FLAG == true)
                        {
                            item.CREATEDBY = SessionHandling.UserId.ToString(); 
                            item.CREATEDWHEN = DateTime.Now;
                        }
                    }
                    foreach (var item in menuModel.ReportRightsList)
                    {
                        if (item.Selection == true)
                        {
                            item.CREATEDBY = SessionHandling.UserId.ToString(); ;
                            item.CREATEDWHEN = DateTime.Now;
                        }
                    }
                    mobjNotify = mobjBALMenu.UpdateRights(menuModel, id);
                    if (mobjNotify.RowEffected > 0)
                    {
                        ShowAlert(AlertType.Success, mobjNotify.NotifyMessage);
                        return RedirectToAction("UserList");
                    }
                    else
                    {
                        ShowAlert(AlertType.Error, mobjNotify.NotifyMessage);
                        return View(menuModel);
                    }
                }
                else
                {
                    return RedirectToAction("Login", "Home");
                }
            }
            catch (Exception ex)
            {
                if (ex is BALException)
                    throw ex;
                else
                    //ExceptionLogger.WriteExceptionInDB(ex, ExceptionLevel.UI, ExceptionType.Error);
                throw new UIException("User Rights Info not completed in UI Layer");
            }
        }
    }
}
