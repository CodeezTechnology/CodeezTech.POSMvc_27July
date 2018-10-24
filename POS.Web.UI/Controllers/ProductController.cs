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
    public class ProductController : MasterController
    {
        private Entities db = new Entities();
        BALProduct _objBALProduct = new BALProduct();
        POS_PRODUCT _objProductEntity = new POS_PRODUCT();
        Notify objNotify = new Notify();
        Error error = new Error();

        public ProductController()
            : base()
        {
            GetSelectList();
        }
        // GET: /Product/
        public ActionResult Index()
        {
            try
            {
                if (Session[SessionVariables.Session_UserInfo] != null)
                {
                    return View(_objBALProduct.List());
                }
                else
                {
                    return RedirectToAction("Login", "Home");
                }
            }
            catch (Exception ex)
            {
                error.Breadcrum = "Home > POINT OF SALE (POS) > Product  > Index";
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

        // GET: /Product/Details/5
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
                    POS_PRODUCT POS_PRODUCT = _objBALProduct.GetById(id);
                    if (POS_PRODUCT == null)
                    {
                        return HttpNotFound();
                    }
                    return View(POS_PRODUCT);
                }
                else
                {
                    return RedirectToAction("Login", "Home");
                }
            }
            catch (Exception ex)
            {
                error.Breadcrum = "Home > POINT OF SALE (POS) > Product  > Detail";
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

        // GET: /Product/Create
        public ActionResult Create()
        {
            try
            {
                if (Session[SessionVariables.Session_UserInfo] != null)
                {
                    GetSelectList();
                    _objProductEntity.PRODUCT_CODE = _objBALProduct.GetMaxCode();
                    return View(_objProductEntity);
                }
                else
                {
                    return RedirectToAction("Login", "Home");
                }
            }
            catch (Exception ex)
            {
                error.Breadcrum = "Home > POINT OF SALE (POS) > Product > Create";
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

        // POST: /Product/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create(POS_PRODUCT ProductModel)
        {
            try
            {
                if (Session[SessionVariables.Session_UserInfo] != null)
                {
                    ProductModel.CREATEDBY = SessionHandling.UserInformation.USERNAME;
                    ProductModel.CREATEDWHEN = DateTime.Now;
                    if (ProductModel.PRODUCT_DESC != null)
                    {
                        objNotify = _objBALProduct.Create(ProductModel);
                        if (objNotify.RowEffected > 0)
                        {
                            ShowAlert(AlertType.Success, objNotify.NotifyMessage);
                        }
                        else
                        {
                            ShowAlert(AlertType.Error, objNotify.NotifyMessage);
                        }
                    }
                    //return View(POS_PRODUCT);
                }
                else
                {
                    return RedirectToAction("Login", "Home");
                }
            }
            catch (Exception ex)
            {
                error.Breadcrum = "Home > POINT OF SALE (POS) > Product > Create";
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
            return Json(new { Result = objNotify.RowEffected }, JsonRequestBehavior.AllowGet);
        }

        // GET: /Product/Edit/5
        public ActionResult Edit(long? id)
        {
            try
            {
                if (Session[SessionVariables.Session_UserInfo] != null)
                {
                    GetSelectList();
                    if (id == null)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }
                    POS_PRODUCT POS_PRODUCT = _objBALProduct.GetById(id);
                    if (POS_PRODUCT == null)
                    {
                        return HttpNotFound();
                    }
                    return View(POS_PRODUCT);
                }
                else
                {
                    return RedirectToAction("Login", "Home");
                }
            }
            catch (Exception ex)
            {
                error.Breadcrum = "Home > POINT OF SALE (POS) > Product   > Edit";
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

        // POST: /Product/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(POS_PRODUCT POS_PRODUCT)
        {
            try
            {
                if (Session[SessionVariables.Session_UserInfo] != null)
                {

                    POS_PRODUCT.MODIFIEDBY = SessionHandling.UserInformation.USERNAME;
                    POS_PRODUCT.MODIFIEDWHEN = DateTime.Now;
                    if (ModelState.IsValid)
                    {
                        objNotify = _objBALProduct.Update(POS_PRODUCT);
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
                        return View(POS_PRODUCT);
                    }

                    return View(POS_PRODUCT);
                }
                else
                {
                    return RedirectToAction("Login", "Home");
                }
            }
            catch (Exception ex)
            {
                error.Breadcrum = "Home > POINT OF SALE (POS) > Product  > Edit";
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



        // GET: /Product/Delete/5
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
                    POS_PRODUCT POS_PRODUCT = _objBALProduct.GetById(id);
                    if (POS_PRODUCT == null)
                    {
                        return HttpNotFound();
                    }
                    return View(POS_PRODUCT);
                }
                else
                {
                    return RedirectToAction("Login", "Home");
                }
            }
            catch (Exception ex)
            {
                error.Breadcrum = "Home > POINT OF SALE (POS) > Product > Delete";
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

        // POST: /Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            try
            {
                if (Session[SessionVariables.Session_UserInfo] != null)
                {
                    objNotify = _objBALProduct.Delete(id);
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
                error.Breadcrum = "Home > POINT OF SALE (POS) > Product   > Delete";
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
        [HttpGet]
        public ActionResult GetStockDetail(long id)
        {
            POS_DISPLAY_STOCK entityDisplayStock = new POS_DISPLAY_STOCK();
            return PartialView("_StockDetail",entityDisplayStock);
        }
        public void GetSelectList()
        {
            //BALProductCategory objBALProductCategory = new BALProductCategory();
            //var ProductCategoryList = GetProductCategoryList(objBALProductCategory.List());
            //TempData["ProductCategoryList"] = ProductCategoryList;

            //BALProductType objBALProductType = new BALProductType();
            //var ProductTypeList = GetProductTypeList(objBALProductType.List());
            //TempData["ProductTypeList"] = ProductTypeList;

            //BALUnits objBALUnits = new BALUnits();
            //var UnitsList = GetUnitList(objBALUnits.List());
            //TempData["UnitList"] = UnitsList;


        }


        [HttpGet]
        public ActionResult ProductDetailPartial(long id)
        {
            Session["ProductID"] = id;
            var Query = "";
                //from tblprod in db.POS_PAYMENT_TYPE.tol
                         //where tblprod.PRODUCT_ID == id
                         //select new
                         //{

                         //}).AsEnumerable().Select(x => new POS_PRODUCT()
                         //{

                         //}).ToList();

            return PartialView("ProductDetail", Query);
        }
        public ActionResult CallDetail(string id)
        {
            return ProductDetailPartial(Convert.ToInt32(id));
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
