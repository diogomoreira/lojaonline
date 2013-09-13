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
        public void AddCategoria(Categoria categoria)
        {
            using (LojaOnlineEntities context = new LojaOnlineEntities())
            {
                context.Categorias.Add(categoria);
                context.SaveChanges();
            }
        }

        public void RemoveCategoria(Categoria categoria)
        {
            using (LojaOnlineEntities context = new LojaOnlineEntities())
            {
                context.Categorias.Remove(categoria);
                context.SaveChanges();
            }
        }

        public List<Categoria> Listar()
        {
            using (LojaOnlineEntities context = new LojaOnlineEntities())
            {
                return context.Categorias.ToList();
            }
        }
    }
}