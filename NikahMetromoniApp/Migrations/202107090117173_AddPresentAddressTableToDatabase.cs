namespace NikahMetromoniApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPresentAddressTableToDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PresentAddresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PersonalId = c.String(),
                        DivisionVisibility = c.Boolean(nullable: false),
                        Division = c.String(),
                        CityVisibility = c.Boolean(nullable: false),
                        City = c.String(),
                        PostalCodeVisibility = c.Boolean(nullable: false),
                        PostalCode = c.String(),
                        CountryVisibility = c.Boolean(nullable: false),
                        Country = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PresentAddresses");
        }
    }
}
