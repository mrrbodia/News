using NHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate.Tool.hbm2ddl;

namespace News.NHibernateDataProvider.NHibernateCore
{
    public class Helper
    {
        private static ISessionFactory sessionFactory;

        public static ISession OpenSession()
        {
            if (sessionFactory == null)
            {
                InitializeSessionFactory();
            }
            return sessionFactory.OpenSession();
        }

        private static void InitializeSessionFactory()
        {
            sessionFactory = Fluently.Configure()                
                .Database(MsSqlConfiguration.MsSql2012
                              .ConnectionString(c => c.FromConnectionStringWithKey("DefaultConnection"))
                              .ShowSql()
                )
                .Mappings(m =>
                          m.FluentMappings
                              .AddFromAssemblyOf<Helper>())
                //.ExposeConfiguration(cfg => new SchemaExport(cfg)
                //                                .Create(true, true))
                              .BuildSessionFactory();
        }
    }
}