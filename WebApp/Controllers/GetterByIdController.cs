using System;
using System.Web.Mvc;
using DAL;
using DAL.Functions;
using WebApp.Core;

namespace WebApp.Controllers
{
    public class GetterByIdController : Controller
    {
        IFunctions _functions = FunctionsManager.Manager.Functions;
        RepositoryManager _context = RepositoryManager.Manager;

        public ActionResult GetAgro(string word, int id)
        {
            var product = _functions.GetProduct(id);
            if (product == null)
            {
                Log.I("File not found with id ", id);
                return HttpNotFound("Product Not Found. With id " + id);
            }

            var realWord = product.product_name.Replace(' ', '_');
            if (realWord != word)
            {
                Log.I("Wrong \"word\" for id - ", id);
                return RedirectToAction(nameof(GetAgro), new { word=realWord, id=id });
            }

            AddView(id);

            return View(product);
        }

        public ActionResult GetClothes(string word, int id)
        {
            return HttpNotFound("Clothes page not implemented");
        }

        public void AddView(int id)
        {
            var value = Request.Cookies[MvcApplication.GuestHashCookie].Value;
            if (value == null)
            {
                Log.E("Hash in cookie not exists");
            }
            else
            {
                object sess = Session["guest_id"];
                if (sess == null)
                {
                    Log.W("Session has not guest_id");
                }
                else
                {
                    var guestId = (int)sess;
                    var view = new ProductView { guest_id = guestId, product_id = id, view_date = DateTime.Now, };
                    _context.ProductView.Save(view);
                }
            }
        }
    }
}