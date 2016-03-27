using System;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using DAL;
using WebApp.Core;

namespace WebApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public const string GuestHashCookie = "guest_hash";


        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebAPI.WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected void Application_AcquireRequestState()
        {
            var hash = Request.Cookies[GuestHashCookie];
            if (hash != null) return;


            if (HttpContext.Current.Session == null)
            {
                Log.E("Session no work");
                return;
            }

            var cookie = new HttpCookie(GuestHashCookie, Util.GetRandomString());
            Response.Cookies.Add(cookie);


            var guest = new Guest
            {
                ip_address = Request.ServerVariables["REMOTE_ADDR"],
                languages = Request.Headers["accept-language"],
                user_agent = Request.UserAgent,
                coming_date = DateTime.Now,
            };

            int id;
            try
            {
                id = RepositoryManager.Manager.Guest.Save(guest).id;
            }
            catch (Exception e)
            {
                Log.E("Guest not added. " + e.Message);
                return;
            }
            Session["guest_id"] = id;
            Log.D("Create cookie: hash = " + cookie.Value);
        }
    }
}
