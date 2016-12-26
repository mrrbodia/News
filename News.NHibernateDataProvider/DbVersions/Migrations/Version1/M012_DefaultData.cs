using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.NHibernateDataProvider.DbVersions.Migrations.Version1
{
    [Migration(201612252226)]
    public class M012_DefaultData : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("DefaultDataUp.sql");
        }

        public override void Down()
        {
            Execute.EmbeddedScript("DefaultDataDown.sql");
        }
    }
}
