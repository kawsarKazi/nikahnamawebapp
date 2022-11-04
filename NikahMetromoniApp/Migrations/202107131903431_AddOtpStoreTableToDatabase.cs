namespace NikahMetromoniApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOtpStoreTableToDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OtpStores",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        PhoneNo = c.String(),
                        Otp = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.OtpStores");
        }
    }
}
