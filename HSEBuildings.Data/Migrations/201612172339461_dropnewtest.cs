namespace HSEBuildings.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dropnewtest : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.PhotoSets", "PhotoId");
            AddForeignKey("dbo.PhotoSets", "PhotoId", "dbo.Photos", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PhotoSets", "PhotoId", "dbo.Photos");
            DropIndex("dbo.PhotoSets", new[] { "PhotoId" });
        }
    }
}
