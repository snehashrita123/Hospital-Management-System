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
    [Table("bloodDonor")]
    public class BloodDonor
    {
        [Key]
        public int DonorID { get; set; }

        [Required, MaxLength(50)]
        public string DonorName { get; set; }

        [Required]
        public int DonorAge { get; set; }

        [Required, MaxLength(50)]
        public string DonorGender{ get; set; }

        [Required]
        public string DonorAddress { get; set; }


        [Required]
        public string DonorBloodtype { get; set; }

        
        [Required, MaxLength(10), RegularExpression(@"^[0-9]{10}$")]
        [Index(IsUnique = true)]
        public string DonorPhoneNumber { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        [Index(IsUnique = true)]
        public string Email { get; set; }


        [Required]
        public float DonorWeight { get; set; }

        [Required]
        public bool Ishealthy { get; set; }

    }
}