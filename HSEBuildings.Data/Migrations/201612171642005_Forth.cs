namespace HSEBuildings.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Forth : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Flors", "CampusId", "dbo.Campus");
            DropForeignKey("dbo.Rooms", "FlorId", "dbo.Flors");
            DropForeignKey("dbo.Photos", "RoomId", "dbo.Rooms");
            DropIndex("dbo.Flors", new[] { "CampusId" });
            DropIndex("dbo.Photos", new[] { "RoomId" });
            DropIndex("dbo.Rooms", new[] { "FlorId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Rooms", "FlorId");
            CreateIndex("dbo.Photos", "RoomId");
            CreateIndex("dbo.Flors", "CampusId");
            AddForeignKey("dbo.Photos", "RoomId", "dbo.Rooms", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Rooms", "FlorId", "dbo.Flors", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Flors", "CampusId", "dbo.Campus", "Id", cascadeDelete: true);
        }
    }
}
