using LojaOnline.Comum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LojaOnline.MVC.Models
{
    public class ProdutoRepositorio
    {
        public void AddProduto(Produto produto)
        {
            using (LojaOnlineEntities context = new LojaOnlineEntities())
            {
                context.Produtos.Add(produto);
                context.SaveChanges();
            }
        }

        public void RemoveProduto(Produto produto)
        {
            using (LojaOnlineEntities context = new LojaOnlineEntities())
            {
                context.Produtos.Remove(produto);
                context.SaveChanges();
            }
        }

        public List<Produto> Listar()
        {
            using (LojaOnlineEntities context = new LojaOnlineEntities())
            {
                return context.Produtos.ToList();
            }
        }

        public List<ProdutoCategoria> ListarProdutos()
        {
            using (LojaOnlineEntities context = new LojaOnlineEntities())
            {
                var items = from p in context.Produtos
                            select new ProdutoCategoria()
                            {
                                CodigoProduto = p.Codigo,
                                Nome = p.Nome,
                                Preco = p.Preco,
                                NomeCategoria = p.Categoria.Nome
                            };
                return items.ToList();
            }
        }
    }
}