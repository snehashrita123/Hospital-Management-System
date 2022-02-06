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
    [Table("bloodRequest")]
    public class BloodRequest
    {
        [Key]
        public int RequestID { get; set; }


        [Required, MaxLength(50)]
        public string RequestorName { get; set; }


        [Required]
        public int RequestorAge { get; set; }

        [Required]
        public int RequestorGender { get; set; }


        [Required, MaxLength(10), RegularExpression(@"^[0-9]{10}$")]
        [Index(IsUnique = true)]
        public string RequestorPhoneNumber{ get; set; }


        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        [Index(IsUnique = true)]
        public string Email { get; set; }

        [Required, MaxLength(100)]
        public string RequestorAddress { get; set; }


        [Required]
        public string RequestedBloodtype { get; set; }


        [Required]
        public bool IsActive { get; set; }

        public DateTime RequestedOn { get; set; } = DateTime.Now.Date;
    }
}