namespace HOSPITAL_MANAGEMENT_SYSTEM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.doctor",
                c => new
                    {
                        DoctorID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Gender = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                        Email = c.String(nullable: false, maxLength: 50, unicode: false),
                        WorkingDays = c.String(nullable: false, maxLength: 100),
                        Speciality = c.String(nullable: false),
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
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.doctor", new[] { "Email" });
            DropTable("dbo.UserLogin");
            DropTable("dbo.patientrecord");
            DropTable("dbo.doctor");
        }
    }
}
