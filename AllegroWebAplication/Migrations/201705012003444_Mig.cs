namespace AllegroWebAplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mig : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Keys", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Keys", "Discriminator");
        }
    }
}
