namespace AF.PetBoarding.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeTimesNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BookingModels", "CanceledTime", c => c.DateTime());
            AlterColumn("dbo.BookingModels", "CheckInTime", c => c.DateTime());
            AlterColumn("dbo.BookingModels", "CheckOutTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.BookingModels", "CheckOutTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.BookingModels", "CheckInTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.BookingModels", "CanceledTime", c => c.DateTime(nullable: false));
        }
    }
}
