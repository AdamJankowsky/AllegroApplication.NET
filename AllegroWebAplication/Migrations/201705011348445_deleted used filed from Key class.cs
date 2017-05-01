namespace AllegroWebAplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletedusedfiledfromKeyclass : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Keys", "Used");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Keys", "Used", c => c.Boolean(nullable: false));
        }
    }
}
