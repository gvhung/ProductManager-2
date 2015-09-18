using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using ProdMan_Models;
using ProdMan_Models.Tables;

namespace ProdMan.Controllers
{
    public class ProductEigenschappenKoppelingsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ProductEigenschappenKoppelings
        public ActionResult Index()
        {
            return View(db.ProductEigenschappenKoppelingen.ToList());
        }

        // GET: ProductEigenschappenKoppelings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductEigenschappenKoppeling productEigenschappenKoppeling = db.ProductEigenschappenKoppelingen.Find(id);
            if (productEigenschappenKoppeling == null)
            {
                return HttpNotFound();
            }
            return View(productEigenschappenKoppeling);
        }

        // GET: ProductEigenschappenKoppelings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductEigenschappenKoppelings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ProductEigenschappenId,ProductId,AanmaakDatum")] ProductEigenschappenKoppeling productEigenschappenKoppeling)
        {
            if (ModelState.IsValid)
            {
                db.ProductEigenschappenKoppelingen.Add(productEigenschappenKoppeling);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productEigenschappenKoppeling);
        }

        // GET: ProductEigenschappenKoppelings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductEigenschappenKoppeling productEigenschappenKoppeling = db.ProductEigenschappenKoppelingen.Find(id);
            if (productEigenschappenKoppeling == null)
            {
                return HttpNotFound();
            }
            return View(productEigenschappenKoppeling);
        }

        // POST: ProductEigenschappenKoppelings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ProductEigenschappenId,ProductId,AanmaakDatum")] ProductEigenschappenKoppeling productEigenschappenKoppeling)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productEigenschappenKoppeling).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productEigenschappenKoppeling);
        }

        // GET: ProductEigenschappenKoppelings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductEigenschappenKoppeling productEigenschappenKoppeling = db.ProductEigenschappenKoppelingen.Find(id);
            if (productEigenschappenKoppeling == null)
            {
                return HttpNotFound();
            }
            return View(productEigenschappenKoppeling);
        }

        // POST: ProductEigenschappenKoppelings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductEigenschappenKoppeling productEigenschappenKoppeling = db.ProductEigenschappenKoppelingen.Find(id);
            db.ProductEigenschappenKoppelingen.Remove(productEigenschappenKoppeling);
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
