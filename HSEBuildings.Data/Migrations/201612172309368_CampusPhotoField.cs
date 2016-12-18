namespace HSEBuildings.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CampusPhotoField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Campus", "CampusPhoto", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Campus", "CampusPhoto");
        }
    }
}
