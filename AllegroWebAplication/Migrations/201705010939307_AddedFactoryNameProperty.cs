namespace AllegroWebAplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedFactoryNameProperty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.KeyStructs", "FactoryName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.KeyStructs", "FactoryName");
        }
    }
}
