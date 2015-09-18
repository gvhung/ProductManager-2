using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using ProdMan_Models.Tables;

namespace ProdMan.Controllers
{
    public class ProductenController : Controller
    {
        private readonly ProdMan_Models.ApplicationDbContext _db = new ProdMan_Models.ApplicationDbContext();

        // GET: Producten
        public ActionResult Index()
        {
            return View(_db.Producten.ToList());
        }

        // GET: Producten/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product producten = _db.Producten.Find(id);
            if (producten == null)
            {
                return HttpNotFound();
            }
            return View(producten);
        }

        // GET: Producten/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Producten/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Naam,Nummer,BtwId,Prijs")] Product producten)
        {
            if (_db.Producten.Any(o => o.Nummer == producten.Nummer))
            {
                //Number is already used
                var mod = ModelState.First(c => c.Key == "Nummer");
                mod.Value.Errors.Add("Dit nummer is al in gebruik!");
            }

            if (!ModelState.IsValid)
            {
                //Model is invalid
                return View(producten);
            }

            _db.Producten.Add(producten);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Producten/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product producten = _db.Producten.Find(id);
            if (producten == null)
            {
                return HttpNotFound();
            }
            return View(producten);
        }

        // POST: Producten/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Naam,Nummer,BtwId,Prijs")] Product producten)
        {
            if (_db.Producten.Any(o => o.Nummer == producten.Nummer && o.Id != producten.Id))
            {                
                // Number is already used
                var mod = ModelState.First(c => c.Key == "Nummer");
                mod.Value.Errors.Add("Dit nummer is al in gebruik!");
            }

            if (!ModelState.IsValid)
            {
                // Model is not valid!
                return View(producten);
            }

            _db.Entry(producten).State = EntityState.Modified;
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: Producten/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product producten = _db.Producten.Find(id);
            if (producten == null)
            {
                return HttpNotFound();
            }
            return View(producten);
        }

        // POST: Producten/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product producten = _db.Producten.Find(id);
            _db.Producten.Remove(producten);
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
