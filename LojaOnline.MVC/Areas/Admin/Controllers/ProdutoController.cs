using LojaOnline.Comum;
using LojaOnline.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LojaOnline.MVC.Areas.Admin.Controllers
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
            return View();
        }

        public ActionResult Cadastrar()
        {
            var items = from c in _repositorioCategoria.Listar()
                        select new SelectListItem()
                        {
                            Text = c.Nome,
                            Value = c.Codigo.ToString()
                        };

            ViewBag.Categorias = items.ToList();

            return View(new Produto());
        }

        [HttpPost]
        public ActionResult Salvar(Produto p)
        {
            Categoria cat = _repositorioCategoria.Listar().Single(x => x.Codigo == p.Categoria.Codigo);
            p.Categoria = cat;
            foreach (var entry in ModelState.Where(x => x.Key.StartsWith("Categoria.")))
            {
                entry.Value.Errors.Clear();
            }

            if (!ModelState.IsValid)
            {
                var items = from c in _repositorioCategoria.Listar()
                            select new SelectListItem()
                            {
                                Text = c.Nome,
                                Value = c.Codigo.ToString()
                            };

                ViewBag.Categorias = items.ToList();
                return View("Cadastrar", p);
            }
            else
            {
                _repositorioProduto.AddProduto(p);
                return View(p);
            }
        }

    }
}
