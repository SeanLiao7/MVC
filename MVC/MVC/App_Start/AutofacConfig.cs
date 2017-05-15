using System.Reflection;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using MVC.Service;

namespace MVC
{
    public class AutofacConfig
    {
        public static void Register( )
        {
            // 容器建立者
            var builder = new ContainerBuilder( );

            // 註冊Controllers
            builder.RegisterControllers( Assembly.GetExecutingAssembly( ) );

            // 註冊DbContextFactory
            // var connectionString = ConfigurationManager.ConnectionStrings[ "ConnectionString" ].ConnectionString;

            //builder.RegisterType<NORTHWNDEntities>( )
            //    .WithParameter( "connectionString", connectionString )
            //    .As<IDbContextFactory>( )
            //    .InstancePerHttpRequest( );

            builder.Register( c => new NORTHWNDEntities( ) ).
                InstancePerRequest( );

            // 註冊 Repository UnitOfWork
            //builder.RegisterGeneric( typeof( GenericRepository<> ) ).As( typeof( IRepository<> ) );

            // 註冊Services
            builder.Register( c => new CustomerService(
                c.Resolve<NORTHWNDEntities>( ) ) ).
                AsImplementedInterfaces( );

            //builder.RegisterAssemblyTypes( Assembly.GetExecutingAssembly( ) )
            //       .Where( t => t.Name.EndsWith( "Service" ) )
            //       .AsImplementedInterfaces( );

            // 建立容器
            var container = builder.Build( );

            // 解析容器內的型別
            //AutofacWebApiDependencyResolver resolverApi = new AutofacWebApiDependencyResolver( container );
            var resolver = new AutofacDependencyResolver( container );

            // 建立相依解析器
            //GlobalConfiguration.Configuration.DependencyResolver = resolverApi;
            DependencyResolver.SetResolver( resolver );
        }
    }
}