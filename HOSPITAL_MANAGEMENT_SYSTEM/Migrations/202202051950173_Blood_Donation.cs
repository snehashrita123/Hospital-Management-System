namespace HOSPITAL_MANAGEMENT_SYSTEM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Blood_Donation : DbMigration
    {
        public override void Up()
        {
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
                        RequestorGender = c.Int(nullable: false),
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
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.bloodRequest", new[] { "Email" });
            DropIndex("dbo.bloodRequest", new[] { "RequestorPhoneNumber" });
            DropIndex("dbo.bloodDonor", new[] { "Email" });
            DropIndex("dbo.bloodDonor", new[] { "DonorPhoneNumber" });
            DropTable("dbo.bloodRequest");
            DropTable("dbo.bloodDonor");
        }
    }
}
