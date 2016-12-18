namespace HSEBuildings.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Droptest : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SideFlors", "Flor_Id", "dbo.Flors");
            DropForeignKey("dbo.SideFlors", "Side_Id", "dbo.Sides");
            DropIndex("dbo.SideFlors", new[] { "Flor_Id" });
            DropIndex("dbo.SideFlors", new[] { "Side_Id" });
            RenameColumn(table: "dbo.SideFlors", name: "Flor_Id", newName: "FlorId");
            RenameColumn(table: "dbo.SideFlors", name: "Side_Id", newName: "SideId");
            AlterColumn("dbo.SideFlors", "FlorId", c => c.Int(nullable: false));
            AlterColumn("dbo.SideFlors", "SideId", c => c.Int(nullable: false));
            CreateIndex("dbo.SideFlors", "FlorId");
            CreateIndex("dbo.SideFlors", "SideId");
            AddForeignKey("dbo.SideFlors", "FlorId", "dbo.Flors", "Id", cascadeDelete: true);
            AddForeignKey("dbo.SideFlors", "SideId", "dbo.Sides", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SideFlors", "SideId", "dbo.Sides");
            DropForeignKey("dbo.SideFlors", "FlorId", "dbo.Flors");
            DropIndex("dbo.SideFlors", new[] { "SideId" });
            DropIndex("dbo.SideFlors", new[] { "FlorId" });
            AlterColumn("dbo.SideFlors", "SideId", c => c.Int());
            AlterColumn("dbo.SideFlors", "FlorId", c => c.Int());
            RenameColumn(table: "dbo.SideFlors", name: "SideId", newName: "Side_Id");
            RenameColumn(table: "dbo.SideFlors", name: "FlorId", newName: "Flor_Id");
            CreateIndex("dbo.SideFlors", "Side_Id");
            CreateIndex("dbo.SideFlors", "Flor_Id");
            AddForeignKey("dbo.SideFlors", "Side_Id", "dbo.Sides", "Id");
            AddForeignKey("dbo.SideFlors", "Flor_Id", "dbo.Flors", "Id");
        }
    }
}
