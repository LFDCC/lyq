using AutoMapper;
using lyq.Infrastructure.Extension;
using System;
using System.Linq;
using System.Reflection;
using System.Web.Compilation;

namespace lyq.Infrastructure.Mapping
{
    public class AutoMapConfig
    {
        /// <summary>
        /// 注册映射
        /// </summary>
        public static void RegisterMapper()
        {
            Mapper.Initialize(ctx =>
            {
                var baseType = typeof(IMapper);

                var assemblys = BuildManager.GetReferencedAssemblies().Cast<Assembly>();//获取所有程序集
               
                foreach (var assembly in assemblys)
                {
                    var types = assembly.GetTypes().Where(t =>baseType.IsAssignableFrom(t));//获取所有实现IMapper接口的类
                    foreach (Type type in types)
                    {
                        AutoMapAttribute autoMapAttribute = type.GetCustomAttribute(typeof(AutoMapAttribute), false).As<AutoMapAttribute>();
                        if (autoMapAttribute != null)
                        {
                            ctx.CreateMap(autoMapAttribute.type, type);
                        }
                    }
                }
            });
        }
    }
}
