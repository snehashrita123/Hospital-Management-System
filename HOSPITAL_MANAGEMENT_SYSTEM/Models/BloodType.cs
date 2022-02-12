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
    [Table("bloodType")]
    public class BloodType
    {
        [Key]
        [Required]
        public int BloodId { get; set; }

        [Required]
        public string BloodTypes { get; set; }

        [Required]
        public int BloodUnit { get; set; }
    }
}