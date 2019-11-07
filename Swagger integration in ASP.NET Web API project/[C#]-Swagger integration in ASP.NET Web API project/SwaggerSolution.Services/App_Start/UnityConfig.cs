using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;
using NHibernate;


namespace SwaggerSolution.Services
{
    public static class UnityConfig
    {
        private static IUnityContainer _currentContainer;

        public static IUnityContainer CurrentContainer
        {
            get { return _currentContainer ?? (_currentContainer = new UnityContainer()); }
        }

        public static void RegisterComponents()
        {

            ConfigureContainer();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(CurrentContainer);
        }

        private static void ConfigureContainer()
        {





        }



        #region  Initialization

        private static ISessionFactory SessionFactory { get; set; }

        #endregion
    }
}