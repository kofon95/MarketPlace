using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DAL;
using WebApp.Core;
using WebApp.Core.ViewModel;
using WebApp.Properties;
using Roles = WebApp.Core.Roles;
using System.Security.Cryptography;
using System.Text;
using WebApp.Core.Private;

namespace WebApp.Controllers
{
    public class UserController : Controller
    {
        RepositoryManager _manager = RepositoryManager.Manager;

        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(UserViewModel.SignUp signUpModel, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (_manager.User.GetAll().FirstOrDefault(u => u.login == signUpModel.Login) != null)
            {
                Log.I("User is existing");
                ModelState.AddModelError("", Resources.UserIsExisting);
                return View();
            }

            var password = PasswordEncoder.Encode(signUpModel.Password);

            var saveUser = _manager.User.Save(new User
            {
                login = signUpModel.Login,
                password = password,
                given_name = signUpModel.GivenName,
                surname = signUpModel.Surname,
                birthday = signUpModel.Birthday,
                roles = Roles.User,
            });
            AuthenticateUser(saveUser.id, saveUser.roles);

            return Redirect(returnUrl ?? "/");
        }



        private void AuthenticateUser(int userId, string roles)
        {
            string userIdStr = userId.ToString();
            var ticket = new FormsAuthenticationTicket(
                1,
                userIdStr,
                DateTime.Now,
                DateTime.Now.Add(FormsAuthentication.Timeout),
                false,
                roles);

            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(ticket));
            Response.Cookies.Add(cookie);

            Log.D("User authenticate: " + userIdStr);
        }

        [HttpGet]
        public ActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(UserViewModel.SignIn model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                Log.W("ModelState is not valid in SignIn. Email - " + model?.Login);
                return View();
            }

            var user = _manager.User.GetAll().SingleOrDefault(u => u.login == model.Login);
            if (user == null)
            {
                Log.D("User not exists, login = " + model.Login);
                ModelState.AddModelError("", Resources.UserIsNotExisting);
                return View();
            }

            string password = PasswordEncoder.Encode(model.Password);
            if (password != user.password)
            {
                Log.D("Wrong password by email - " + model.Login);
                ModelState.AddModelError("", Resources.WrongPassword);
                return View();
            }

            AuthenticateUser(user.id, user.roles);
            return Redirect(returnUrl ?? "/");
        }

        public ActionResult SignOut()
        {
            Log.T("SignOut: " + User.Identity.Name);
            FormsAuthentication.SignOut();

            var referer = Request.UrlReferrer;
            if (referer?.LocalPath.StartsWith("/Admin") == false)
                return Redirect(referer.AbsoluteUri);
            return Redirect("/");
        }
    }
}