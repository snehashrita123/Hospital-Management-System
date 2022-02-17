using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HOSPITAL_MANAGEMENT_SYSTEM.Models
{
    [Table("bill1")]
    public class Bill
    {
        [Key]
        public int PaymentID { get; set; }


        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Mobile Number is required.")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public string PhoneNumber { get; set; }


        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        [Index(IsUnique = true)]
        public string Email { get; set; }


        [Required]
        public int DocCharge { get; set; }


        [Required]
        public int WardCharge { get; set; }


        [Required(ErrorMessage = "Admitted Days are required.")]
        [StringLength(100)]
        public string Days { get; set; }


        [Required]
        public int BillAmount { get; set; }

    }
}