using System.ComponentModel.DataAnnotations.Schema;
using FluentMigrator;
using FluentMigrator.Oracle;

namespace DataAccess.Migrations;

[Migration(0)]
public class M0000_InitialMigration : Migration
{
    public override void Up()
    {
        Create.Table("users")
            .WithColumn("id").AsGuid().Identity().PrimaryKey()
            .WithColumn("username").AsString().Unique().NotNullable()
            .WithColumn("hashed_password").AsString().NotNullable(); 
    }

    public override void Down()
    {
        Delete.Table("users");
    }
}