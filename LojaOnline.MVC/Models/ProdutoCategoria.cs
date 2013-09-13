using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LojaOnline.MVC.Models
{
    public class ProdutoCategoria
    {
        public long CodigoProduto { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public string NomeCategoria { get; set; }

        public ProdutoCategoria()
        {
                
        }
    }
}