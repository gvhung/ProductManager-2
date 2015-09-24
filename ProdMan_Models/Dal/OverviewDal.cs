using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProdMan_Models.Tables;
using ProdMan_Models.View;

namespace ProdMan_Models.Dal
{
    public class OverviewDal
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();

        public List<Product> GetAllProducts()
        {
            return _db.Producten.ToList();
        }

        public List<Leverancier> GetAllLeveranciers()
        {
            return _db.Leveranciers.ToList();
        }

        public List<ProductGroep> GetAllProductGroep()
        {
            return _db.ProductGroepen.ToList();
        }
    }
}
