using DI.Interface;
using Infrastructure.Interface.Interface;
using Infrastructure.Service.Contexts;
using Infrastructure.Service.Services;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using Unity;
using Unity.Injection;
using Unity.Lifetime;

namespace DI.Modules
{
    public class InterfaceModule : IModule
    {
        public void Register(IUnityContainer container)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MyContext>();
            optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["MyContext"].ConnectionString);

            //using (var context = new MyContext(optionsBuilder.Options)) context.Database.EnsureCreated();

            container.RegisterType<MyContext>(new HierarchicalLifetimeManager(), new InjectionConstructor(optionsBuilder.Options));
            container.RegisterType<IUserRepository, UserServiceRepository>(new ContainerControlledLifetimeManager());
        }
    }
}
