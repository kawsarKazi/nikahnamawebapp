namespace NikahMetromoniApp.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddColumnToUsersTable1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Religion", c => c.String());
        }

        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Religion");
        }
    }
}
