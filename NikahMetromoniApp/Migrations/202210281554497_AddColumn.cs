namespace NikahMetromoniApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DivorceRegistrations", "UserId", c => c.String());
            AddColumn("dbo.MarriageRegistrations", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MarriageRegistrations", "UserId");
            DropColumn("dbo.DivorceRegistrations", "UserId");
        }
    }
}
