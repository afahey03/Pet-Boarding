using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AF.PetBoarding.Models
{
    public class PetOwnerModel
    {
        [Key]
        public Guid PetOwnerID { get; set; } // PK

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public virtual List<PetModel> Pets { get; set; }

        public PetOwnerModel()
        {
            PetOwnerID = Guid.NewGuid();
            Pets = new List<PetModel>();
        }
    }
}