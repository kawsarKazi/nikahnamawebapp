namespace NikahMetromoniApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProfilePictureTableToDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProfilePictures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PersonalId = c.String(),
                        ImageVisibility = c.Boolean(nullable: false),
                        ImageUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ProfilePictures");
        }
    }
}
