namespace HSEBuildings.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ILikeStupidMistakes : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Rooms", "SideFlor_Id", "dbo.SideFlors");
            DropIndex("dbo.Rooms", new[] { "SideFlor_Id" });
            RenameColumn(table: "dbo.Rooms", name: "SideFlor_Id", newName: "SideFlorId");
            AlterColumn("dbo.Rooms", "SideFlorId", c => c.Int(nullable: false));
            CreateIndex("dbo.Rooms", "SideFlorId");
            AddForeignKey("dbo.Rooms", "SideFlorId", "dbo.SideFlors", "Id", cascadeDelete: true);
            DropColumn("dbo.Rooms", "FlorSideId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rooms", "FlorSideId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Rooms", "SideFlorId", "dbo.SideFlors");
            DropIndex("dbo.Rooms", new[] { "SideFlorId" });
            AlterColumn("dbo.Rooms", "SideFlorId", c => c.Int());
            RenameColumn(table: "dbo.Rooms", name: "SideFlorId", newName: "SideFlor_Id");
            CreateIndex("dbo.Rooms", "SideFlor_Id");
            AddForeignKey("dbo.Rooms", "SideFlor_Id", "dbo.SideFlors", "Id");
        }
    }
}
