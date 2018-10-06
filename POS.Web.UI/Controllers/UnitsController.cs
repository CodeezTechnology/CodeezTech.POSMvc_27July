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
    public class UnitsController : MasterController
    {
        private Entities db = new Entities();
        BALUnits _objBALUnits = new BALUnits();
        POS_UNITS _objUnitsEntity = new POS_UNITS();
        Notify objNotify = new Notify();
        Error error = new Error();

        public UnitsController()
            : base()
        {

        }
        // GET: /Units/
        public ActionResult Index()
        {
            try
            {
                if (Session[SessionVariables.Session_UserInfo] != null)
                {
                    return View(_objBALUnits.List());
                }
                else
                {
                    return RedirectToAction("Login", "Home");
                }
            }
            catch (Exception ex)
            {
                error.Breadcrum = "Home > POINT OF SALE (POS) > Units  > Index";
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

        // GET: /Units/Details/5
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
                    POS_UNITS POS_UNITS = _objBALUnits.GetById(id);
                    if (POS_UNITS == null)
                    {
                        return HttpNotFound();
                    }
                    return View(POS_UNITS);
                }
                else
                {
                    return RedirectToAction("Login", "Home");
                }
            }
            catch (Exception ex)
            {
                error.Breadcrum = "Home > POINT OF SALE (POS) > Units  > Detail";
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

        // GET: /Units/Create
        public ActionResult Create()
        {
            try
            {
                if (Session[SessionVariables.Session_UserInfo] != null)
                {
                    return View(_objUnitsEntity);
                }
                else
                {
                    return RedirectToAction("Login", "Home");
                }
            }
            catch (Exception ex)
            {
                error.Breadcrum = "Home > POINT OF SALE (POS) > Units > Create";
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

        // POST: /Units/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(POS_UNITS POS_UNITS)
        {
            try
            {
                if (Session[SessionVariables.Session_UserInfo] != null)
                {
                    POS_UNITS.CREATEDBY = SessionHandling.UserInformation.USERNAME;
                    POS_UNITS.CREATEDWHEN = DateTime.Now;
                    if (ModelState.IsValid)
                    {
                        objNotify = _objBALUnits.Create(POS_UNITS);
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
                        return View(POS_UNITS);
                    }

                    return View(POS_UNITS);
                }
                else
                {
                    return RedirectToAction("Login", "Home");
                }
            }
            catch (Exception ex)
            {
                error.Breadcrum = "Home > POINT OF SALE (POS) > Units > Create";
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

        // GET: /Units/Edit/5
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
                    POS_UNITS POS_UNITS = _objBALUnits.GetById(id);
                    if (POS_UNITS == null)
                    {
                        return HttpNotFound();
                    }
                    return View(POS_UNITS);
                }
                else
                {
                    return RedirectToAction("Login", "Home");
                }
            }
            catch (Exception ex)
            {
                error.Breadcrum = "Home > POINT OF SALE (POS) > Units   > Edit";
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

        // POST: /Units/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(POS_UNITS POS_UNITS)
        {
            try
            {
                if (Session[SessionVariables.Session_UserInfo] != null)
                {

                    POS_UNITS.MODIFIEDBY = SessionHandling.UserInformation.USERNAME;
                    POS_UNITS.MODIFIEDWHEN = DateTime.Now;
                    if (ModelState.IsValid)
                    {
                        objNotify = _objBALUnits.Update(POS_UNITS);
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
                        return View(POS_UNITS);
                    }

                    return View(POS_UNITS);
                }
                else
                {
                    return RedirectToAction("Login", "Home");
                }
            }
            catch (Exception ex)
            {
                error.Breadcrum = "Home > POINT OF SALE (POS) > Units  > Edit";
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

        // GET: /Units/Delete/5
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
                    POS_UNITS POS_UNITS = _objBALUnits.GetById(id);
                    if (POS_UNITS == null)
                    {
                        return HttpNotFound();
                    }
                    return View(POS_UNITS);
                }
                else
                {
                    return RedirectToAction("Login", "Home");
                }
            }
            catch (Exception ex)
            {
                error.Breadcrum = "Home > POINT OF SALE (POS) > Units > Delete";
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

        // POST: /Units/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            try
            {
                if (Session[SessionVariables.Session_UserInfo] != null)
                {
                    objNotify = _objBALUnits.Delete(id);
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
                error.Breadcrum = "Home > POINT OF SALE (POS) > Units   > Delete";
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
