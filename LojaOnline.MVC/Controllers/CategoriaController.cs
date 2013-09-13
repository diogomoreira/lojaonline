using LojaOnline.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LojaOnline.Comum;

namespace LojaOnline.MVC.Controllers
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
            
            return View("Listar");
        }

        public ActionResult Listar()
        {
            List<Categoria> categorias = _repositorio.Listar();
            return View(categorias);
        }

    }
}
