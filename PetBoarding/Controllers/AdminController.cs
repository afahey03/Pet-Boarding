using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AF.PetBoarding.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Pets()
        {
            return View("~/Views/Admin/Pets.cshtml");
        }

        public ActionResult Bookings()
        {
            return View("~/Views/Admin/Bookings.cshtml");
        }
    }
}