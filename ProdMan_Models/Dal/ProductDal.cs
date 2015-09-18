using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using ProdMan_Models.Tables;
using ProdMan_Models.View;

namespace ProdMan_Models.Dal
{
    public class ProductDal
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();

        public List<Btw> GetAllBtw()
        {
            return _db.Btws.ToList();
        }




        public List<ProductView> GetAllProducts()
        {
            var taxValueList = _db.Btws.ToList();
            var productGroepList = _db.ProductGroepen.ToList();
            var leverancierList = _db.Leveranciers.ToList();

            try
            {
                return _db.Producten.ToList().Select(p => new ProductView
                {
                    Product = p,
                    Btw = taxValueList.Find(t => t.Id == p.BtwId),
                    Leverancier = leverancierList.Find(l => l.Id == p.LeveranciersId),
                    ProductGroep = productGroepList.Find(o => o.Id == p.ProductgroepId)
                })
                .OrderBy(p => p.Product.Nummer)
                .ToList();
            }
                // TODO do something with the exception
            catch (Exception)
            {
                return new List<ProductView>();
            }
        }

        public List<ProductEigenschappenView> GetProductEigenschappenView()
        {
            var productList = _db.Producten.ToList();
            var productEigenschappenList = _db.ProductEigenschappen.ToList();

            try
            {
                return _db.ProductEigenschappenKoppelingen.ToList().Select(p => new ProductEigenschappenView
                {
                    Product = productList.Find(o => o.Id == p.ProductId),
                    ProductEigenschappen = productEigenschappenList.Find(e => e.Id == p.ProductEigenschappenId)

                }).ToList();
            }
                // TODO do something with the exception
            catch (Exception)
            {
                return new List<ProductEigenschappenView>();
            }
        }
    }
}
