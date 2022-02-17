namespace HOSPITAL_MANAGEMENT_SYSTEM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Bill : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.bill1",
                c => new
                    {
                        PaymentID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                        Email = c.String(nullable: false, maxLength: 50, unicode: false),
                        DocCharge = c.Int(nullable: false),
                        WardCharge = c.Int(nullable: false),
                        Days = c.String(nullable: false, maxLength: 100),
                        BillAmount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PaymentID)
                .Index(t => t.Email, unique: true);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.bill1", new[] { "Email" });
            DropTable("dbo.bill1");
        }
    }
}
