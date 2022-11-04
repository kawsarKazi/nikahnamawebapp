namespace NikahMetromoniApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMarriageAndDivorceTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DivorceRegistrations",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        GroomName = c.String(),
                        GroomFatherName = c.String(),
                        GroomIdentity = c.String(),
                        BrideName = c.String(),
                        BrideFatherName = c.String(),
                        BrideIdentity = c.String(),
                        RegisterVolumeNo = c.String(),
                        PageNo = c.String(),
                        FilePath = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MarriageRegistrations",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        GroomName = c.String(),
                        GroomFatherName = c.String(),
                        GroomIdentity = c.String(),
                        BrideName = c.String(),
                        BrideFatherName = c.String(),
                        BrideIdentity = c.String(),
                        RegisterVolumeNo = c.String(),
                        PageNo = c.String(),
                        FilePath = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MarriageRegistrations");
            DropTable("dbo.DivorceRegistrations");
        }
    }
}
