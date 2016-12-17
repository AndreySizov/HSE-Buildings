namespace HSEBuildings.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newTest : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PhotoSets", "PhotoId", "dbo.Photos");
            DropIndex("dbo.PhotoSets", new[] { "PhotoId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.PhotoSets", "PhotoId");
            AddForeignKey("dbo.PhotoSets", "PhotoId", "dbo.Photos", "Id", cascadeDelete: true);
        }
    }
}
