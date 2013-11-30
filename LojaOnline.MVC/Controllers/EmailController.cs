using ActionMailer.Net.Mvc;
using LojaOnline.Comum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LojaOnline.MVC.Controllers
{
    public class EmailController : MailerBase
    {
        //
        // GET: /Email/

        public EmailResult Index()
        {
            To.Add("emailaqui@provedor.com");
            Subject = "Assunto aqui";
            return Email("Index", new Categoria() { Nome = "Livros" });
        }

    }
}
