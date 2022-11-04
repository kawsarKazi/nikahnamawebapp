namespace NikahMetromoniApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnInDivorceTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DivorceRegistrations", "DivorceType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DivorceRegistrations", "DivorceType");
        }
    }
}
