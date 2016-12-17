namespace HSEBuildings.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewSchema : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Rooms", "FlorId", "dbo.Flors");
            DropForeignKey("dbo.Photos", "RoomId", "dbo.Rooms");
            DropIndex("dbo.Photos", new[] { "RoomId" });
            DropIndex("dbo.Rooms", new[] { "FlorId" });
            CreateTable(
                "dbo.PhotoSets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PhotoId = c.Int(nullable: false),
                        PhotoSetNum = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Photos", t => t.PhotoId, cascadeDelete: true)
                .Index(t => t.PhotoId);
            
            CreateTable(
                "dbo.SideFlors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FlorId = c.Int(nullable: false),
                        SideId = c.Int(nullable: false),
                        PhotoSetNum = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Flors", t => t.FlorId, cascadeDelete: true)
                .ForeignKey("dbo.Sides", t => t.SideId, cascadeDelete: true)
                .Index(t => t.FlorId)
                .Index(t => t.SideId);
            
            CreateTable(
                "dbo.Sides",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Rooms", "FlorSideId", c => c.Int(nullable: false));
            AddColumn("dbo.Rooms", "SideFlor_Id", c => c.Int());
            CreateIndex("dbo.Rooms", "SideFlor_Id");
            AddForeignKey("dbo.Rooms", "SideFlor_Id", "dbo.SideFlors", "Id");
            DropColumn("dbo.Photos", "RoomId");
            DropColumn("dbo.Rooms", "Side");
            DropColumn("dbo.Rooms", "FlorId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rooms", "FlorId", c => c.Int(nullable: false));
            AddColumn("dbo.Rooms", "Side", c => c.Boolean(nullable: false));
            AddColumn("dbo.Photos", "RoomId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Rooms", "SideFlor_Id", "dbo.SideFlors");
            DropForeignKey("dbo.SideFlors", "SideId", "dbo.Sides");
            DropForeignKey("dbo.SideFlors", "FlorId", "dbo.Flors");
            DropForeignKey("dbo.PhotoSets", "PhotoId", "dbo.Photos");
            DropIndex("dbo.SideFlors", new[] { "SideId" });
            DropIndex("dbo.SideFlors", new[] { "FlorId" });
            DropIndex("dbo.Rooms", new[] { "SideFlor_Id" });
            DropIndex("dbo.PhotoSets", new[] { "PhotoId" });
            DropColumn("dbo.Rooms", "SideFlor_Id");
            DropColumn("dbo.Rooms", "FlorSideId");
            DropTable("dbo.Sides");
            DropTable("dbo.SideFlors");
            DropTable("dbo.PhotoSets");
            CreateIndex("dbo.Rooms", "FlorId");
            CreateIndex("dbo.Photos", "RoomId");
            AddForeignKey("dbo.Photos", "RoomId", "dbo.Rooms", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Rooms", "FlorId", "dbo.Flors", "Id", cascadeDelete: true);
        }
    }
}
