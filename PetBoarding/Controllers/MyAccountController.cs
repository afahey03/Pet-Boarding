using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AF.PetBoarding.Models;

namespace AF.PetBoarding.Controllers
{
    public class MyAccountController : Controller
    {
        // GET: MyAccount
        public ActionResult Index()
        {
            return View();
        }

        //MyAccount/Create?FirstName=Aidan&LastName=Fahey&Email=afahey2003@yahoo.com&Phone=5082453155&Address=Rochdale
        public ActionResult Create(string FirstName, string LastName, string Email, string Phone, string Address)
        {
            ApplicationDbContext dbContext = new ApplicationDbContext();

            PetOwnerModel ownerModel = new PetOwnerModel();

            ownerModel.FirstName = FirstName;
            ownerModel.LastName = LastName;
            ownerModel.Email = Email;
            ownerModel.Phone = Phone;
            ownerModel.Address = Address;

            dbContext.PetOwnerModels.Add(ownerModel);

            try
            {
                dbContext.SaveChanges();
                return Content("Created");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }

        //MyAccount/Delete?ID=
        public ActionResult Delete(Guid ID)
        {
            ApplicationDbContext dbContext = new ApplicationDbContext();

            PetOwnerModel ownerModel = dbContext.PetOwnerModels.Include("Pets").FirstOrDefault(x => x.PetOwnerID == ID);

            if (ownerModel != null)
            {
                dbContext.PetOwnerModels.Remove(ownerModel);
                dbContext.PetModels.RemoveRange(ownerModel.Pets);
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
                return Content("OwnerID does not exist");
            }

            return Content("Deleted - " + ID);
        }
    }
}