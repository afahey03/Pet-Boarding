namespace AF.PetBoarding.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBreedToPet : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PetModels", "Breed", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PetModels", "Breed");
        }
    }
}
