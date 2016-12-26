using FluentMigrator;

namespace News.NHibernateDataProvider.DbVersions.Migrations.Version1
{
    [Migration(201612261956)]
    public class M003_BackUpLiveDb  : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("BackUpData.sql");
        }

        public override void Down()
        {
            Execute.EmbeddedScript("BackUpDataDown.sql");
        }
    }
}
