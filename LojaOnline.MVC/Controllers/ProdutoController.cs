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
            var items = from p in _repositorioProduto.Listar()
                        from c in _repositorioCategoria.Listar()
                        where p.CodigoCategoria == c.Codigo
                        select new ProdutoCategoria()
                        {
                            CodigoProduto = p.Codigo,
                            Nome = p.Nome,
                            Preco = p.Preco,
                            NomeCategoria = c.Nome
                        };

            ViewBag.Produtos = items.ToList();
            return View();
        }

    }
}
