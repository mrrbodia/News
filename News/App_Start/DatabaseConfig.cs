using News.NHibernateDataProvider.DbVersions;

namespace News.App_Start
{
    public class DatabaseConfig
    {
        public static void MigrateDatabase(string connectionString)
        {
            var migrator = new Migrator(connectionString);
            //migrator.MigrateDown(201612252226);
            migrator.MigrateToLatest();
        }
    }
}