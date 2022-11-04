namespace NikahMetromoniApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnToDivorceTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DivorceRegistrations", "DivorceDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.DivorceRegistrations", "Address", c => c.String());
            AddColumn("dbo.DivorceRegistrations", "DownloadPermission", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DivorceRegistrations", "DownloadPermission");
            DropColumn("dbo.DivorceRegistrations", "Address");
            DropColumn("dbo.DivorceRegistrations", "DivorceDate");
        }
    }
}
