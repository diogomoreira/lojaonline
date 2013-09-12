using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaOnline.Comum
{
    public class Carrinho
    {
        public delegate void AoAdicionarProdutoEventHandler(Produto p);
        public event AoAdicionarProdutoEventHandler AoAdicionarProduto;

        public List<Produto> Produtos
        {
            get;
            set;
        }

        public Carrinho()
        {
            this.Produtos = new List<Produto>();
        }

        public bool AdicionarProduto(Produto p)
        {
            this.Produtos.Add(p);
            if (this.AoAdicionarProduto != null)
            {
                this.AoAdicionarProduto(p);
            }
            return true;
        }

        public decimal CalcularTotal()
        {
            return this.Produtos.Sum(x => x.Preco);
        }
    }
}
