namespace YasService
{
    using System.Data.Entity;
    using System.Reflection;
    using System.Web.Http;
    using Microsoft.Practices.Unity;
    using Unity.WebApi;
    using Models.Context;

    public class UnityConfig
    {
        /// <summary>
        /// Registers Framework assembly with the Unity dependency resolver.
        /// </summary>
        public static void RegisterComponents()
        {
            var container = new UnityContainer();
            container.RegisterTypes(
                AllClasses.FromAssemblies(Assembly.GetExecutingAssembly()),
                WithMappings.FromMatchingInterface,
                WithName.Default,
                WithLifetime.Transient);

            //Framework DataContext
            container.RegisterType<DbContext, YasContext>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container.CreateChildContainer());
        }
    }
}