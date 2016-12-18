namespace HSEBuildings.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DownToThird : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Flors", "CampusId");
            CreateIndex("dbo.Photos", "RoomId");
            CreateIndex("dbo.Rooms", "FlorId");
            AddForeignKey("dbo.Flors", "CampusId", "dbo.Campus", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Rooms", "FlorId", "dbo.Flors", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Photos", "RoomId", "dbo.Rooms", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Photos", "RoomId", "dbo.Rooms");
            DropForeignKey("dbo.Rooms", "FlorId", "dbo.Flors");
            DropForeignKey("dbo.Flors", "CampusId", "dbo.Campus");
            DropIndex("dbo.Rooms", new[] { "FlorId" });
            DropIndex("dbo.Photos", new[] { "RoomId" });
            DropIndex("dbo.Flors", new[] { "CampusId" });
        }
    }
}
