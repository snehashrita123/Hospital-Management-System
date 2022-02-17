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
        public DbSet<DoctorDetails> DoctorInfo { get; set; }
        public DbSet<Patient_Details> patientrecord { get; set; }
        public DbSet<BloodDonor> bloodDonor { get; set; }
        public DbSet<BloodRequest> bloodRequest { get; set; }
        public DbSet<Ambulance> ambulance { get; set; }
        public DbSet<BloodType> bloodType { get; set; }
        public DbSet<Vacc_reg> vacc_registration { get; set; }
        public DbSet<Bill> bill1 { get; set; }
        public DbSet<AppointmentDetails> AppointmentInfo { get; set; }
        public DbSet<Feedback> feedback { get; set; }
    }
}