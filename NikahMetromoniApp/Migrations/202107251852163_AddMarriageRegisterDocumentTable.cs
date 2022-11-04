namespace NikahMetromoniApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMarriageRegisterDocumentTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MarriageRegisterDocuments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PersonalId = c.String(),
                        ImageUrl = c.String(),
                        CertificateUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MarriageRegisterDocuments");
        }
    }
}
