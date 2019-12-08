namespace uthTrip.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImageEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Blocked_Users",
                c => new
                    {
                        Blocked_ID = c.Int(nullable: false),
                        User_ID = c.Int(),
                    })
                .PrimaryKey(t => t.Blocked_ID)
                .ForeignKey("dbo.Users", t => t.User_ID)
                .Index(t => t.User_ID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        User_ID = c.Int(nullable: false, identity: true),
                        First_Name = c.String(nullable: false, maxLength: 30, unicode: false),
                        Last_Name = c.String(nullable: false, maxLength: 30, unicode: false),
                        Email = c.String(nullable: false, maxLength: 30, unicode: false),
                        Username = c.String(nullable: false, maxLength: 30, unicode: false),
                        Password = c.String(nullable: false, maxLength: 30, unicode: false),
                        Birthday = c.DateTime(nullable: false, storeType: "date"),
                        Photo_Url = c.String(nullable: false, maxLength: 30, unicode: false),
                        Info = c.String(nullable: false, maxLength: 30, unicode: false),
                        image_id = c.Int(),
                    })
                .PrimaryKey(t => t.User_ID)
                .ForeignKey("dbo.ImageEntities", t => t.image_id)
                .Index(t => t.image_id);
            
            CreateTable(
                "dbo.ImageEntities",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        ImagePath = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        Review_ID = c.Int(nullable: false),
                        Writer_ID = c.Int(nullable: false),
                        Trip_ID = c.Int(nullable: false),
                        Review = c.String(maxLength: 150, unicode: false),
                        Mark = c.Int(),
                    })
                .PrimaryKey(t => t.Review_ID)
                .ForeignKey("dbo.Trips", t => t.Trip_ID)
                .ForeignKey("dbo.Users", t => t.Writer_ID)
                .Index(t => t.Writer_ID)
                .Index(t => t.Trip_ID);
            
            CreateTable(
                "dbo.Trips",
                c => new
                    {
                        Trip_ID = c.Int(nullable: false),
                        Trip_Title = c.String(maxLength: 100, unicode: false),
                        Description = c.String(maxLength: 300, unicode: false),
                        Price = c.Double(nullable: false),
                        Date_ID = c.Int(nullable: false),
                        Number_Of_People = c.Int(nullable: false),
                        Destination_ID = c.Int(nullable: false),
                        Creator_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Trip_ID)
                .ForeignKey("dbo.Dates_ranges", t => t.Date_ID)
                .ForeignKey("dbo.Destinations", t => t.Destination_ID)
                .ForeignKey("dbo.Users", t => t.Creator_ID)
                .Index(t => t.Date_ID)
                .Index(t => t.Destination_ID)
                .Index(t => t.Creator_ID);
            
            CreateTable(
                "dbo.Dates_ranges",
                c => new
                    {
                        Date_ID = c.Int(nullable: false),
                        Start_date = c.DateTime(storeType: "date"),
                        End_date = c.DateTime(storeType: "date"),
                    })
                .PrimaryKey(t => t.Date_ID);
            
            CreateTable(
                "dbo.Destinations",
                c => new
                    {
                        Destination_ID = c.Int(nullable: false),
                        Is_Abroad = c.Boolean(nullable: false),
                        Country = c.String(maxLength: 50, unicode: false),
                        City = c.String(maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.Destination_ID);
            
            CreateTable(
                "dbo.Rights",
                c => new
                    {
                        Rights_ID = c.Int(nullable: false),
                        User_ID = c.Int(nullable: false),
                        Role_ID = c.Int(nullable: false),
                        Trip_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Rights_ID)
                .ForeignKey("dbo.Roles", t => t.Role_ID)
                .ForeignKey("dbo.Trips", t => t.Trip_ID)
                .ForeignKey("dbo.Users", t => t.User_ID)
                .Index(t => t.User_ID)
                .Index(t => t.Role_ID)
                .Index(t => t.Trip_ID);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Role_ID = c.Int(nullable: false),
                        Title = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.Role_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Trips", "Creator_ID", "dbo.Users");
            DropForeignKey("dbo.Rights", "User_ID", "dbo.Users");
            DropForeignKey("dbo.Reviews", "Writer_ID", "dbo.Users");
            DropForeignKey("dbo.Rights", "Trip_ID", "dbo.Trips");
            DropForeignKey("dbo.Rights", "Role_ID", "dbo.Roles");
            DropForeignKey("dbo.Reviews", "Trip_ID", "dbo.Trips");
            DropForeignKey("dbo.Trips", "Destination_ID", "dbo.Destinations");
            DropForeignKey("dbo.Trips", "Date_ID", "dbo.Dates_ranges");
            DropForeignKey("dbo.Users", "image_id", "dbo.ImageEntities");
            DropForeignKey("dbo.Blocked_Users", "User_ID", "dbo.Users");
            DropIndex("dbo.Rights", new[] { "Trip_ID" });
            DropIndex("dbo.Rights", new[] { "Role_ID" });
            DropIndex("dbo.Rights", new[] { "User_ID" });
            DropIndex("dbo.Trips", new[] { "Creator_ID" });
            DropIndex("dbo.Trips", new[] { "Destination_ID" });
            DropIndex("dbo.Trips", new[] { "Date_ID" });
            DropIndex("dbo.Reviews", new[] { "Trip_ID" });
            DropIndex("dbo.Reviews", new[] { "Writer_ID" });
            DropIndex("dbo.Users", new[] { "image_id" });
            DropIndex("dbo.Blocked_Users", new[] { "User_ID" });
            DropTable("dbo.Roles");
            DropTable("dbo.Rights");
            DropTable("dbo.Destinations");
            DropTable("dbo.Dates_ranges");
            DropTable("dbo.Trips");
            DropTable("dbo.Reviews");
            DropTable("dbo.ImageEntities");
            DropTable("dbo.Users");
            DropTable("dbo.Blocked_Users");
        }
    }
}
