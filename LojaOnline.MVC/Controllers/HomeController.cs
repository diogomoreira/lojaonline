using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LojaOnline.Comum;
using LojaOnline.MVC.Models;

namespace LojaOnline.MVC.Controllers
{
    public class HomeController : Controller
    {
        // Repositorio
        
        public HomeController():base()
        {
            
        }

        public ActionResult Index()
        {
            using (LojaOnlineEntities context = new LojaOnlineEntities())
            {
                Categoria categoria = context.Categorias.FirstOrDefault();

                Produto produto = new Produto();
                produto.Nome = "Livro de ASP.NET MVC 4";
                produto.Categoria = categoria;
                produto.Preco = (decimal)546.22;

                context.Produtos.Add(produto);

                context.SaveChanges();
            }
            return View();
        }

        public ActionResult Visualizar(long id)
        {
            return View();
        }

        public ActionResult Contato(Contato contato)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", contato);
            }
            return View(contato);
        }


        



    }
}
