namespace NikahMetromoniApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveTabls : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.EducationAndCareers");
            DropTable("dbo.FamilyInformations");
            DropTable("dbo.HobbyAndInterests");
            DropTable("dbo.IntroductionBios");
            DropTable("dbo.MailBoxes");
            DropTable("dbo.OtpStores");
            DropTable("dbo.PersonalDetails");
            DropTable("dbo.PhysicalAttributes");
            DropTable("dbo.PresentAddresses");
            DropTable("dbo.ProfilePictures");
            DropTable("dbo.SpiritualAndSocialBackgrounds");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.SpiritualAndSocialBackgrounds",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PersonalId = c.String(),
                        ReligionVisibility = c.Boolean(nullable: false),
                        Religion = c.String(),
                        CasteVisibility = c.Boolean(nullable: false),
                        Caste = c.String(),
                        SubCasteVisibility = c.Boolean(nullable: false),
                        SubCaste = c.String(),
                        EthnicityVisibility = c.Boolean(nullable: false),
                        Ethnicity = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProfilePictures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PersonalId = c.String(),
                        ImageVisibility = c.Boolean(nullable: false),
                        ImageUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PresentAddresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PersonalId = c.String(),
                        DivisionVisibility = c.Boolean(nullable: false),
                        Division = c.String(),
                        CityVisibility = c.Boolean(nullable: false),
                        City = c.String(),
                        PostalCodeVisibility = c.Boolean(nullable: false),
                        PostalCode = c.String(),
                        CountryVisibility = c.Boolean(nullable: false),
                        Country = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
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
            
            CreateTable(
                "dbo.OtpStores",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        PhoneNo = c.String(),
                        Otp = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MailBoxes",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        FromId = c.String(),
                        ToId = c.String(),
                        Subject = c.String(),
                        MailBody = c.String(),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IntroductionBios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PersonalId = c.String(),
                        Visibility = c.Boolean(nullable: false),
                        Introduction = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
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
                        HobbyOther = c.Boolean(nullable: false),
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
            
            CreateTable(
                "dbo.FamilyInformations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PersonalId = c.String(),
                        FamilyInfoVisibility = c.Boolean(nullable: false),
                        Info = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
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
    }
}
