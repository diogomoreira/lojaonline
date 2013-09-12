using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LojaOnline.Comum;
using LojaOnline.MVC.Models;

namespace LojaOnline.MVC.Controllers
{
    public class HomeController : Controller
    {
        // Repositorio
        
        public HomeController():base()
        {
            
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Visualizar(long id)
        {
            return View();
        }

        public ActionResult Contato(Contato contato)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", contato);
            }
            return View(contato);
        }


        



    }
}
