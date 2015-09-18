using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ProdMan_Models.Dal
{
    public class BtwDal
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();

        /// <summary>
        /// Reutrns a List for a combobox with all the availble btw value's
        /// </summary>
        /// <returns></returns>
        public List<SelectListItem> GetBtwSelectListItems()
        {
            return _db.Btws.Select(
                taxValue => new SelectListItem
                {
                    Text = taxValue.BtwNaam,
                    Value = taxValue.Id.ToString()
                }).ToList();
        }
    }
}
