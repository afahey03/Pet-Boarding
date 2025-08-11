using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AF.PetBoarding.Models;

namespace AF.PetBoarding.Controllers
{
    public class BookingsController : Controller
    {
        // GET: Bookings
        public ActionResult Index()
        {
            return View();
        }

        //Bookings/Create?Pet=35408555-4E7B-4873-B5C3-A41FCE48FAB7&BookingStartTime=2025-08-08T10:00:00&BookingEndTime=2025-08-10T10:00:00&EmployeeCheckIn=B91BB650-E7A6-4DA8-AC3C-9007BF1C4E68&EmployeeCheckOut=541E36FE-A4AD-41F0-B065-F710717E1E2E
        public ActionResult Create(Guid Pet, DateTime BookingStartTime, DateTime BookingEndTime, BookingStatus Status = BookingStatus.Booked, 
            Guid? EmployeeCheckIn = null, Guid? EmployeeCheckOut = null, DateTime? CanceledTime = null, DateTime? CheckInTime = null, 
            DateTime? CheckOutTime = null)
        {
            ApplicationDbContext dbContext = new ApplicationDbContext();

            if (Pet == null) return Content("Bookings must include a pet");
            if (BookingStartTime == null) return Content("Bookings must include a pet");
            if (BookingEndTime == null) return Content("Bookings must include a pet");

            if (BookingStartTime >= BookingEndTime) return Content("Booking must start before it ends");
            if (CheckInTime >= CheckOutTime) return Content("Check-in must happen before check-out");

            var petModel = dbContext.PetModels.FirstOrDefault(x => x.PetID == Pet);
            if (petModel == null) return Content("No records of this pet");

            var checkInEmployee = dbContext.EmployeeModels.FirstOrDefault(x => x.EmployeeID == EmployeeCheckIn);
            if (checkInEmployee == null) return Content("No such employee");

            var checkOutEmployee = dbContext.EmployeeModels.FirstOrDefault(x => x.EmployeeID == EmployeeCheckOut);
            if (checkOutEmployee == null) return Content("No such employee");

            BookingModel bookingModel = new BookingModel();

            bookingModel.PetID = petModel;
            bookingModel.BookingStartTime = BookingStartTime;
            bookingModel.BookingEndTime = BookingEndTime;
            bookingModel.Status = Status;
            bookingModel.EmployeeCheckIn = checkInEmployee;
            bookingModel.EmployeeCheckOut = checkOutEmployee;
            bookingModel.CanceledTime = CanceledTime;
            bookingModel.CheckInTime = CheckInTime;
            bookingModel.CheckOutTime = CheckOutTime;

            dbContext.BookingModels.Add(bookingModel);

            try
            {
                dbContext.SaveChanges();
                return Content("Created");
            }
            catch (Exception ex)
            {
                return Content("Error - " + ex.Message);
            }
        }

        //Bookings/Delete?&ID=
        public ActionResult Delete(Guid ID)
        {
            ApplicationDbContext dbContext = new ApplicationDbContext();

            BookingModel bookingModel = dbContext.BookingModels.FirstOrDefault(x => x.BookingID == ID);

            if (bookingModel != null)
            {
                dbContext.BookingModels.Remove(bookingModel);
                try
                {
                    dbContext.SaveChanges();
                }
                catch (Exception ex)
                {
                    return Content("Error - " + ex.Message);
                }
            }
            else
            {
                return Content("Booking does not exist");
            }

            return Content("Deleted");
        }
    }
}