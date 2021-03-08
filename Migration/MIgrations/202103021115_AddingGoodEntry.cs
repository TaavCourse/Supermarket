using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace Migration.MIgrations
{
    [Migration(202103021115)]
    public class _202103021115_AddingGoodEntry : FluentMigrator.Migration

    {
        public override void Up()
        {
            Create.Table("GoodEntries")
                .WithColumn("Id").AsInt32().Identity().PrimaryKey()
                .WithColumn("GoodCode").AsString(50).NotNullable()
                .WithColumn("EntryDate").AsDateTime()
                .WithColumn("GoodCount").AsInt32().NotNullable();

            Alter.Table("Goods")
                .AddColumn("Count").AsInt32().NotNullable().WithDefaultValue(0);
        }

        public override void Down()
        {
            Delete.Table("GoodEntries");
        }
    }
}
