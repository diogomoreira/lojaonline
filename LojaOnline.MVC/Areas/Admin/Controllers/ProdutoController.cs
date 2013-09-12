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
        public Repositorio _repositorio { get; set; }

        public ProdutoController()
        {
            _repositorio = new Repositorio();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Cadastrar()
        {
            var items = from c in _repositorio.ObterCategorias()
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
            //Categoria cat = _repositorio.ObterCategorias().Single(x => x.Codigo == p.Categoria.Codigo);
            //p.Categoria = cat;
            foreach (var entry in ModelState.Where(x => x.Key.StartsWith("Categoria.")))
            {
                entry.Value.Errors.Clear();
            }

            if (!ModelState.IsValid)
            {
                var items = from c in _repositorio.ObterCategorias()
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
                _repositorio.AddProduto(p);
                return RedirectToAction("listar");
            }
        }

        public ActionResult Visualizar(long id)
        {
            Produto p = _repositorio.ObterProdutos().Where(x => x.Codigo == id).SingleOrDefault();
            if (p != null)
            {
                return View(p);
            }
            else
            {
                return View("PaginaNaoEncontrada");
            }
        }

        public ActionResult Listar()
        {
            List<Produto> produtos = _repositorio.ObterProdutos();
            return View(produtos);
        }

    }
}
