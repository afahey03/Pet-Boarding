using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AF.PetBoarding.ViewModels
{
    public class ContactUsSubmissionVM
    {
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Message { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}