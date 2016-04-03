using System;
using System.IO;
using System.Security.Principal;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using DAL;
using WebApp.Core;

//[assembly: log4net.Config.XmlConfigurator(ConfigFile = "Web.config", Watch = true)]
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
            
            log4net.Config.XmlConfigurator.Configure(new FileInfo(Server.MapPath("~/Web.config")));
            Log.I("Application started");
        }
        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            var authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];

            if (authCookie != null)
            {
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);

                string[] roles = ticket.UserData.Split(',');
                Context.User = new GenericPrincipal(new GenericIdentity(ticket.Name), roles);
            }
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
