using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LojaOnline.MVC.Models
{
    public class Contato
    {
        [DisplayName("Informe o seu nome")]
        [Required(ErrorMessage="Campo obrigatório")]
        public string Nome { get; set; }

        [DisplayName("Informe o seu texto")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Texto { get; set; }
    }
}