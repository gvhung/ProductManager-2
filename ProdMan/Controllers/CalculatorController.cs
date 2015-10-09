using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ProdMan_Models;
using ProdMan_Models.Dal;
using ProdMan_Models.Tables;
using ProdMan_Models.View;

namespace ProdMan.Controllers
{
    public class CalculatorController : Controller
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();
        private readonly OverviewDal _overviewDal = new OverviewDal();

        // GET: Overview
        public ActionResult Index()
        {
            var oReturn = new OverView
            {
                Leveranciers = _overviewDal.GetAllLeveranciers(),
                Products = _overviewDal.GetAllProducts(),
                ProductGroeps = _overviewDal.GetAllProductGroep()
            };

            return View(oReturn);
        }

        // /Calculator/JsonResultProductList/
        [HttpGet]
        public JsonResult JsonResultProductList(bool o = true, bool b = true, bool a = true)
        {
            List<Product> jReturn = _db.Producten.ToList();

            return Json(jReturn, JsonRequestBehavior.AllowGet);
        }
    }
}