namespace HSEBuildings.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SwapSidesAndFlors : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Flors", "CampusId", "dbo.Campus");
            DropIndex("dbo.Flors", new[] { "CampusId" });
            AddColumn("dbo.Sides", "CampusId", c => c.Int(nullable: false));
            CreateIndex("dbo.Sides", "CampusId");
            AddForeignKey("dbo.Sides", "CampusId", "dbo.Campus", "Id", cascadeDelete: true);
            DropColumn("dbo.Flors", "CampusId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Flors", "CampusId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Sides", "CampusId", "dbo.Campus");
            DropIndex("dbo.Sides", new[] { "CampusId" });
            DropColumn("dbo.Sides", "CampusId");
            CreateIndex("dbo.Flors", "CampusId");
            AddForeignKey("dbo.Flors", "CampusId", "dbo.Campus", "Id", cascadeDelete: true);
        }
    }
}
