using DI.Interface;
using DI.Modules;
using System.Security.Permissions;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace DevicesAPI
{
    //[FileIOPermissionAttribute(SecurityAction.PermitOnly,
    // PathDiscovery = "C:\\Documents and Settings\\All Users")]
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            Register<DomainModule>(container);
            Register<InterfaceModule>(container);
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }

        public static void Register<T>(IUnityContainer container) where T : IModule, new()
        {
            new T().Register(container);
        }
    }
}