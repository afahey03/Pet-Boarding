using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AF.PetBoarding.Models
{
    public class ContactUsModel
    {
        [Key]
        public Guid ContactUsID { get; set; } // PK

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Message { get; set; }

        public string Email { get; set; }

        public DateTime SubmittedAtUTC { get; set; }

        public ContactUsModel()
        {
            ContactUsID = Guid.NewGuid();
            SubmittedAtUTC = DateTime.UtcNow;
        }
    }
}