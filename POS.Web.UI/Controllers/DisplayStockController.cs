using System;
using System.Collections.Generic;
using System.Data;
using System;
using System.Net;
using System.Web.Mvc;
using CodeezTech.POS.Web.DAL.EntityDataModel;
using CodeezTech.POS.Web.BAL;
using CodeezTech.POS.CommonProject;

namespace POS.Web.UI.Controllers
{
    public class DisplayStockController : MasterController
    {
        private Entities db = new Entities();
        BALDisplayStock _objBALDisplayStock = new BALDisplayStock();
        POS_DISPLAY_STOCK _objDisplayStockEntity = new POS_DISPLAY_STOCK();
        Notify objNotify = new Notify();
        Error error = new Error();

        public DisplayStockController()
            : base()
        {

        }
        // GET: /DisplayStock/
        public ActionResult Index()
        {
            try
            {
                if (Session[SessionVariables.Session_UserInfo] != null)
                {
                    return View(_objBALDisplayStock.List());
                }
                else
                {
                    return RedirectToAction("Login", "Home");
                }
            }
            catch (Exception ex)
            {
                error.Breadcrum = "Home > Inventory Management > DisplayStock  > Index";
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

        // GET: /DisplayStock/Details/5
        public ActionResult Details(long id)
        {
            try
            {
                if (Session[SessionVariables.Session_UserInfo] != null)
                {
                    if (id == null)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }
                    POS_DISPLAY_STOCK POS_DISPLAY_STOCK = _objBALDisplayStock.GetById(id);
                    if (POS_DISPLAY_STOCK == null)
                    {
                        return HttpNotFound();
                    }
                    return View(POS_DISPLAY_STOCK);
                }
                else
                {
                    return RedirectToAction("Login", "Home");
                }
            }
            catch (Exception ex)
            {
                error.Breadcrum = "Home > Inventory Management > DisplayStock  > Detail";
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

        // GET: /DisplayStock/Create
        public ActionResult Create()
        {
            try
            {
                if (Session[SessionVariables.Session_UserInfo] != null)
                {
                    _objDisplayStockEntity.DSTOCK_CODE = _objBALDisplayStock.GetMaxCode();
                    return View(_objDisplayStockEntity);
                }
                else
                {
                    return RedirectToAction("Login", "Home");
                }
            }
            catch (Exception ex)
            {
                error.Breadcrum = "Home > Inventory Management > DisplayStock > Create";
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

        // POST: /DisplayStock/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(POS_DISPLAY_STOCK POS_DISPLAY_STOCK)
        {
            try
            {
                if (Session[SessionVariables.Session_UserInfo] != null)
                {
                    POS_DISPLAY_STOCK.CREATEDBY = SessionHandling.UserInformation.USERNAME;
                    POS_DISPLAY_STOCK.CREATEDWHEN = DateTime.Now;
                    if (ModelState.IsValid)
                    {
                        objNotify = _objBALDisplayStock.Create(POS_DISPLAY_STOCK);
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
                        return View(POS_DISPLAY_STOCK);
                    }

                    return View(POS_DISPLAY_STOCK);
                }
                else
                {
                    return RedirectToAction("Login", "Home");
                }
            }
            catch (Exception ex)
            {
                error.Breadcrum = "Home > Inventory Management > DisplayStock > Create";
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

        // GET: /DisplayStock/Edit/5
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
                    POS_DISPLAY_STOCK POS_DISPLAY_STOCK = _objBALDisplayStock.GetById(id);
                    if (POS_DISPLAY_STOCK == null)
                    {
                        return HttpNotFound();
                    }
                    return View(POS_DISPLAY_STOCK);
                }
                else
                {
                    return RedirectToAction("Login", "Home");
                }
            }
            catch (Exception ex)
            {
                error.Breadcrum = "Home > Inventory Management > DisplayStock   > Edit";
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

        // POST: /DisplayStock/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(POS_DISPLAY_STOCK POS_DISPLAY_STOCK)
        {
            try
            {
                if (Session[SessionVariables.Session_UserInfo] != null)
                {

                    POS_DISPLAY_STOCK.MODIFIEDBY = SessionHandling.UserInformation.USERNAME;
                    POS_DISPLAY_STOCK.MODIFIEDWHEN = DateTime.Now;
                    if (ModelState.IsValid)
                    {
                        objNotify = _objBALDisplayStock.Update(POS_DISPLAY_STOCK);
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
                        return View(POS_DISPLAY_STOCK);
                    }

                    return View(POS_DISPLAY_STOCK);
                }
                else
                {
                    return RedirectToAction("Login", "Home");
                }
            }
            catch (Exception ex)
            {
                error.Breadcrum = "Home > Inventory Management > DisplayStock  > Edit";
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

        // GET: /DisplayStock/Delete/5
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
                    POS_DISPLAY_STOCK POS_DISPLAY_STOCK = _objBALDisplayStock.GetById(id);
                    if (POS_DISPLAY_STOCK == null)
                    {
                        return HttpNotFound();
                    }
                    return View(POS_DISPLAY_STOCK);
                }
                else
                {
                    return RedirectToAction("Login", "Home");
                }
            }
            catch (Exception ex)
            {
                error.Breadcrum = "Home > Inventory Management > DisplayStock > Delete";
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

        // POST: /DisplayStock/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            try
            {
                if (Session[SessionVariables.Session_UserInfo] != null)
                {
                    objNotify = _objBALDisplayStock.Delete(id);
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
                error.Breadcrum = "Home > Inventory Management > DisplayStock   > Delete";
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
