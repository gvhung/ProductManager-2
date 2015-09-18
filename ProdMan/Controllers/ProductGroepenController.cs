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
    public class ProductGroepenController : Controller
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();

        // GET: ProductGroepen
        public ActionResult Index()
        {
            return View(_db.ProductGroepen.ToList());
        }

        // GET: ProductGroepen/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductGroep productGroep = _db.ProductGroepen.Find(id);
            if (productGroep == null)
            {
                return HttpNotFound();
            }
            return View(productGroep);
        }

        // GET: ProductGroepen/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductGroepen/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nummer,Naam")] ProductGroep productGroep)
        {
            if (_db.ProductGroepen.Any(o => o.Nummer == productGroep.Nummer))
            {                
                // Number is already used
                var mod = ModelState.First(c => c.Key == "Nummer");
                mod.Value.Errors.Add("Dit nummer is al in gebruik!");
            }

            if (!ModelState.IsValid)
            {
                // Model not valid!
                return View(productGroep);
            }

            _db.ProductGroepen.Add(productGroep);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: ProductGroepen/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductGroep productGroep = _db.ProductGroepen.Find(id);
            if (productGroep == null)
            {
                return HttpNotFound();
            }
            return View(productGroep);
        }

        // POST: ProductGroepen/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nummer,Naam")] ProductGroep productGroep)
        {
            if (_db.ProductGroepen.Any(o => o.Nummer == productGroep.Nummer && o.Id != productGroep.Id))
            {
                // Number is already used
                var mod = ModelState.First(c => c.Key == "Nummer");
                mod.Value.Errors.Add("Dit nummer is al in gebruik!");
            }

            if (!ModelState.IsValid)
            {
                // Model is not Valid
                return View(productGroep);
            }

            _db.Entry(productGroep).State = EntityState.Modified;
            _db.SaveChanges();
            
            return RedirectToAction("Index");
        }

        // GET: ProductGroepen/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductGroep productGroep = _db.ProductGroepen.Find(id);
            if (productGroep == null)
            {
                return HttpNotFound();
            }
            return View(productGroep);
        }

        // POST: ProductGroepen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductGroep productGroep = _db.ProductGroepen.Find(id);
            _db.ProductGroepen.Remove(productGroep);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
