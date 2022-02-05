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
        public int DoctorID { get; set; }




        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }



        [Required]
        public string Gender { get; set; }



        [Required(ErrorMessage = "Mobile Number is required.")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public string PhoneNumber { get; set; }




        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        [Index(IsUnique = true)]
        public string Email { get; set; }




        [Required(ErrorMessage = "Working Days are required.")]
        [StringLength(100)]
        public string WorkingDays { get; set; }




        [Required(ErrorMessage = "Speciality is required.")]
        public string Speciality { get; set; }




        [Required(ErrorMessage = "Experience is required.")]
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Only Alphabets and Numbers allowed.")]
        public string Experience { get; set; }
    }
}