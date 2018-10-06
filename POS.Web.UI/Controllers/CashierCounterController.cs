using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CodeezTech.POS.Web.DAL.EntityDataModel;
using System.Net.NetworkInformation;
using CodeezTech.POS.Web.BAL;
using CodeezTech.POS.CommonProject;
namespace POS.Web.UI.Controllers
{
    public class CashierCounterController : MasterController
    {
        // GET: CashierCounter

        private Entities db = new Entities();
        BALCashierCounter _objBALCahierCounter = new BALCashierCounter();
        POS_USER _objUserEntity = new POS_USER();
        Notify objNotify = new Notify();
        Error error = new Error();
        public CashierCounterController()
            : base()
        {
            BranchList();
        }
        // GET: /Company/
        public ActionResult Index()
        {
            try
            {
                if (Session[SessionVariables.Session_UserInfo] != null)
                {
                    BranchList();
                    return View(_objBALCahierCounter.List());
                }
                else
                {
                    return RedirectToAction("Login", "Home");
                }
            }
            catch (Exception ex)
            {
                error.Breadcrum = "Home > Cashier Counter > List";
                if (ex is BALException)
                {
                    error.ErrorMsg = ex.Message.ToString() + "from " + ex.TargetSite.DeclaringType.Name + " method in " + ex.TargetSite.Name + " layer";
                }
                else
                {
                    ExceptionLogger.WriteExceptionInDB(ex, ExceptionLevel.UI, ExceptionType.Error);
                    error.ErrorMsg = ex.Message.ToString() + "from " + ex.TargetSite.DeclaringType.Name + " method in " + ex.TargetSite.Name + " layer";
                }
                return RedirectToAction("ShowErrorPage", "Master", error);
            }
        }

        // GET: /Company/Details/5
        public ActionResult Details(long? id)
        {
            try
            {
                if (Session[SessionVariables.Session_UserInfo] != null)
                {
                    if (id == null)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }
                    POS_CASHIER_COUNTER pos_cashier = _objBALCahierCounter.GetById(id);
                    if (pos_cashier == null)
                    {
                        return HttpNotFound();
                    }
                    return View(pos_cashier);
                }
                else
                {
                    return RedirectToAction("Login", "Home");
                }
            }
            catch (Exception ex)
            {
                error.Breadcrum = "Home > Cashier Counter > List  > Detail";
                if (ex is BALException)
                {
                    error.ErrorMsg = ex.Message.ToString() + "from " + ex.TargetSite.DeclaringType.Name + " method in " + ex.TargetSite.Name + " layer";
                }
                else
                {
                    ExceptionLogger.WriteExceptionInDB(ex, ExceptionLevel.UI, ExceptionType.Error);
                    error.ErrorMsg = ex.Message.ToString() + "from " + ex.TargetSite.DeclaringType.Name + " method in " + ex.TargetSite.Name + " layer";
                }
                return RedirectToAction("ShowErrorPage", "Master", error);
            }

        }

        // GET: /Company/Create
        public ActionResult Create()
        {
            try
            {
                if (Session[SessionVariables.Session_UserInfo] != null)
                {
                    BranchList();

                    return View();
                }
                else
                {
                    return RedirectToAction("Login", "Home");
                }
            }
            catch (Exception ex)
            {
                error.Breadcrum = "Home > Cashier Counter > List > Create";
                if (ex is BALException)
                {
                    error.ErrorMsg = ex.Message.ToString() + "from " + ex.TargetSite.DeclaringType.Name + " method in " + ex.TargetSite.Name + " layer";
                }
                else
                {
                    ExceptionLogger.WriteExceptionInDB(ex, ExceptionLevel.UI, ExceptionType.Error);
                    error.ErrorMsg = ex.Message.ToString() + "from " + ex.TargetSite.DeclaringType.Name + " method in " + ex.TargetSite.Name + " layer";
                }
                return RedirectToAction("ShowErrorPage", "Master", error);
            }
        }

