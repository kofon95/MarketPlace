using System.Web.Mvc;
using DAL;
using DAL.Functions;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        IFunctions _functions = FunctionsManager.Manager.Functions;
        
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
    }
}