namespace NikahMetromoniApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnToRegistrationTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MarriageRegistrations", "RegistrationDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.MarriageRegistrations", "AmountOfDower", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.MarriageRegistrations", "Address", c => c.String());
            AddColumn("dbo.MarriageRegistrations", "DownloadPermission", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MarriageRegistrations", "DownloadPermission");
            DropColumn("dbo.MarriageRegistrations", "Address");
            DropColumn("dbo.MarriageRegistrations", "AmountOfDower");
            DropColumn("dbo.MarriageRegistrations", "RegistrationDate");
        }
    }
}
