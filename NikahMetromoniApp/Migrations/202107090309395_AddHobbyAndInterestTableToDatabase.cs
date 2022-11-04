namespace NikahMetromoniApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddHobbyAndInterestTableToDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HobbyAndInterests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PersonalId = c.String(),
                        HobbyVisibility = c.Boolean(nullable: false),
                        HobbyPhotography = c.Boolean(nullable: false),
                        HobbyGardening = c.Boolean(nullable: false),
                        HobbyFishing = c.Boolean(nullable: false),
                        HobbyDrawing = c.Boolean(nullable: false),
                        HobbyBanknoteCollecting = c.Boolean(nullable: false),
                        InterestVisible = c.Boolean(nullable: false),
                        InterestAstronomy = c.Boolean(nullable: false),
                        InterestShopping = c.Boolean(nullable: false),
                        InterestTheater = c.Boolean(nullable: false),
                        InterestTraveling = c.Boolean(nullable: false),
                        InterestOther = c.Boolean(nullable: false),
                        MovieVisibility = c.Boolean(nullable: false),
                        MovieAction = c.Boolean(nullable: false),
                        MovieAdventure = c.Boolean(nullable: false),
                        MovieDocumentary = c.Boolean(nullable: false),
                        MovieRomantic = c.Boolean(nullable: false),
                        MovieOther = c.Boolean(nullable: false),
                        MusicVisibility = c.Boolean(nullable: false),
                        MusicBand = c.Boolean(nullable: false),
                        MusicClassic = c.Boolean(nullable: false),
                        MusicCountry = c.Boolean(nullable: false),
                        MusicRock = c.Boolean(nullable: false),
                        MusicOther = c.Boolean(nullable: false),
                        SportsVisibility = c.Boolean(nullable: false),
                        SportsFootball = c.Boolean(nullable: false),
                        SportsCricket = c.Boolean(nullable: false),
                        SportsHockey = c.Boolean(nullable: false),
                        SportsAthletics = c.Boolean(nullable: false),
                        SportsWrestling = c.Boolean(nullable: false),
                        SportsOther = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.HobbyAndInterests");
        }
    }
}
