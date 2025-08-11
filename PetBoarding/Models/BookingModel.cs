using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AF.PetBoarding.Models
{

    public enum BookingStatus
    {
        Booked,
        InProgress,
        Concluded,
        Canceled

    }

    public class BookingModel
    {
        [Key]
        public Guid BookingID { get; set; }

        [Required]
        public PetModel PetID { get; set; } // FK

        public DateTime BookingStartTime { get; set; }

        public DateTime BookingEndTime { get; set; }

        public BookingStatus Status { set; get; }

        public EmployeeModel EmployeeCheckIn { get; set; } // FK

        public EmployeeModel EmployeeCheckOut { get; set; } // FK

        public DateTime? CanceledTime { get; set; }

        public DateTime? CheckInTime { get; set; }

        public DateTime? CheckOutTime { get; set; }

        public BookingModel()
        {
            BookingID = Guid.NewGuid();
            Status = BookingStatus.Booked;
        }

    }
}