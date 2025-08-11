using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AF.PetBoarding.ViewModels;
using AF.PetBoarding.Models;
using System.Security.Cryptography.X509Certificates;

namespace AF.PetBoarding.Controllers
{
    public class ContactUsController : Controller
    {
        // GET: ContactUs
        [HttpGet]
        public ActionResult Index()
        {
            return View(new ContactUsSubmissionVM());
        }

        [HttpPost]
        public ActionResult Index(ContactUsSubmissionVM contactUsVM)
        {
            ApplicationDbContext dbContext = new ApplicationDbContext();
            ContactUsModel contactUsModel = new ContactUsModel();

            if (string.IsNullOrEmpty(contactUsVM.FirstName)) return Content("First name is required");
            if (string.IsNullOrEmpty(contactUsVM.LastName)) return Content("Last name is required");
            if (string.IsNullOrEmpty(contactUsVM.Message)) return Content("Message is required");
            if (string.IsNullOrEmpty(contactUsVM.Email)) return Content("Email address is required");

            contactUsModel.FirstName = contactUsVM.FirstName;
            contactUsModel.LastName = contactUsVM.LastName;
            contactUsModel.Message = contactUsVM.Message;
            contactUsModel.Email = contactUsVM.Email;

            dbContext.ContactUsModels.Add(contactUsModel);

            try
            {
                dbContext.SaveChanges();
                return View("ContactUsSuccess");
            }
            catch (Exception ex)
            {
                return Content("Error - " + ex.Message);
            }
        }

        public ActionResult ContactUsSuccess()
        {
            return View("~/Views/ContactUs/ContactUsSuccess.cshtml");
        }
    }
}