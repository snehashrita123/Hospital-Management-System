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
    [Table("vacc_registration")]
    public class Vacc_reg
    {
        [Key]
        public int vacc_id {get;set;}

        [Required]
        [Index(IsUnique = true)]
        [StringLength(12)]
        public string AadharCard_Number { get; set; }


        [Required]
        public string Name { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required, MaxLength(10), RegularExpression(@"^[0-9]{10}$")]
        [Index(IsUnique = true)]
        public string PhoneNumber { get; set; }

        [Required]
        public int YOB { get; set; } 
    }
}