        // POST: /Company/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(POS_CASHIER_COUNTER pos_cashiercounter)
        {
            try
            {
                if (Session[SessionVariables.Session_UserInfo] != null)
                {
                    if (ModelState.IsValid)
                    {
                        BranchList();
                        string hostName = Dns.GetHostName(); // Retrive the Name of HOST  
                        //// Get the IP  
                        string myIP = Dns.GetHostEntry(hostName).AddressList[0].ToString();
                        //string MAC = GetMacAddress().ToString();
                        pos_cashiercounter.PC_NAME = hostName;
                        pos_cashiercounter.IP_ADDRESS = myIP;
                        pos_cashiercounter.CREATEDBY = SessionHandling.UserInformation.USERNAME;
                        pos_cashiercounter.MODIFIEDBY = SessionHandling.UserInformation.USERNAME;
                        pos_cashiercounter.CREATEDWHEN = DateTime.Now;
                        db.POS_CASHIER_COUNTER.Add(pos_cashiercounter);
                        db.SaveChanges();
                       // objNotify = _objBALCahierCounter.Create(pos_cashiercounter);
                        if (objNotify.RowEffected > 0)
                        {
                            ShowAlert(AlertType.Success, objNotify.NotifyMessage);
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            ShowAlert(AlertType.Error, objNotify.NotifyMessage);
                        }
                    }
                }
                else
                {
                    return RedirectToAction("Login", "Home");
                }
            }
            catch (Exception ex)
            {
                error.Breadcrum = "Home > Cashier Counter > List > Create";
                if (ex is BALException)
                {
                    error.ErrorMsg = ex.Message.ToString() + "from " + ex.TargetSite.DeclaringType.Name + " method in " + ex.TargetSite.Name + " layer";
                }
                else
                {
                    ExceptionLogger.WriteExceptionInDB(ex, ExceptionLevel.UI, ExceptionType.Error);
                    error.ErrorMsg = ex.Message.ToString() + "from " + ex.TargetSite.DeclaringType.Name + " method in " + ex.TargetSite.Name + " layer";
                }
                return RedirectToAction("ShowErrorPage", "Master", error);
            }
            return View(pos_cashiercounter);
        }
        public static PhysicalAddress GetMacAddress()
        {
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                // Only consider Ethernet network interfaces
                if (nic.NetworkInterfaceType == NetworkInterfaceType.Ethernet &&
                    nic.OperationalStatus == OperationalStatus.Up)
                {
                    return nic.GetPhysicalAddress();
                }
            }
            return null;
        }
        // GET: /Company/Edit/5
        public ActionResult Edit(long? id)
        {
            try
            {
                if (Session[SessionVariables.Session_UserInfo] != null)
                {
                    if (id == null)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }
                    POS_CASHIER_COUNTER pos_cashiercounter = _objBALCahierCounter.GetById(id);
                    if (pos_cashiercounter == null)
                    {
                        return HttpNotFound();
                    }
                    BranchList();
                    return View(pos_cashiercounter);
                }
                else
                {
                    return RedirectToAction("Login", "Home");
                }
            }
            catch (Exception ex)
            {
                error.Breadcrum = "Home > Cashier Counter > List  > Edit";
                if (ex is BALException)
                {
                    error.ErrorMsg = ex.Message.ToString() + "from " + ex.TargetSite.DeclaringType.Name + " method in " + ex.TargetSite.Name + " layer";
                }
                else
                {
                    ExceptionLogger.WriteExceptionInDB(ex, ExceptionLevel.UI, ExceptionType.Error);
                    error.ErrorMsg = ex.Message.ToString() + "from " + ex.TargetSite.DeclaringType.Name + " method in " + ex.TargetSite.Name + " layer";
                }
                return RedirectToAction("ShowErrorPage", "Master", error);
            }

        }

        // POST: /Company/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(POS_CASHIER_COUNTER pos_cashiercounter)
        {
            try
            {
                if (Session[SessionVariables.Session_UserInfo] != null)
                {
                    BranchList();
                    pos_cashiercounter.MODIFIEDBY = SessionHandling.UserInformation.USERNAME;
                    pos_cashiercounter.MODIFIEDWHEN = DateTime.Now;
                        if (ModelState.IsValid)
                        {
                            objNotify = _objBALCahierCounter.Update(pos_cashiercounter);
                            if (objNotify.RowEffected > 0)
                            {
                                ShowAlert(AlertType.Success, objNotify.NotifyMessage);
                                return RedirectToAction("Index");
                            }
                            else
                            {
                                ShowAlert(AlertType.Error, objNotify.NotifyMessage);
                            }
                        }
                        else
                        {
                            return View(pos_cashiercounter);
                        }
                   // }
                    return View(pos_cashiercounter);
                }
                else
                {
                    return RedirectToAction("Login", "Home");
                }
            }
            catch (Exception ex)
            {
                error.Breadcrum = "Home > Cashier Counter > List  > Edit";
                if (ex is BALException)
                {
                    error.ErrorMsg = ex.Message.ToString() + "from " + ex.TargetSite.DeclaringType.Name + " method in " + ex.TargetSite.Name + " layer";
                }
                else
                {
                    ExceptionLogger.WriteExceptionInDB(ex, ExceptionLevel.UI, ExceptionType.Error);
                    error.ErrorMsg = ex.Message.ToString() + "from " + ex.TargetSite.DeclaringType.Name + " method in " + ex.TargetSite.Name + " layer";
                }
                return RedirectToAction("ShowErrorPage", "Master", error);
            }

        }

        // GET: /Company/Delete/5
        public ActionResult Delete(long? id)
        {
            try
            {
                if (Session[SessionVariables.Session_UserInfo] != null)
                {
                    if (id == null)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }
                    POS_CASHIER_COUNTER pos_cashiercounter = _objBALCahierCounter.GetById(id);
                    if (pos_cashiercounter == null)
                    {
                        return HttpNotFound();
                    }
                    return View(pos_cashiercounter);
                }
                else
                {
                    return RedirectToAction("Login", "Home");
                }
            }
            catch (Exception ex)
            {
                error.Breadcrum = "Home > Cashier Counter > List  > Delete";
                if (ex is BALException)
                {
                    error.ErrorMsg = ex.Message.ToString() + "from " + ex.TargetSite.DeclaringType.Name + " method in " + ex.TargetSite.Name + " layer";
                }
                else
                {
                    ExceptionLogger.WriteExceptionInDB(ex, ExceptionLevel.UI, ExceptionType.Error);
                    error.ErrorMsg = ex.Message.ToString() + "from " + ex.TargetSite.DeclaringType.Name + " method in " + ex.TargetSite.Name + " layer";
                }
                return RedirectToAction("ShowErrorPage", "Master", error);
            }
        }

        // POST: /Company/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            try
            {
                if (Session[SessionVariables.Session_UserInfo] != null)
                {
                    objNotify = _objBALCahierCounter.Delete(id);
                    if (objNotify.RowEffected > 0)
                    {
                        ShowAlert(AlertType.Success, objNotify.NotifyMessage);
                    }
                    else
                    {
                        ShowAlert(AlertType.Error, objNotify.NotifyMessage);
                    }
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Login", "Home");
                }
            }
            catch (Exception ex)
            {
                error.Breadcrum = "Home > Cashier Counter > List  > Delete";
                if (ex is BALException)
                {
                    error.ErrorMsg = ex.Message.ToString() + "from " + ex.TargetSite.DeclaringType.Name + " method in " + ex.TargetSite.Name + " layer";
                }
                else
                {
                    ExceptionLogger.WriteExceptionInDB(ex, ExceptionLevel.UI, ExceptionType.Error);
                    error.ErrorMsg = ex.Message.ToString() + "from " + ex.TargetSite.DeclaringType.Name + " method in " + ex.TargetSite.Name + " layer";
                }
                return RedirectToAction("ShowErrorPage", "Master", error);
            }

        }

        public void BranchList()
        {
            BALCompanyBranch objBALCompanyBranch = new BALCompanyBranch();
            var CompanyBranchList = GetBranchList(objBALCompanyBranch.List());
            TempData["CompanyBranchList"] = CompanyBranchList;
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
