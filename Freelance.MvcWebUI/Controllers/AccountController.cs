using Freelance.DAL.Abstract;
using Freelance.DAL.Concrete.EntityFramework;
using Freelance.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Freelance.MvcWebUI.Controllers
{
    public class AccountController : Controller
    {

        IUserDal _userDal = new EFUserDal();

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Login()
        {
            bool isAuthenticated = (System.Web.HttpContext.Current.User != null) &&
                System.Web.HttpContext.Current.User.Identity.IsAuthenticated;

            if (isAuthenticated)
            {
                return RedirectToAction("index", "Home");
            }
            else
            {
                return View();
            }

        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(FormCollection formCollection)
        {
            string userName = formCollection["userName"];
            string password = formCollection["password"];
            User user = _userDal.GetUserByMailAndPassword(userName, password);

            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(user.Name, true);
                Session["UserID"] = user.Id.ToString();
                Session["Name"] = user.Name.ToString();
                Session["Credit"] = user.Credit.ToString();
                return RedirectToAction("index", "Home");
            }
            else
            {
                ViewBag.loginError = "Kullanıcı adı veya şifre geçersiz";
                return View();
            }

        }

        [HttpGet]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Register(FormCollection formCollection)
        {

            bool isAuthenticated = (System.Web.HttpContext.Current.User != null) &&
              System.Web.HttpContext.Current.User.Identity.IsAuthenticated;

            if (isAuthenticated)
            {
                return RedirectToAction("index", "Home");
            }
            else
            {

                string userName = formCollection["registerName"];
                string mail = formCollection["registerMail"];
                string password = formCollection["registerPassword"];

                User user = _userDal.GetUserByMail(mail);

                if (user != null)
                {
                    ViewData["registerErrormessage"] = "Girilen mail üzerine kayıtlı bir kullanıcı zaten mevcut. Başka bir tane deneyin.";
                    return View("Login");
                }
                else
                {
                    user = new User();

                    user.Name = userName;
                    user.Mail = mail;
                    user.Password = password;

                    _userDal.CreateUser(user);

                    ViewData["registerSuccessmessage"] = "Hesap oluşturuldu. Giriş yapabilirsiniz.";
                    return View("Login");
                }
            }
        }
    }
}