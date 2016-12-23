using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using News.Business.IDataProviders;
using News.Business.Components.Managers;
using News.NHibernateDataProvider.DataProviders;

namespace News.App_Start
{
    public class AutofacConfig
    {
        public static void RegisterDependencies()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<UserManager>();

            builder.RegisterType<RoleManager>();

            builder.RegisterType<TidingManager>();

            builder.RegisterType<CommentManager>();

            builder.RegisterType<ContentBlockManager>();

            builder.RegisterType<PageManager>();

            builder.RegisterType<NHibernateRoleDataProvider>()
                .As<IRoleDataProvider>();

            builder.RegisterType<NHibernateUserDataProvider>()
                .As<IUserDataProvider>();

            builder.RegisterType<NHibernateTidingsDataProvider>()
               .As<ITidingsDataProvider>();

            builder.RegisterType<NHibernateCommentDataProvider>()
               .As<ICommentDataProvider>();

            builder.RegisterType<NHibernatePageDataProvider>()
               .As<IPageProvider>();

            builder.RegisterType<NHibernateContentBlockDataProvider>()
                .As<IContentBlockProvider>();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}