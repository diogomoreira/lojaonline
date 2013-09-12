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
        public Repositorio _repositorio { get; set; }

        public ProdutoController()
        {
            _repositorio = new Repositorio();
        }

        public ActionResult Index()
        {
            return RedirectToAction("listar");
        }

        public ActionResult Listar()
        {
            List<Produto> produtos = _repositorio.ObterProdutos();
            return View(produtos);
        }

    }
}
