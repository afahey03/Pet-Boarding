using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AF.PetBoarding.Models
{
    public class EmployeeModel
    {
        [Key]
        public Guid EmployeeID { get; set; } // PK

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Role { get; set; }

        public EmployeeModel()
        {
            EmployeeID = Guid.NewGuid();
        }
    }
}