using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;



namespace HOSPITAL_MANAGEMENT_SYSTEM.Models
{



    public class HMSContext : DbContext
    {
        public HMSContext() : base("HMSDbConnection")
        {



        }
        public DbSet<AppUser> UserLogin { get; set; }
        public DbSet<Doctor> doctor { get; set; }

        //public DbSet<Admin_Patient> admin_Patient { get; set; }

        public DbSet<Patient_Details> patientrecord { get; set; }
    }
}