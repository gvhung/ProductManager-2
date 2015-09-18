using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using ProdMan_Models;
using ProdMan_Models.Dal;
using ProdMan_Models.Tables;
using ProdMan_Models.View;

namespace ProdMan.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();

        // GET: Product
        public ActionResult Index()
        {
            return View(new ProductDal().GetAllProducts());
        }

        // GET: Product/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = _db.Producten.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductView productView)
        {

            //var product = new Product();
            //product = productView.Product;
            //product.Btw = productView.Btw;
            if (_db.Producten.Any(o => o.Nummer == productView.Product.Nummer))
            {
                //Number is already used
                var mod = ModelState.First(c => c.Key == "Nummer");
                mod.Value.Errors.Add("Dit nummer is al in gebruik!");
            }

            if (!ModelState.IsValid)
            {
                return View(productView.Product);
            }

            _db.Producten.Add(productView.Product);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var productview = new ProductView
            {
                Product = _db.Producten.Find(id)
            };

            if (productview.Product == null)
            {
                return HttpNotFound();
            }
            return View(productview);
        }

        // POST: Product/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductView productView)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(productView.Product).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productView.Product);
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var productview = new ProductView();

            Product product = _db.Producten.Find(id);
            productview.Product = product;

            if (productview.Product == null)
            {
                return HttpNotFound();
            }
            return View(productview);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = _db.Producten.Find(id);
            _db.Producten.Remove(product);
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
