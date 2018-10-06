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
    public class CashierStatusController : Controller
    {
        private Entities db = new Entities();


        // GET: CashierStatus
        public ActionResult Index()
        {
            return View(db.POS_USER_SESSION.ToList());
        }

        // GET: CashierStatus/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            POS_USER_SESSION pOS_USER_SESSION = db.POS_USER_SESSION.Find(id);
            if (pOS_USER_SESSION == null)
            {
                return HttpNotFound();
            }
            return View(pOS_USER_SESSION);
        }

        // GET: CashierStatus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CashierStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "USER_SESSION_ID,USER_ID,COUNTER_ID,LOGIN_DATETIME,ISSUCCESS_LOGIN_FLAG,IP_ADDRESS,LOGOUT_DATETIME,ISSUCCESS_LOGOUT_FLAG")] POS_USER_SESSION pOS_USER_SESSION)
        {
            if (ModelState.IsValid)
            {
                db.POS_USER_SESSION.Add(pOS_USER_SESSION);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pOS_USER_SESSION);
        }

        // GET: CashierStatus/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            POS_USER_SESSION pOS_USER_SESSION = db.POS_USER_SESSION.Find(id);
            if (pOS_USER_SESSION == null)
            {
                return HttpNotFound();
            }
            return View(pOS_USER_SESSION);
        }

        // POST: CashierStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "USER_SESSION_ID,USER_ID,COUNTER_ID,LOGIN_DATETIME,ISSUCCESS_LOGIN_FLAG,IP_ADDRESS,LOGOUT_DATETIME,ISSUCCESS_LOGOUT_FLAG")] POS_USER_SESSION pOS_USER_SESSION)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pOS_USER_SESSION).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pOS_USER_SESSION);
        }

        // GET: CashierStatus/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            POS_USER_SESSION pOS_USER_SESSION = db.POS_USER_SESSION.Find(id);
            if (pOS_USER_SESSION == null)
            {
                return HttpNotFound();
            }
            return View(pOS_USER_SESSION);
        }

        // POST: CashierStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            POS_USER_SESSION pOS_USER_SESSION = db.POS_USER_SESSION.Find(id);
            db.POS_USER_SESSION.Remove(pOS_USER_SESSION);
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
