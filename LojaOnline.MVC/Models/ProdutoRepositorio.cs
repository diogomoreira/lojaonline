using LojaOnline.Comum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LojaOnline.MVC.Models
{
    public class ProdutoRepositorio
    {
        private LojaOnlineEntities _contexto;

        public ProdutoRepositorio(LojaOnlineEntities contexto)
        {
            _contexto = contexto;
        }

        public void AddProduto(Produto produto)
        {
            Categoria cat = _contexto.Categorias.Where(x => x.Codigo == produto.Categoria.Codigo).FirstOrDefault();
            produto.Categoria = cat;
            _contexto.Produtos.Add(produto);
            _contexto.SaveChanges();
        }

        public void RemoveProduto(long Id)
        {
            Produto produto = _contexto.Produtos.Where(x => x.Codigo == Id).FirstOrDefault();
            _contexto.Produtos.Remove(produto);
            _contexto.SaveChanges();
        }

        public List<Produto> Listar()
        {
            return _contexto.Produtos.ToList();
        }

        public List<ProdutoCategoria> ListarProdutos()
        {
            var items = from p in _contexto.Produtos
                        select new ProdutoCategoria()
                        {
                            CodigoProduto = p.Codigo,
                            Nome = p.Nome,
                            Preco = p.Preco,
                            NomeCategoria = p.Categoria.Nome
                        };
            return items.ToList();
        }

        public Produto RecuperarProduto(long Id)
        {
            var items = from p in _contexto.Produtos
                        where p.Codigo == Id
                        select p;
            return items.SingleOrDefault();
        }

        public void Atualizar(Produto produto)
        {
            Produto produtoBanco = _contexto.Produtos.Where(x => x.Codigo == produto.Codigo).FirstOrDefault();
            Categoria categoriaBanco = _contexto.Categorias.Where(x => x.Codigo == produto.Categoria.Codigo).FirstOrDefault();

            produtoBanco.Nome = produto.Nome;
            produtoBanco.Preco = produto.Preco;
            produtoBanco.Categoria = categoriaBanco;
            _contexto.SaveChanges();
        }
    }
}