using LojaOnline.Comum;
using LojaOnline.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LojaOnline.MVC.Areas.Admin.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class CategoriaController : Controller
    {
        private CategoriaRepositorio _repositorio;

        public CategoriaController(CategoriaRepositorio repositorio)
        {
            _repositorio = repositorio;
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

        public ActionResult Remover(long Id)
        {
            _repositorio.RemoveCategoria(Id);
            return RedirectToAction("Listar", "Categoria", new { Area = "" });
        }

    }
}
