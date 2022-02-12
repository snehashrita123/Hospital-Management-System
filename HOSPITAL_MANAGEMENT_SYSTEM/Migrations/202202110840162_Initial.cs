namespace HOSPITAL_MANAGEMENT_SYSTEM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ambulance",
                c => new
                    {
                        AmbulanceNo = c.Int(nullable: false, identity: true),
                        OwnerName = c.String(nullable: false),
                        CallForDetails = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.AmbulanceNo)
                .Index(t => t.CallForDetails, unique: true);
            
            CreateTable(
                "dbo.bloodDonor",
                c => new
                    {
                        DonorID = c.Int(nullable: false, identity: true),
                        DonorName = c.String(nullable: false, maxLength: 50),
                        DonorAge = c.Int(nullable: false),
                        DonorGender = c.String(nullable: false, maxLength: 50),
                        DonorAddress = c.String(nullable: false),
                        DonorBloodtype = c.String(nullable: false),
                        DonorPhoneNumber = c.String(nullable: false, maxLength: 10),
                        Email = c.String(nullable: false, maxLength: 50, unicode: false),
                        DonorWeight = c.Single(nullable: false),
                        Ishealthy = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.DonorID)
                .Index(t => t.DonorPhoneNumber, unique: true)
                .Index(t => t.Email, unique: true);
            
            CreateTable(
                "dbo.bloodRequest",
                c => new
                    {
                        RequestID = c.Int(nullable: false, identity: true),
                        RequestorName = c.String(nullable: false, maxLength: 50),
                        RequestorAge = c.Int(nullable: false),
                        RequestorGender = c.String(nullable: false),
                        RequestorPhoneNumber = c.String(nullable: false, maxLength: 10),
                        Email = c.String(nullable: false, maxLength: 50, unicode: false),
                        RequestorAddress = c.String(nullable: false, maxLength: 100),
                        RequestedBloodtype = c.String(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        RequestedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.RequestID)
                .Index(t => t.RequestorPhoneNumber, unique: true)
                .Index(t => t.Email, unique: true);
            
            CreateTable(
                "dbo.bloodType",
                c => new
                    {
                        BloodId = c.Int(nullable: false, identity: true),
                        BloodTypes = c.String(nullable: false),
                        BloodUnit = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BloodId);
            
            CreateTable(
                "dbo.DoctorInfo",
                c => new
                    {
                        DoctorID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false, maxLength: 50, unicode: false),
                        PhoneNumber = c.String(nullable: false),
                        Speciality = c.String(nullable: false),
                        WorkingDays = c.String(nullable: false, maxLength: 100),
                        Experience = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.DoctorID)
                .Index(t => t.Email, unique: true);
            
            CreateTable(
                "dbo.patientrecord",
                c => new
                    {
                        PateintID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Age = c.Int(nullable: false),
                        gender = c.String(nullable: false),
                        ContactNumber = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Symptoms = c.String(nullable: false),
                        Ward = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.PateintID);
            
            CreateTable(
                "dbo.UserLogin",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        PhoneNumber = c.String(nullable: false),
                        Email = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.vacc_registration",
                c => new
                    {
                        vacc_id = c.Int(nullable: false, identity: true),
                        AadharCard_Number = c.String(nullable: false, maxLength: 12),
                        Name = c.String(nullable: false),
                        Gender = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false, maxLength: 10),
                        YOB = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.vacc_id)
                .Index(t => t.AadharCard_Number, unique: true)
                .Index(t => t.PhoneNumber, unique: true);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.vacc_registration", new[] { "PhoneNumber" });
            DropIndex("dbo.vacc_registration", new[] { "AadharCard_Number" });
            DropIndex("dbo.DoctorInfo", new[] { "Email" });
            DropIndex("dbo.bloodRequest", new[] { "Email" });
            DropIndex("dbo.bloodRequest", new[] { "RequestorPhoneNumber" });
            DropIndex("dbo.bloodDonor", new[] { "Email" });
            DropIndex("dbo.bloodDonor", new[] { "DonorPhoneNumber" });
            DropIndex("dbo.ambulance", new[] { "CallForDetails" });
            DropTable("dbo.vacc_registration");
            DropTable("dbo.UserLogin");
            DropTable("dbo.patientrecord");
            DropTable("dbo.DoctorInfo");
            DropTable("dbo.bloodType");
            DropTable("dbo.bloodRequest");
            DropTable("dbo.bloodDonor");
            DropTable("dbo.ambulance");
        }
    }
}
