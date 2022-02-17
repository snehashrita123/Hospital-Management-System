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
    [Table("feedback")]
    public class Feedback
    {
        public int FeedbackId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
    }
}