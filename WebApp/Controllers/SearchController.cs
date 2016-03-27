using System.Linq;
using System.Web.Mvc;
using DAL;
using DAL.Functions;
// ReSharper disable InconsistentNaming

namespace WebApp.Controllers
{
    public class SearchController : Controller
    {
        private IFunctions _functions = FunctionsManager.Manager.Functions;
        // GET: Search
        public ActionResult Agro(float? min_price, float? max_price, int? category_id, int? commodity_id, string text = "")
        {
            var products = _functions.GetProducts(text);
            if (min_price != null)
                products = products.Where(p => p.price >= min_price.Value);
            if (max_price != null)
                products = products.Where(p => p.price <= max_price.Value);

            if (commodity_id != null)
                products = products.Where(p => p.commodity_id == commodity_id.Value);
            else if (category_id != null)
                products = products.Where(p => p.category_id == category_id.Value);


            return View(products);
        }

        public ActionResult Clothes(float? min_price, float? max_price, string text = "")
        {
            return HttpNotFound("Clothes page not implemented");
        }
    }
}