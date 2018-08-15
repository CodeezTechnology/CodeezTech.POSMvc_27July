using System;
using System.Net;
using System.Web.Mvc;
using CodeezTech.POS.Web.DAL.EntityDataModel;
using CodeezTech.POS.Web.BAL;
using CodeezTech.POS.CommonProject;

namespace POS.Web.UI.Controllers
{
    public class ProductCategoryController : MasterController
    {
        private Entities db = new Entities();
        BALProductCategory _objBALProductCategory = new BALProductCategory();
        POS_PRODUCT_CATEGORY _objProductCategoryEntity = new POS_PRODUCT_CATEGORY();
        Notify objNotify = new Notify();
        Error error = new Error();

        public ProductCategoryController()
            : base()
        {
            
        }
        // GET: /ProductCategory/
        public ActionResult Index()
        {
            try
            {
                if (Session[SessionVariables.Session_UserInfo] != null)
                {
                    return View(_objBALProductCategory.List());
                }
                else
                {
                    return RedirectToAction("Login", "Home");
                }
            }
            catch (Exception ex)
            {
                error.Breadcrum = "Home > POINT OF SALE (POS) > GetProductCategory  > Index";
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

        // GET: /ProductCategory/Details/5
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
                    POS_PRODUCT_CATEGORY POS_PRODUCT_CATEGORY = _objBALProductCategory.GetById(id);
                    if (POS_PRODUCT_CATEGORY == null)
                    {
                        return HttpNotFound();
                    }
                    return View(POS_PRODUCT_CATEGORY);
                }
                else
                {
                    return RedirectToAction("Login", "Home");
                }
            }
            catch (Exception ex)
            {
                error.Breadcrum = "Home > POINT OF SALE (POS) > GetProductCategory  > Detail";
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

        // GET: /ProductCategory/Create
        public ActionResult Create()
        {
            try
            {
                if (Session[SessionVariables.Session_UserInfo] != null)
                {
                    _objProductCategoryEntity.CATOEGORY_CODE = _objBALProductCategory.GetMaxCode();
                    return View(_objProductCategoryEntity);
                }
                else
                {
                    return RedirectToAction("Login", "Home");
                }
            }
            catch (Exception ex)
            {
                error.Breadcrum = "Home > POINT OF SALE (POS) > GetProductCategory > Create";
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

        // POST: /ProductCategory/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(POS_PRODUCT_CATEGORY POS_PRODUCT_CATEGORY)
        {
            try
            {
                if (Session[SessionVariables.Session_UserInfo] != null)
                {
                    POS_PRODUCT_CATEGORY.CREATEDBY = SessionHandling.UserInformation.USERNAME;
                    POS_PRODUCT_CATEGORY.CREATEDWHEN = DateTime.Now;
                    if (ModelState.IsValid)
                    {
                        objNotify = _objBALProductCategory.Create(POS_PRODUCT_CATEGORY);
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
                        return View(POS_PRODUCT_CATEGORY);
                    }

                    return View(POS_PRODUCT_CATEGORY);
                }
                else
                {
                    return RedirectToAction("Login", "Home");
                }
            }
            catch (Exception ex)
            {
                error.Breadcrum = "Home > POINT OF SALE (POS) > GetProductCategory > Create";
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

        // GET: /ProductCategory/Edit/5
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
                    POS_PRODUCT_CATEGORY POS_PRODUCT_CATEGORY = _objBALProductCategory.GetById(id);
                    if (POS_PRODUCT_CATEGORY == null)
                    {
                        return HttpNotFound();
                    }
                    return View(POS_PRODUCT_CATEGORY);
                }
                else
                {
                    return RedirectToAction("Login", "Home");
                }
            }
            catch (Exception ex)
            {
                error.Breadcrum = "Home > POINT OF SALE (POS) > GetProductCategory   > Edit";
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

        // POST: /ProductCategory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(POS_PRODUCT_CATEGORY POS_PRODUCT_CATEGORY)
        {
            try
            {
                if (Session[SessionVariables.Session_UserInfo] != null)
                {

                    POS_PRODUCT_CATEGORY.MODIFIEDBY = SessionHandling.UserInformation.USERNAME;
                    POS_PRODUCT_CATEGORY.MODIFIEDWHEN = DateTime.Now;
                    if (ModelState.IsValid)
                    {
                        objNotify = _objBALProductCategory.Update(POS_PRODUCT_CATEGORY);
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
                        return View(POS_PRODUCT_CATEGORY);
                    }

                    return View(POS_PRODUCT_CATEGORY);
                }
                else
                {
                    return RedirectToAction("Login", "Home");
                }
            }
            catch (Exception ex)
            {
                error.Breadcrum = "Home > POINT OF SALE (POS) > GetProductCategory  > Edit";
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

        // GET: /ProductCategory/Delete/5
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
                    POS_PRODUCT_CATEGORY POS_PRODUCT_CATEGORY = _objBALProductCategory.GetById(id);
                    if (POS_PRODUCT_CATEGORY == null)
                    {
                        return HttpNotFound();
                    }
                    return View(POS_PRODUCT_CATEGORY);
                }
                else
                {
                    return RedirectToAction("Login", "Home");
                }
            }
            catch (Exception ex)
            {
                error.Breadcrum = "Home > POINT OF SALE (POS) > GetProductCategory > Delete";
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

        // POST: /ProductCategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            try
            {
                if (Session[SessionVariables.Session_UserInfo] != null)
                {
                    objNotify = _objBALProductCategory.Delete(id);
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
                error.Breadcrum = "Home > POINT OF SALE (POS) > GetProductCategory   > Delete";
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
