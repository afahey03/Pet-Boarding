using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AF.PetBoarding.Models;

namespace AF.PetBoarding.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }

        //Employee/Create?FirstName=Robert&LastName=Plant&Email=rplant@gmail.com&Role=Groomer
        //Employee/Create?FirstName=George&LastName=Michael&Email=gmichael@yahoo.com&Role=Sitter
        public ActionResult Create(string FirstName, string LastName, string Email, string Role)
        {
            ApplicationDbContext dbContext = new ApplicationDbContext();

            EmployeeModel employeeModel = new EmployeeModel();

            employeeModel.FirstName = FirstName;
            employeeModel.LastName = LastName;
            employeeModel.Email = Email;
            employeeModel.Role = Role;

            dbContext.EmployeeModels.Add(employeeModel);

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
    }
}