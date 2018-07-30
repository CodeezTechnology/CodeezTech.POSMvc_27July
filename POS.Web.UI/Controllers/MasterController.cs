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
    public class MasterController : Controller
    {
        public MasterController()
        {


            if (SessionHandling.UserInformation != null)
            {
                if (SessionHandling.LoginLevel != 0)
                {
                    BALMenu objBALMenu = new BALMenu();
                    if (SessionHandling.LoginLevel == 1)
                    {
                        ViewData["Menu"] = objBALMenu.GetChildMenuForUser(SessionHandling.UserId);
                    }
                    else if (SessionHandling.LoginLevel == 2 || SessionHandling.LoginLevel == 3)
                    {
                        ViewData["Menu"] = objBALMenu.GetChildMenuForAdmin();
                    }
                    
                }
                else
                {
                    GoToAction();
                }
            }
            else
            {
                GoToAction();
            }
        }
        public ActionResult GoToAction()
        {
            return RedirectToAction("Index", "Home");
        }
        public void ShowAlert(AlertType MsgType, string Message)
        {
            TempData["AlertType"] = MsgType.ToString();
            TempData["Message"] = Message.ToString();
        }
        public ActionResult ShowErrorPage(Error error)
        {
            return View(error);
        }
        #region Select List
        Entities db = new Entities();
        public SelectList GetCompanyList(List<POS_COMPANY> lstCompany)
        {
            var result = (from u in lstCompany
                          select new{
                              u.COMPANY_ID,
                              u.COMPANY_DESC
                          }).AsEnumerable().ToList();
            return new SelectList(result, "COMPANY_ID", "COMPANY_DESC");
        }
        public SelectList GetBranchList(List<POS_BRANCH> lstBranch)
        {
            var result = (from u in lstBranch
                          select new
                          {
                              u.BRANCH_ID,
                              u.BRANCH_DESC
                          }).AsEnumerable().ToList();

           
            return new SelectList(result, "BRANCH_ID", "BRANCH_DESC");
        }
        #endregion
    }
}