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
        public DbSet<Patient_Details> patientrecord { get; set; }

        public DbSet<BloodDonor> bloodDonor { get; set; }
        public DbSet<BloodRequest> bloodRequest { get; set; }
    }
}