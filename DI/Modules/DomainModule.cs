using DI.Interface;
using Domain.Interface;
using Domain.Service.Services;
using Unity;
using Unity.Lifetime;

namespace DI.Modules
{
    public class DomainModule : IModule
    {
        public void Register(IUnityContainer container)
        {
            container.RegisterType<IUserInterface, UserService>(new HierarchicalLifetimeManager());
        }
    }
}
