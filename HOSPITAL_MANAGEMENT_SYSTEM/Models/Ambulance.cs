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
    [Table("ambulance")]
    public class Ambulance
    {
        [Key]
        public int AmbulanceNo { get; set; }



        [Required(ErrorMessage = "Name is required.")]
        public string OwnerName { get; set; }



        [Required, MaxLength(10), RegularExpression(@"^[0-9]{10}$")]
        [Index(IsUnique = true)]
        public string CallForDetails { get; set; }
    }
}