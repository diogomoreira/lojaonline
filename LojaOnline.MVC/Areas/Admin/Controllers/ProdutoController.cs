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
    public class ProdutoController : Controller
    {
        private CategoriaRepositorio _repositorioCategoria;
        private ProdutoRepositorio _repositorioProduto;

        public ProdutoController(ProdutoRepositorio produtoRepositorio, CategoriaRepositorio categoriaRepositorio)
        {
            _repositorioCategoria = categoriaRepositorio;
            _repositorioProduto = produtoRepositorio;
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

        public ActionResult Editar(long Id)
        {
            var items = from c in _repositorioCategoria.Listar()
                        select new SelectListItem()
                        {
                            Text = c.Nome,
                            Value = c.Codigo.ToString()
                        };

            ViewBag.Categorias = items.ToList();
            Produto p = _repositorioProduto.RecuperarProduto(Id);
            return View(p);
        }

        [HttpPost]
        public ActionResult Atualizar(Produto p)
        {
            _repositorioProduto.Atualizar(p);
            return RedirectToAction("Listar", "Produto", new { Area = "" });
        }

        public ActionResult Remover(long Id)
        {
            _repositorioProduto.RemoveProduto(Id);
            return RedirectToAction("Listar", "Produto", new { Area = "" });
        }

    }
}
