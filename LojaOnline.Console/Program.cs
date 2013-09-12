using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LojaOnline.Comum;

namespace LojaOnline.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Produtos de teste
            Produto produto1 = new Produto();
            produto1.Codigo = 1;
            produto1.Nome = "Revista Digital";
            produto1.Preco = (decimal) 12.5;

            Produto produto2 = new Produto();
            produto2.Codigo = 2;
            produto2.Nome = "Alguma coisa Magazine®";
            produto2.Preco = (decimal) 1.2;
            #endregion

            Carrinho carrinho = new Carrinho();
            carrinho.AoAdicionarProduto += carrinho_AoAdicionarProduto;
            carrinho.AdicionarProduto(produto1);
            carrinho.AdicionarProduto(produto2);
            System.Console.WriteLine("Total no carrinho: " + carrinho.CalcularTotal().ToString("c"));

            System.Console.ReadKey();
        }

        static void carrinho_AoAdicionarProduto(Produto produto)
        {
            string mensagem = String.Format("Produto: {0} / Preço: {1:c} / Data: {2:dd/MM/yyyy}", 
                produto.Nome, produto.Preco, DateTime.Now);
            System.Console.WriteLine(mensagem);    
        }
    }
}
