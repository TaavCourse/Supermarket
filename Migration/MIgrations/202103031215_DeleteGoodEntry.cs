using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace Migration.MIgrations
{
    [Migration(202103031215)]
    public class _202103031215_DeleteGoodEntry : FluentMigrator.Migration
    {
        
        public override void Up()
        {
            Delete.Column("EntryDate").FromTable("GoodEntries");
        }

        public override void Down()
        {
            Alter.Table("GoodEntries")
                .AddColumn("EntryDate").AsDateTime().NotNullable().WithDefaultValue(DateTime.Now);
        }
    }
}
