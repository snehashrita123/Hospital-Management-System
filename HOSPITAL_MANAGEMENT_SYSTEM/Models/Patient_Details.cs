using System;
using System.Collections.Generic;
using System.Data;
using HOSPITAL_MANAGEMENT_SYSTEM.Models;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;





namespace HOSPITAL_MANAGEMENT_SYSTEM.Models
{
    [Table(" patientrecord")]
    public class Patient_Details
    {
        [Key]
        public int PateintID { get; set; }

        [Required]
        public string FirstName { get; set; }


        [Required]
        public string LastName { get; set; }


        [Required]
        public int Age { get; set; }


        [Required]
        public string gender { get; set; }


        [Required]
        public string ContactNumber { get; set; }


        [Required]
        public string Address { get; set; }


        [Required]
        public string Email { get; set; }

        [Required]
        public string Symptoms { get; set; }

        [Required]
        public string Ward { get; set; }


    }
}