using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;



namespace HOSPITAL_MANAGEMENT_SYSTEM.Models
{
    [Table("doctor")]
    public class Doctor
    {
        [Key]
        public int DoctorId { get; set; }





        [Required, StringLength(50)]
        public string FirstName { get; set; }





        [Required, StringLength(50)]
        public string LastName { get; set; }





        [Required]
        public DateTime AvailabilityTime { get; set; }





        [Required, StringLength(50)]
        public string Specialty { get; set; }





        public int Experience { get; set; }
    }
}