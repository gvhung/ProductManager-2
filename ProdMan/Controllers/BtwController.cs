using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProdMan_Models;
using ProdMan_Models.Tables;

namespace ProdMan.Controllers
{
    public class BtwController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Btw
        public ActionResult Index()
        {
            return View(db.Btws.ToList());
        }

        // GET: Btw/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Btw btw = db.Btws.Find(id);
            if (btw == null)
            {
                return HttpNotFound();
            }
            return View(btw);
        }

        // GET: Btw/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Btw/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,BtwNaam,BtwValue")] Btw btw)
        {
            if (ModelState.IsValid)
            {
                db.Btws.Add(btw);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(btw);
        }

        // GET: Btw/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Btw btw = db.Btws.Find(id);
            if (btw == null)
            {
                return HttpNotFound();
            }
            return View(btw);
        }

        // POST: Btw/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,BtwNaam,BtwValue")] Btw btw)
        {
            if (ModelState.IsValid)
            {
                db.Entry(btw).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(btw);
        }

        // GET: Btw/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Btw btw = db.Btws.Find(id);
            if (btw == null)
            {
                return HttpNotFound();
            }
            return View(btw);
        }

        // POST: Btw/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Btw btw = db.Btws.Find(id);
            db.Btws.Remove(btw);
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
