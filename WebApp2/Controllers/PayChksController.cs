using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApp2.Models;

namespace WebApp2.Controllers
{
    public class PayChksController : Controller
    {
        private WebApp2Context db = new WebApp2Context();

        // GET: PayChks
        public ActionResult Index()
        {
            return View(db.PayChks.ToList());
        }

        // GET: PayChks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PayChk payChk = db.PayChks.Find(id);
            if (payChk == null)
            {
                return HttpNotFound();
            }
            return View(payChk);
        }

        // GET: PayChks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PayChks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,EmoID,Payee")] PayChk payChk)
        {
            if (ModelState.IsValid)
            {
                db.PayChks.Add(payChk);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(payChk);
        }

        // GET: PayChks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PayChk payChk = db.PayChks.Find(id);
            if (payChk == null)
            {
                return HttpNotFound();
            }
            return View(payChk);
        }

        // POST: PayChks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,EmoID,Payee")] PayChk payChk)
        {
            if (ModelState.IsValid)
            {
                db.Entry(payChk).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(payChk);
        }

        // GET: PayChks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PayChk payChk = db.PayChks.Find(id);
            if (payChk == null)
            {
                return HttpNotFound();
            }
            return View(payChk);
        }

        // POST: PayChks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PayChk payChk = db.PayChks.Find(id);
            db.PayChks.Remove(payChk);
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
