namespace NikahMetromoniApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPersonalDetailTableToDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PersonalDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PersonalId = c.String(),
                        FirstNameVisibility = c.Boolean(nullable: false),
                        FirstName = c.String(),
                        LastNameVisibility = c.Boolean(nullable: false),
                        LastName = c.String(),
                        GenderVisibility = c.Boolean(nullable: false),
                        Gender = c.String(),
                        BirthdateVisibility = c.Boolean(nullable: false),
                        Birthdate = c.String(),
                        AgeVisibility = c.Boolean(nullable: false),
                        Age = c.String(),
                        MaritalStatusVisibility = c.Boolean(nullable: false),
                        MaritalStatus = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PersonalDetails");
        }
    }
}
