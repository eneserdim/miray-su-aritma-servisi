using ALPAY_WEP_PROJECT.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ALPAY_WEP_PROJECT.Controllers
{
    public class AccountController : Controller
    {
        // GET: Security
        Context c = new Context();
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User p)
        {
            var bilgiler = c.Users.FirstOrDefault(x => x.UserName == p.UserName && x.Password == p.Password);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.UserName, false);
                Session["UserName"] = bilgiler.UserName.ToString();
                return RedirectToAction("hizlimenu", "Admin");

            }
            else
            {
                return RedirectToAction("Login", "Account");
            }

        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}