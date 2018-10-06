using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CodeezTech.POS.Web.DAL.EntityDataModel;

namespace POS.Web.UI.Controllers
{
    public class PreferencesController : Controller
    {
        private Entities db = new Entities();

        // GET: Preferences
        public ActionResult Index()
        {
            return View(db.POS_COMPANY.ToList());
        }

        // GET: Preferences/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            POS_COMPANY pOS_COMPANY = db.POS_COMPANY.Find(id);
            if (pOS_COMPANY == null)
            {
                return HttpNotFound();
            }
            return View(pOS_COMPANY);
        }

        // GET: Preferences/Create
        public ActionResult Create()
        {
            POS_COMPANY tblcmp = db.POS_COMPANY.FirstOrDefault();

            if (tblcmp != null)
            {
                tblcmp.IsMultipleBranch = tblcmp.IsMultipleBranch;
                tblcmp.IsWarehouse = tblcmp.IsWarehouse;
                tblcmp.IsWarehouseStock = tblcmp.IsWarehouseStock;
                tblcmp.IsWarehouseTracking = tblcmp.IsWarehouseTracking;
                tblcmp.IsWarehouseShipment = tblcmp.IsWarehouseShipment;
                tblcmp.IsVendor = tblcmp.IsVendor;
                tblcmp.IsVendorShipment = tblcmp.IsVendorShipment;
                tblcmp.IsDisplayTracking = tblcmp.IsDisplayTracking;
                tblcmp.IsRFQ = tblcmp.IsRFQ;
                tblcmp.IsAccounting = tblcmp.IsAccounting;
                tblcmp.IsCashierCounter = tblcmp.IsCashierCounter;
                tblcmp.IsPromotion = tblcmp.IsPromotion;
                tblcmp.IsPaymentSystem = tblcmp.IsPaymentSystem;

                return View(tblcmp);
            }
            else
                return View(tblcmp);
        }

        // POST: Preferences/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(POS_COMPANY pOS_COMPANY)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    POS_COMPANY tblcmp = db.POS_COMPANY.FirstOrDefault();

                    if (tblcmp != null)
                    {
                        tblcmp.IsMultipleBranch = pOS_COMPANY.IsMultipleBranch;
                        tblcmp.IsWarehouse = pOS_COMPANY.IsWarehouse;
                        tblcmp.IsWarehouseStock = pOS_COMPANY.IsWarehouseStock;
                        tblcmp.IsWarehouseTracking = pOS_COMPANY.IsWarehouseTracking;
                        tblcmp.IsWarehouseShipment = pOS_COMPANY.IsWarehouseShipment;
                        tblcmp.IsVendor = pOS_COMPANY.IsVendor;
                        tblcmp.IsVendorShipment = pOS_COMPANY.IsVendorShipment;
                        tblcmp.IsDisplayTracking = pOS_COMPANY.IsDisplayTracking;
                        tblcmp.IsRFQ = pOS_COMPANY.IsRFQ;
                        tblcmp.IsAccounting = pOS_COMPANY.IsAccounting;
                        tblcmp.IsCashierCounter = pOS_COMPANY.IsCashierCounter;
                        tblcmp.IsPromotion = pOS_COMPANY.IsPromotion;
                        tblcmp.IsPaymentSystem = pOS_COMPANY.IsPaymentSystem;
                        //   Session["FormName"] = "Email Settings";
                        db.SaveChanges();

                    }
                    else
                    {
                        pOS_COMPANY.IsMultipleBranch = pOS_COMPANY.IsMultipleBranch;
                        pOS_COMPANY.IsWarehouse = pOS_COMPANY.IsWarehouse;
                        pOS_COMPANY.IsWarehouseStock = pOS_COMPANY.IsWarehouseStock;
                        pOS_COMPANY.IsWarehouseTracking = pOS_COMPANY.IsWarehouseTracking;
                        pOS_COMPANY.IsWarehouseShipment = pOS_COMPANY.IsWarehouseShipment;
                        pOS_COMPANY.IsVendor = pOS_COMPANY.IsVendor;
                        pOS_COMPANY.IsVendorShipment = pOS_COMPANY.IsVendorShipment;
                        pOS_COMPANY.IsDisplayTracking = pOS_COMPANY.IsDisplayTracking;
                        pOS_COMPANY.IsRFQ = pOS_COMPANY.IsRFQ;
                        pOS_COMPANY.IsAccounting = pOS_COMPANY.IsAccounting;
                        pOS_COMPANY.IsCashierCounter = pOS_COMPANY.IsCashierCounter;
                        pOS_COMPANY.IsPromotion = pOS_COMPANY.IsPromotion;
                        pOS_COMPANY.IsPaymentSystem = pOS_COMPANY.IsPaymentSystem;
                        db.POS_COMPANY.Add(pOS_COMPANY);
                        db.SaveChanges();
                    }
                    return View(pOS_COMPANY);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return View(pOS_COMPANY);
        }

        // GET: Preferences/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            POS_COMPANY pOS_COMPANY = db.POS_COMPANY.Find(id);
            if (pOS_COMPANY == null)
            {
                return HttpNotFound();
            }
            return View(pOS_COMPANY);
        }

        // POST: Preferences/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "COMPANY_ID,COMPANY_CODE,COMPANY_DESC,LOGO,HTTP_HOST_ADDRESS,NTN_NO,REGISTEREDBY,ISACTIVE_FLAG,ISPOSTED_FLAG,CREATEDBY,MODIFIEDBY,CREATEDWHEN,MODIFIEDWHEN,IsMultipleBranch,IsWarehouse,IsWarehouseStock,IsWarehouseTracking,IsWarehouseShipment,IsVendor,IsVendorShipment,IsDisplayTracking,IsRFQ,IsAccounting,IsCashierCounter,IsPromotion,IsPaymentSystem")] POS_COMPANY pOS_COMPANY)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pOS_COMPANY).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pOS_COMPANY);
        }

        // GET: Preferences/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            POS_COMPANY pOS_COMPANY = db.POS_COMPANY.Find(id);
            if (pOS_COMPANY == null)
            {
                return HttpNotFound();
            }
            return View(pOS_COMPANY);
        }

        // POST: Preferences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            POS_COMPANY pOS_COMPANY = db.POS_COMPANY.Find(id);
            db.POS_COMPANY.Remove(pOS_COMPANY);
            db.SaveChanges();
            return RedirectToAction("Index");
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
