namespace NikahMetromoniApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPhysicalAttributeTableToDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PhysicalAttributes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PersonalId = c.String(),
                        HeightVisibility = c.Boolean(nullable: false),
                        Height = c.String(),
                        WeightVisibility = c.Boolean(nullable: false),
                        Weight = c.String(),
                        EyeColorVisibility = c.Boolean(nullable: false),
                        EyeColor = c.String(),
                        HairColorVisibility = c.Boolean(nullable: false),
                        HairColor = c.String(),
                        BloodGroupVisibility = c.Boolean(nullable: false),
                        BloodGroup = c.String(),
                        ComplexionVisibility = c.Boolean(nullable: false),
                        Complexion = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PhysicalAttributes");
        }
    }
}
