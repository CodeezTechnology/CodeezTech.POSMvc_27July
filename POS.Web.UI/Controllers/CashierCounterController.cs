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
    public class CashierCounterController : MasterController
    {
        // GET: CashierCounter
        private Entities db = new Entities();

        // GET: /Company/
        public ActionResult Index()
        {
            return View(db.POS_CASHIER_COUNTER.ToList());
        }

        // GET: /Company/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            POS_CASHIER_COUNTER pos_cashiercounter = db.POS_CASHIER_COUNTER.Find(id);
            if (pos_cashiercounter == null)
            {
                return HttpNotFound();
            }
            return View(pos_cashiercounter);
        }

        // GET: /Company/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Company/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "COMPANY_ID,COMPANY_CODE,COMPANY_DESC,LOGO,HTTP_HOST_ADDRESS,NTN_NO,REGISTEREDBY,ISACTIVE_FLAG,ISPOSTED_FLAG,CREATEDBY,MODIFIEDBY,CREATEDWHEN,MODIFIEDWHEN")] POS_CASHIER_COUNTER pos_cashiercounter)
        {
            if (ModelState.IsValid)
            {
                db.POS_CASHIER_COUNTER.Add(pos_cashiercounter);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pos_cashiercounter);
        }

        // GET: /Company/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            POS_CASHIER_COUNTER pos_cashiercounter = db.POS_CASHIER_COUNTER.Find(id);
            if (pos_cashiercounter == null)
            {
                return HttpNotFound();
            }
            return View(pos_cashiercounter);
        }

        // POST: /Company/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "COMPANY_ID,COMPANY_CODE,COMPANY_DESC,LOGO,HTTP_HOST_ADDRESS,NTN_NO,REGISTEREDBY,ISACTIVE_FLAG,ISPOSTED_FLAG,CREATEDBY,MODIFIEDBY,CREATEDWHEN,MODIFIEDWHEN")] POS_CASHIER_COUNTER pos_cashiercounter)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pos_cashiercounter).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pos_cashiercounter);
        }

        // GET: /Company/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            POS_CASHIER_COUNTER pos_cashiercounter = db.POS_CASHIER_COUNTER.Find(id);
            if (pos_cashiercounter == null)
            {
                return HttpNotFound();
            }
            return View(pos_cashiercounter);
        }

        // POST: /Company/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            POS_CASHIER_COUNTER pos_cashiercounter = db.POS_CASHIER_COUNTER.Find(id);
            db.POS_CASHIER_COUNTER.Remove(pos_cashiercounter);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
