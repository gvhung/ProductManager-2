using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ProdMan_Models.Dal
{
    public class LeverancierDal
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();

        /// <summary>
        /// Returns a List for a combobox with all the availble Leveranciers.
        /// </summary>
        /// <returns></returns>
        public List<SelectListItem> GetLeverancierSelectListItems()
        {
            return _db.Leveranciers.Select(
                leveranciers => new SelectListItem
                {
                    Text = leveranciers.Naam,
                    Value = leveranciers.Id.ToString()
                }).ToList();
        }
    }
}
