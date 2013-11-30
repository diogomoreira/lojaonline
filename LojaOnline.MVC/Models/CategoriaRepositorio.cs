using LojaOnline.Comum;
using LojaOnline.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LojaOnline.MVC.Models
{
    public class CategoriaRepositorio
    {
        private LojaOnlineEntities _contexto;

        public CategoriaRepositorio(LojaOnlineEntities contexto)
        {
            _contexto = contexto;
        }

        public void AddCategoria(Categoria categoria)
        {
            _contexto.Categorias.Add(categoria);
            _contexto.SaveChanges();
        }

        public void RemoveCategoria(long IdCategoria)
        {
            Categoria categoria = _contexto.Categorias.Where(x => x.Codigo == IdCategoria).FirstOrDefault();
            _contexto.Categorias.Remove(categoria);
            _contexto.SaveChanges();
        }

        public List<Categoria> Listar()
        {
            return _contexto.Categorias.ToList();
        }

        public Categoria RecuperarCategoria(long Id)
        {
            var categorias = from c in _contexto.Categorias
                        where c.Codigo == Id
                        select c;
            return categorias.SingleOrDefault();
        }

        public List<ProdutoCategoria> ListarProdutos(long idCategoria)
        {
            var produtos = from p in _contexto.Produtos
                           where p.CodigoCategoria == idCategoria
                           select new ProdutoCategoria()
                           {
                               CodigoProduto = p.Codigo,
                               Nome = p.Nome,
                               Preco = p.Preco,
                               NomeCategoria = p.Categoria.Nome
                           };
            return produtos.ToList();
        }
    }
}