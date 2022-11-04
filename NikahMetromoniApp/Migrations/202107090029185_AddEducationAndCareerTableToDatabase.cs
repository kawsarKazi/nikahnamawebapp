namespace NikahMetromoniApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEducationAndCareerTableToDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EducationAndCareers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PersonalId = c.String(),
                        EducationVisibility = c.Boolean(nullable: false),
                        HighestEducation = c.String(),
                        OccupationVisibility = c.Boolean(nullable: false),
                        Occupation = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.EducationAndCareers");
        }
    }
}
