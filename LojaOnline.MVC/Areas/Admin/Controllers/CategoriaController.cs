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
        public Repositorio _repositorio { get; set; }

        public CategoriaController()
        {
            _repositorio = new Repositorio();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Visualizar(long id)
        {
            Categoria categoria = _repositorio.ObterCategorias().Where(x => x.Codigo == id).Single();
            if (categoria != null)
            {
                ViewBag.Categoria = categoria;
                List<Produto> produtos = _repositorio.ObterProdutos();
                return View(produtos);
            }
            else
            {
                return View("PaginaNaoEncontrada");
            }

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

        public ActionResult Listar()
        {
            List<Categoria> categorias = _repositorio.ObterCategorias();
            return View(categorias);
        }

    }
}
