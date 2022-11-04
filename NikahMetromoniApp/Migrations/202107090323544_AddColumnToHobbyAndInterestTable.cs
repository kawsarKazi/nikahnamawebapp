namespace NikahMetromoniApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnToHobbyAndInterestTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HobbyAndInterests", "HobbyOther", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.HobbyAndInterests", "HobbyOther");
        }
    }
}
