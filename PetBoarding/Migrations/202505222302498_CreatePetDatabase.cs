namespace AF.PetBoarding.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatePetDatabase : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.PetModels", name: "PetOwnerID_PetOwnerID", newName: "PetOwner_PetOwnerID");
            RenameColumn(table: "dbo.BookingModels", name: "EmployeeCheckInID_EmployeeID", newName: "EmployeeCheckIn_EmployeeID");
            RenameColumn(table: "dbo.BookingModels", name: "EmployeeCheckOutID_EmployeeID", newName: "EmployeeCheckOut_EmployeeID");
            RenameIndex(table: "dbo.BookingModels", name: "IX_EmployeeCheckInID_EmployeeID", newName: "IX_EmployeeCheckIn_EmployeeID");
            RenameIndex(table: "dbo.BookingModels", name: "IX_EmployeeCheckOutID_EmployeeID", newName: "IX_EmployeeCheckOut_EmployeeID");
            RenameIndex(table: "dbo.PetModels", name: "IX_PetOwnerID_PetOwnerID", newName: "IX_PetOwner_PetOwnerID");
            DropColumn("dbo.BookingModels", "Status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BookingModels", "Status", c => c.String());
            RenameIndex(table: "dbo.PetModels", name: "IX_PetOwner_PetOwnerID", newName: "IX_PetOwnerID_PetOwnerID");
            RenameIndex(table: "dbo.BookingModels", name: "IX_EmployeeCheckOut_EmployeeID", newName: "IX_EmployeeCheckOutID_EmployeeID");
            RenameIndex(table: "dbo.BookingModels", name: "IX_EmployeeCheckIn_EmployeeID", newName: "IX_EmployeeCheckInID_EmployeeID");
            RenameColumn(table: "dbo.BookingModels", name: "EmployeeCheckOut_EmployeeID", newName: "EmployeeCheckOutID_EmployeeID");
            RenameColumn(table: "dbo.BookingModels", name: "EmployeeCheckIn_EmployeeID", newName: "EmployeeCheckInID_EmployeeID");
            RenameColumn(table: "dbo.PetModels", name: "PetOwner_PetOwnerID", newName: "PetOwnerID_PetOwnerID");
        }
    }
}
