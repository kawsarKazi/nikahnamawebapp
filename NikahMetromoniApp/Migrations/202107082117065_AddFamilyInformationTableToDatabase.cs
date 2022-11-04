namespace NikahMetromoniApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFamilyInformationTableToDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FamilyInformations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PersonalId = c.String(),
                        FamilyInfoVisibility = c.Boolean(nullable: false),
                        Info = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.FamilyInformations");
        }
    }
}
