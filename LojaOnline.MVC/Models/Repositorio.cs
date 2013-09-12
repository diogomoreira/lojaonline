using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LojaOnline.Comum;

namespace LojaOnline.MVC.Models
{
    public class Repositorio
    {
        private static readonly Dictionary<long, Categoria> _categorias = new Dictionary<long, Categoria>();
        private static readonly Dictionary<long, Produto> _produtos = new Dictionary<long, Produto>();

        public Repositorio()
        {
        }

        public void AddCategoria(Categoria cat)
        {
            cat.Codigo = _categorias.Values.Count+1;
            _categorias.Add(cat.Codigo, cat);
        }

        public List<Categoria> ObterCategorias()
        {
            return _categorias.Values.ToList();
        }

        public void AddProduto(Produto prod)
        {
            prod.Codigo = _produtos.Values.Count + 1;
            _produtos.Add(prod.Codigo, prod);
        }

        public List<Produto> ObterProdutos()
        {
            return _produtos.Values.ToList();
        }
    }
}