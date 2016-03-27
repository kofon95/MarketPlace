using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;
using DAL.Functions;

namespace WebApp.Controllers
{
    public class SearchController : Controller
    {
        private IFunctions _functions = FunctionsManager.Manager.Functions;
        // GET: Search
        public ActionResult Agro(int? min_price, int? max_price, string text = "")
        {
            var products = _functions.GetProducts(text);
            if (min_price != null)
                products = products.Where(p => p.price >= min_price.Value);
            if (max_price != null)
                products = products.Where(p => p.price <= max_price.Value);

            return View(products);
        }
    }
}