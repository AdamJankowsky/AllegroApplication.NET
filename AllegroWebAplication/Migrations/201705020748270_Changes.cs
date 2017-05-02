namespace AllegroWebAplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changes : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Keys", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Keys", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
    }
}
