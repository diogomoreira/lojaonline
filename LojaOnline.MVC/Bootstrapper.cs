using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc4;
using LojaOnline.MVC.Models;

namespace LojaOnline.MVC
{
  public static class Bootstrapper
  {
    public static IUnityContainer Initialise()
    {
      var container = BuildUnityContainer();

      DependencyResolver.SetResolver(new UnityDependencyResolver(container));

      return container;
    }

    private static IUnityContainer BuildUnityContainer()
    {
      var container = new UnityContainer();

      // register all your components with the container here
      // it is NOT necessary to register your controllers

      // e.g. container.RegisterType<ITestService, TestService>();    
      RegisterTypes(container);

      return container;
    }

    public static void RegisterTypes(IUnityContainer container)
    {
        container.RegisterType<LojaOnlineEntities>();
        container.RegisterType<ProdutoRepositorio>();
        container.RegisterType<CategoriaRepositorio>();
    }
  }
}