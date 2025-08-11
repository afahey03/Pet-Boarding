using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AF.PetBoarding.Models
{
    public class PetModel
    {
        [Key]
        public Guid PetID { get; set; } // PK

        [Required]
        public string Name { get; set; }

        public int Age { get; set; }

        public string Breed { get; set; }

        [Required]
        public PetOwnerModel PetOwner { get; set; } // FK

        public int FeedingAmount { get; set; }

        public int FeedingFrequency { get; set; }

        public string Medications { get; set; }

        public string SpecialInstructions { get; set; }

        public int EmergencyContactNum { get; set; }

        public virtual List<BookingModel> Bookings { get; set; }

        public PetModel()
        {
            PetID = Guid.NewGuid();
            Bookings = new List<BookingModel>();
        }
    }
}