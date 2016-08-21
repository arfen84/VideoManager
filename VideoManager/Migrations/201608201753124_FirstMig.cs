namespace VideoManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMig : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "Link", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "Link");
        }
    }
}
