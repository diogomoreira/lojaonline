using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace LojaOnline.MVC.Controllers
{
    public class AcessoController : Controller
    {

        public ActionResult Index()
        {
            return RedirectToAction("Login");
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormLogin model)
        {
            if (Membership.ValidateUser(model.Login, model.Senha))
            {
                FormsAuthentication.SetAuthCookie(model.Login, model.PermanecerConectado);
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

    }

    public class FormLogin
    {
        public string Login { get; set; }
        public string Senha { get; set; }
        public bool PermanecerConectado { get; set; }
    }
}
