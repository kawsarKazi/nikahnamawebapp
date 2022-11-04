namespace NikahMetromoniApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnsInUsersTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "DivisionName", c => c.String());
            AddColumn("dbo.AspNetUsers", "CityName", c => c.String());
            AddColumn("dbo.AspNetUsers", "AreaName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "AreaName");
            DropColumn("dbo.AspNetUsers", "CityName");
            DropColumn("dbo.AspNetUsers", "DivisionName");
        }
    }
}
