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
    public class ProductEigenschappenController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ProductEigenschappen
        public ActionResult Index()
        {
            return View(db.ProductEigenschappen.ToList());
        }

        // GET: ProductEigenschappen/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductEigenschappen productEigenschappen = db.ProductEigenschappen.Find(id);
            if (productEigenschappen == null)
            {
                return HttpNotFound();
            }
            return View(productEigenschappen);
        }

        // GET: ProductEigenschappen/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductEigenschappen/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Naam,Nummer,PrijsFactor,Toeslag")] ProductEigenschappen productEigenschappen)
        {
            if (ModelState.IsValid)
            {
                db.ProductEigenschappen.Add(productEigenschappen);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productEigenschappen);
        }

        // GET: ProductEigenschappen/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductEigenschappen productEigenschappen = db.ProductEigenschappen.Find(id);
            if (productEigenschappen == null)
            {
                return HttpNotFound();
            }
            return View(productEigenschappen);
        }

        // POST: ProductEigenschappen/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Naam,Nummer,PrijsFactor,Toeslag")] ProductEigenschappen productEigenschappen)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productEigenschappen).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productEigenschappen);
        }

        // GET: ProductEigenschappen/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductEigenschappen productEigenschappen = db.ProductEigenschappen.Find(id);
            if (productEigenschappen == null)
            {
                return HttpNotFound();
            }
            return View(productEigenschappen);
        }

        // POST: ProductEigenschappen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductEigenschappen productEigenschappen = db.ProductEigenschappen.Find(id);
            db.ProductEigenschappen.Remove(productEigenschappen);
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
