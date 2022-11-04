namespace NikahMetromoniApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMailBoxTableToDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MailBoxes",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        FromId = c.String(),
                        ToId = c.String(),
                        Subject = c.String(),
                        MailBody = c.String(),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MailBoxes");
        }
    }
}
