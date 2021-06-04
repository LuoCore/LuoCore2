using Common;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Utility.Factory;

namespace CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {


        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<ISqlSugarFactory, SqlSugarFactory>();

            var DataBasePath = FilePathHelper.GetCurrentProjectRootPath;

            AddSqlSugarClient<ISqlSugarFactory>(services, (sp, cc) =>
            {
                //var ConnectStr = sp.GetService<IConfiguration>().GetConnectionString("SqlserverConnection");
                var ConnectStr = sp.GetService<IConfiguration>().GetConnectionString("SqlLiteConnection");
                ConnectStr = string.Format(ConnectStr, DataBasePath);
                var ConnectStr2 = ConnectStr;
                cc.ConnectionString = ConnectStr;//主库
                cc.DbType = DbType.Sqlite;
                cc.InitKeyType = InitKeyType.Attribute;//从特性读取主键和自增列信息
                cc.IsAutoCloseConnection = true;//开启自动释放模式和EF原理一样我就不多解释了
                //从库
                cc.SlaveConnectionConfigs = new List<SlaveConnectionConfig>()
                {
                     new SlaveConnectionConfig()
                     {
                         HitRate=10,//HitRate 越大走这个从库的概率越大
                          ConnectionString=ConnectStr2
                     }
                };
            });



            // 领域层 - Memory
            services.AddSingleton<IMemoryCache>(factory =>
            {
                var cache = new MemoryCache(new MemoryCacheOptions());
                return cache;
            });



            BatchRegisterService(services, "Services");

            // 注入 服务层
            BatchRegisterService(services, "Repository");

        }
        // <summary>
        /// SqlSugar上下文注入
        /// </summary>
        /// <typeparam name="TSugarContext">要注册的上下文的类型</typeparam>
        /// <param name="serviceCollection"></param>
        /// <param name="configAction"></param>
        /// <param name="lifetime">用于在容器中注册TSugarClient服务的生命周期</param>
        /// <returns></returns>
        internal static IServiceCollection AddSqlSugarClient<TSugarContext>(IServiceCollection serviceCollection, Action<IServiceProvider, ConnectionConfig> configAction, ServiceLifetime lifetime = ServiceLifetime.Scoped)
             where TSugarContext : ISqlSugarFactory
        {
            serviceCollection.TryAdd(new ServiceDescriptor(typeof(ConnectionConfig), sp => ConnectionConfigFactory(sp, configAction), lifetime));
            serviceCollection.Add(new ServiceDescriptor(typeof(ConnectionConfig), p => ConnectionConfigFactory(p, configAction), lifetime));
            serviceCollection.TryAdd(new ServiceDescriptor(typeof(TSugarContext), typeof(TSugarContext), lifetime));
            return serviceCollection;
        }
        private static ConnectionConfig ConnectionConfigFactory(IServiceProvider applicationServiceProvider, Action<IServiceProvider, ConnectionConfig> configAction)
        {
            var config = new ConnectionConfig();

            configAction.Invoke(applicationServiceProvider, config);
            return config;
        }

        /// <summary>
        /// 批量注册
        /// </summary>
        /// <param name="services"></param>
        /// <param name="assemblyName">程序集名</param>
        /// <param name="lifetime">服务生命周期</param>
        public static void BatchRegisterService(IServiceCollection services, string assemblyName, ServiceLifetime lifetime = ServiceLifetime.Scoped)
        {
            foreach (var item in GetClassName(assemblyName))
            {
                //根据生命周期注册
                switch (lifetime)
                {
                    case ServiceLifetime.Scoped:
                        services.AddScoped(item.Value, item.Key);
                        break;
                    case ServiceLifetime.Singleton:
                        services.AddSingleton(item.Value, item.Key);
                        break;
                    case ServiceLifetime.Transient:
                        services.AddTransient(item.Value, item.Key);
                        break;
                }
            }
        }


        /// <summary>
        /// 获取程序集中的类
        /// </summary>
        /// <param name="assemblyName">程序集名</param>
        /// <returns></returns>
        private static Dictionary<Type, Type> GetClassName(string assemblyName)
        {
            var result = new Dictionary<Type, Type>();
            if (!string.IsNullOrWhiteSpace(assemblyName))
            {
                //排除程序程序集中的接口、私有类、抽象类
                Assembly assembly = Assembly.Load(assemblyName);
                var typeList = assembly.GetTypes().Where(t => !t.IsInterface && !t.IsSealed && !t.IsAbstract).ToList();
                //历遍程序集中的类
                foreach (var item in typeList)
                {
                    //查找当前类继承且包含当前类名的接口
                    var interfaceType = item.GetInterfaces().Where(o => o.Name.Contains(item.Name)).FirstOrDefault();
                    if (interfaceType != null)
                    {
                        //把当前类和继承接口加入Dictionary
                        result.Add(item, interfaceType);
                    }
                }
            }
            return result;
        }
    }
}
