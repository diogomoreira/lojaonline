using LojaOnline.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LojaOnline.Comum;

namespace LojaOnline.MVC.Controllers
{
    public class ProdutoController : Controller
    {
        public CategoriaRepositorio _repositorioCategoria { get; set; }
        public ProdutoRepositorio _repositorioProduto { get; set; }

        public ProdutoController()
        {
            _repositorioCategoria = new CategoriaRepositorio();
            _repositorioProduto = new ProdutoRepositorio();
        }

        public ActionResult Index()
        {
            return RedirectToAction("Listar");
        }

        public ActionResult Listar()
        {
            ViewBag.Produtos = _repositorioProduto.ListarProdutos();
            return View();
        }

    }
}
