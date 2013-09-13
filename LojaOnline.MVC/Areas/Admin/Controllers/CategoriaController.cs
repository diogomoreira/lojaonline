using LojaOnline.Comum;
using LojaOnline.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LojaOnline.MVC.Areas.Admin.Controllers
{
    public class CategoriaController : Controller
    {
        public CategoriaRepositorio _repositorio { get; set; }

        public CategoriaController()
        {
            _repositorio = new CategoriaRepositorio();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Salvar(Categoria cat)
        {
            if (!ModelState.IsValid)
            {
                return View("Cadastrar", cat);
            }
            _repositorio.AddCategoria(cat);
            return View(cat);
        }

        public ActionResult Cadastrar()
        {
            return View();
        }

    }
}
