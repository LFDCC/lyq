using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Linq;
using System.Reflection;
using System.Web.Compilation;
using System.Web.Mvc;

namespace lyq.Infrastructure.Ioc
{
    public class AutoFacConfig
    {
        /// <summary>
        /// IOC 容器
        /// </summary>
        public static IContainer container = null;

        /// <summary>
        /// 获取实例化对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Resolve<T>()
        {
            try
            {
                if (container == null)
                {
                    RegisterContainer();
                }
                return container.Resolve<T>();
            }
            catch (Exception ex)
            {
                throw new Exception($"IOC实例化类型{typeof(T).GetType().FullName}出错!" + ex.Message);
            }
        }

        /// <summary>
        /// 注册到容器中
        /// </summary>
        public static void RegisterContainer()
        {
            var builder = new ContainerBuilder();
             
            var assemblys = BuildManager.GetReferencedAssemblies().Cast<Assembly>();//获取所有的程序集
            
            builder.RegisterAssemblyTypes(assemblys.ToArray())
            .Where(t => t.Name.EndsWith("Service"))//注册所有的应用Service类
            .AsImplementedInterfaces().InstancePerLifetimeScope();
            
            builder.RegisterControllers(Assembly.GetCallingAssembly());//注册mvc容器的实现
            builder.RegisterFilterProvider();//注册到筛选器            

            container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}