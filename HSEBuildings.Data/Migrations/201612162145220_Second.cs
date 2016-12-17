namespace HSEBuildings.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Second : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Floors", "Campus_Id", "dbo.Campus");
            DropForeignKey("dbo.Rooms", "Floor_Id", "dbo.Floors");
            DropForeignKey("dbo.Photos", "Room_Id", "dbo.Rooms");
            DropIndex("dbo.Floors", new[] { "Campus_Id" });
            DropIndex("dbo.Photos", new[] { "Room_Id" });
            DropIndex("dbo.Rooms", new[] { "Floor_Id" });
            CreateTable(
                "dbo.Flors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        CampusId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Photos", "RoomId", c => c.Int(nullable: false));
            AddColumn("dbo.Rooms", "FlorId", c => c.Int(nullable: false));
            DropColumn("dbo.Photos", "Room_Id");
            DropColumn("dbo.Rooms", "Floor_Id");
            DropTable("dbo.Floors");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Floors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        Campus_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Rooms", "Floor_Id", c => c.Int());
            AddColumn("dbo.Photos", "Room_Id", c => c.Int());
            DropColumn("dbo.Rooms", "FlorId");
            DropColumn("dbo.Photos", "RoomId");
            DropTable("dbo.Flors");
            CreateIndex("dbo.Rooms", "Floor_Id");
            CreateIndex("dbo.Photos", "Room_Id");
            CreateIndex("dbo.Floors", "Campus_Id");
            AddForeignKey("dbo.Photos", "Room_Id", "dbo.Rooms", "Id");
            AddForeignKey("dbo.Rooms", "Floor_Id", "dbo.Floors", "Id");
            AddForeignKey("dbo.Floors", "Campus_Id", "dbo.Campus", "Id");
        }
    }
}
