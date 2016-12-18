namespace HSEBuildings.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testrel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SideFlors", "FlorId", "dbo.Flors");
            DropForeignKey("dbo.SideFlors", "SideId", "dbo.Sides");
            DropIndex("dbo.SideFlors", new[] { "FlorId" });
            DropIndex("dbo.SideFlors", new[] { "SideId" });
            RenameColumn(table: "dbo.SideFlors", name: "FlorId", newName: "Flor_Id");
            RenameColumn(table: "dbo.SideFlors", name: "SideId", newName: "Side_Id");
            AlterColumn("dbo.SideFlors", "Flor_Id", c => c.Int());
            AlterColumn("dbo.SideFlors", "Side_Id", c => c.Int());
            CreateIndex("dbo.SideFlors", "Flor_Id");
            CreateIndex("dbo.SideFlors", "Side_Id");
            AddForeignKey("dbo.SideFlors", "Flor_Id", "dbo.Flors", "Id");
            AddForeignKey("dbo.SideFlors", "Side_Id", "dbo.Sides", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SideFlors", "Side_Id", "dbo.Sides");
            DropForeignKey("dbo.SideFlors", "Flor_Id", "dbo.Flors");
            DropIndex("dbo.SideFlors", new[] { "Side_Id" });
            DropIndex("dbo.SideFlors", new[] { "Flor_Id" });
            AlterColumn("dbo.SideFlors", "Side_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.SideFlors", "Flor_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.SideFlors", name: "Side_Id", newName: "SideId");
            RenameColumn(table: "dbo.SideFlors", name: "Flor_Id", newName: "FlorId");
            CreateIndex("dbo.SideFlors", "SideId");
            CreateIndex("dbo.SideFlors", "FlorId");
            AddForeignKey("dbo.SideFlors", "SideId", "dbo.Sides", "Id", cascadeDelete: true);
            AddForeignKey("dbo.SideFlors", "FlorId", "dbo.Flors", "Id", cascadeDelete: true);
        }
    }
}
