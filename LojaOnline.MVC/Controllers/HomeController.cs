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
        public LojaOnlineEntities _contexto;
        
        public HomeController(LojaOnlineEntities contexto):base()
        {
            _contexto = contexto;
        }

        public ActionResult Index()
        {
            /*
             * 40010 - Sedex Varejo
             * 40045 - Sedex a Cobrar
             * 40215 - Sedex 10 Varejo
             * 40290 - Sedex Hoje Varejo
             * 41106 - PAC Varejo
             * 
             */
            //Correios.CalcPrecoPrazoWSSoapClient client = new Correios.CalcPrecoPrazoWSSoapClient();
            //var resposta = client.CalcPrecoPrazo(null, null, "41106", "58900000", "58040660", "1", 1, 18, 6, 12, 0, "N", 10, "N");

            //foreach (var svc in resposta.Servicos)
            //{
            //    Console.Out.WriteLine(svc.Valor);
            //}

            //EmailController email = new EmailController();
            //email.Index().Deliver();

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
