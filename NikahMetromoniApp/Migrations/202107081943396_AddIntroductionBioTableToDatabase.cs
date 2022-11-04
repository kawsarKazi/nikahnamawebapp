namespace NikahMetromoniApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIntroductionBioTableToDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.IntroductionBios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Visibility = c.Boolean(nullable: false),
                        Introduction = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.IntroductionBios");
        }
    }
}
