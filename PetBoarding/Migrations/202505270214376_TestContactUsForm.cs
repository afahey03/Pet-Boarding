namespace AF.PetBoarding.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestContactUsForm : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ContactUsModels", "SubmittedAtUTC", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ContactUsModels", "SubmittedAtUTC");
        }
    }
}
