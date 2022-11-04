namespace NikahMetromoniApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSpiritualAndSocialBackgroundTableToDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SpiritualAndSocialBackgrounds",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PersonalId = c.String(),
                        ReligionVisibility = c.Boolean(nullable: false),
                        Religion = c.String(),
                        CasteVisibility = c.Boolean(nullable: false),
                        Caste = c.String(),
                        SubCasteVisibility = c.Boolean(nullable: false),
                        SubCaste = c.String(),
                        EthnicityVisibility = c.Boolean(nullable: false),
                        Ethnicity = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SpiritualAndSocialBackgrounds");
        }
    }
}
