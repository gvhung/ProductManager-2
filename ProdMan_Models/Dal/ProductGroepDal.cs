using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ProdMan_Models.Dal
{
    public class ProductGroepDal
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();

        /// <summary>
        /// Returns a List for a combobox with all the availble product groepen.
        /// </summary>
        /// <returns></returns>
        public List<SelectListItem> GetProductGroepSelectListItems()
        {
            return _db.ProductGroepen.Select(
                productGroepen => new SelectListItem
                {
                    Text = productGroepen.Naam,
                    Value = productGroepen.Id.ToString()
                }).ToList();
        }
    }
}
