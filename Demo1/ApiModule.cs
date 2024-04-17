using Autofac;
using Demo.Application.IService;
using Demo.Application.Service;
using System.Reflection;
using Module = Autofac.Module;

namespace Demo1
{
    public class ApiModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            // 注册仓储接口和实现  
            //builder.RegisterType<UserRepository>()
            //.As<IUserRepository>()
            //.InstancePerLifetimeScope();

            // 注册服务接口和实现  
            builder.RegisterType<UserService>()
                   .As<IUserService>()
                   .InstancePerMatchingLifetimeScope();

            var files = Directory.GetFiles(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Modules"), "*.dll");
            foreach (var file in files)
            {
                Assembly assembly = Assembly.LoadFile(file);
                foreach (var type in assembly.GetTypes())
                {
                    Console.WriteLine(type);
                }
                builder.RegisterTypes(assembly.GetTypes()).AsImplementedInterfaces();
            }
        }
    }
}
