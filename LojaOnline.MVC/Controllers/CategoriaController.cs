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
        private CategoriaRepositorio _repositorio;

        public CategoriaController(CategoriaRepositorio repositorio)
        {
            _repositorio = repositorio;
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

        public ActionResult Visualizar(long Id)
        {
            return View(_repositorio.RecuperarCategoria(Id));
        }

        public ActionResult ListarProdutos(long Id)
        {
            List<ProdutoCategoria> produtosDaCategoria = _repositorio.ListarProdutos(Id);
            if (produtosDaCategoria.Count() == 0)
            {
                return View("SemRegistro");
            }
            ViewBag.Produtos = produtosDaCategoria;
            return View();
        }

    }
}
