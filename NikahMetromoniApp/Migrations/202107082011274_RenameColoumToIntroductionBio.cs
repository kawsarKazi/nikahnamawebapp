namespace NikahMetromoniApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameColoumToIntroductionBio : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.IntroductionBios", "PersonalId", c => c.String());
            DropColumn("dbo.IntroductionBios", "Username");
        }
        
        public override void Down()
        {
            AddColumn("dbo.IntroductionBios", "Username", c => c.String());
            DropColumn("dbo.IntroductionBios", "PersonalId");
        }
    }
}
