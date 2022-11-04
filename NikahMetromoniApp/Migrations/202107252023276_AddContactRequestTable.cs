namespace NikahMetromoniApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddContactRequestTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContactRequests",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        PersonalId = c.String(),
                        Name = c.String(),
                        Email = c.String(),
                        Mobile = c.String(),
                        Message = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ContactRequests");
        }
    }
}
