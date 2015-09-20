using System;
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
        private readonly ProductDal _productDal = new ProductDal();

        // GET: Product
        public ActionResult Index()
        {
            return View(_productDal.GetAllProducts());
        }

        // GET: Product/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var product = _productDal.GetSingleProductView(id);

            if (product.Product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            var oReturn = new ProductView
            {
                Product = _productDal.GetNewProduct()
            };

            return View(oReturn);
        }

        // POST: Product/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductView productView)
        {
            var dateNow = DateTime.Now;

            if (productView.Product.AanmaakDatum == DateTime.MinValue)
            {
                // AanmaakDatum Datetime is not set
                productView.Product.AanmaakDatum = dateNow;
            }

            // Set edit date equal to now
            productView.Product.WijziginsDatum = dateNow;

            //var product = productView.Product;

            //var product = new Product();
            //product = productView.Product;
            //product.Btw = productView.Btw;
            if (_db.Producten.Any(o => o.Nummer == productView.Product.Nummer))
            {
                //Number is already used
                var mod = ModelState.First(c => c.Key == "Product.Nummer");
                mod.Value.Errors.Add("Dit nummer is al in gebruik!");
            }

            if (!ModelState.IsValid)
            {
                return View(productView);
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
            productView.Product.WijziginsDatum = DateTime.Now;

            if (_db.Producten.Any(o => o.Nummer == productView.Product.Nummer && o.Id != productView.Product.Id))
            {
                // Number is already used
                var mod = ModelState.First(c => c.Key == "Product.Nummer");
                mod.Value.Errors.Add("Dit nummer is al in gebruik!");
            }

            if (!ModelState.IsValid)
            {
                // Model is not valid!
                return View(productView);
            }

            _db.Entry(productView.Product).State = EntityState.Modified;
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var product = _productDal.GetSingleProductView(id);

            if (product.Product == null)
            {
                return HttpNotFound();
            }
            return View(product);
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
