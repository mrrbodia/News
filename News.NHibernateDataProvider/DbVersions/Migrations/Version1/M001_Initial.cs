using FluentMigrator;

namespace News.NHibernateDataProvider.DbVersions.Migrations.Version1
{
    [Migration(201611251955)]
    public class M001_Initial : Migration
    {
        public override void Up()
        {
            //Execute.EmbeddedScript("CreateTablesUp.sql");
        }

        public override void Down()
        {
            //Execute.EmbeddedScript("CreateTablesDown.sql");
        }
    }
}
