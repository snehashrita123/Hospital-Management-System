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
    public class Login
    {
        [Required, StringLength(50)]
        public string Email { get; set; }


        [Required]
        public string Password { get; set; }
    }
}