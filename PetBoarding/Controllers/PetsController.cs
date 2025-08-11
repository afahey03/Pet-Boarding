using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AF.PetBoarding.Models;

namespace AF.PetBoarding.Controllers
{
    public class PetsController : Controller
    {
        // GET: Pets
        public ActionResult Index()
        {
            return View();
        }

        //Pets/Create?Name=Mabel&Age=1&Breed=ChowChow&&FeedingAmount=5&FeedingFrequency=3&Medications=HeartDeworm&SpecialInstructions=None&EmergencyContactNum=1112223345&OwnerID=EDFAAA72-B6D7-483C-8113-F077155E6C30
        public ActionResult Create(string Name, Guid OwnerID, int Age = 0, string Breed = null, int FeedingAmount = 0, int FeedingFrequency = 0,
            string Medications = null, string SpecialInstrtuctions = null, int EmergencyContactNum = 0)
        {
            ApplicationDbContext dbContext = new ApplicationDbContext();

            if (string.IsNullOrEmpty(Name)) return Content("Pet must have a name");

            if (OwnerID == null) return Content("Pet must have an owner");

            var ownerModel = dbContext.PetOwnerModels.FirstOrDefault(o => o.PetOwnerID == OwnerID);

            if (ownerModel == null) return Content("OwnerID not found in the database");

            PetModel petModel = new PetModel();

            petModel.Name = Name;
            petModel.Age = Age;
            petModel.Breed = Breed;
            petModel.FeedingAmount = FeedingAmount;
            petModel.FeedingFrequency = FeedingFrequency;
            petModel.Medications = Medications;
            petModel.SpecialInstructions = SpecialInstrtuctions;
            petModel.EmergencyContactNum = EmergencyContactNum;
            petModel.PetOwner = ownerModel;

            dbContext.PetModels.Add(petModel);

            try
            {
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                return Content("Error - " + ex.Message);
            }

            return Content("Created");
        }

        //Pets/Delete?ID=
        public ActionResult Delete(Guid ID)
        {
            ApplicationDbContext dbContext = new ApplicationDbContext();

            PetModel petModel = dbContext.PetModels.FirstOrDefault(x => x.PetID == ID);

            if (petModel != null)
            {
                dbContext.PetModels.Remove(petModel);
                dbContext.BookingModels.RemoveRange(petModel.Bookings);
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
                return Content("PetID does not exist");
            }

            return Content("Deleted - " + ID);
        }
    }
}