namespace HSEBuildings.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Campus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Latitude = c.Double(nullable: false),
                        Longitude = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Floors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        Campus_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Campus", t => t.Campus_Id)
                .Index(t => t.Campus_Id);
            
            CreateTable(
                "dbo.Photos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Link = c.String(),
                        Room_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Rooms", t => t.Room_Id)
                .Index(t => t.Room_Id);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Side = c.Boolean(nullable: false),
                        Floor_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Floors", t => t.Floor_Id)
                .Index(t => t.Floor_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Photos", "Room_Id", "dbo.Rooms");
            DropForeignKey("dbo.Rooms", "Floor_Id", "dbo.Floors");
            DropForeignKey("dbo.Floors", "Campus_Id", "dbo.Campus");
            DropIndex("dbo.Rooms", new[] { "Floor_Id" });
            DropIndex("dbo.Photos", new[] { "Room_Id" });
            DropIndex("dbo.Floors", new[] { "Campus_Id" });
            DropTable("dbo.Rooms");
            DropTable("dbo.Photos");
            DropTable("dbo.Floors");
            DropTable("dbo.Campus");
        }
    }
}
