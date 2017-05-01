namespace AllegroWebAplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Keys",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                        KeyManagerModel_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.KeyManagerModels", t => t.KeyManagerModel_Id)
                .Index(t => t.KeyManagerModel_Id);
            
            CreateTable(
                "dbo.KeyManagerModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FactoryName = c.String(),
                        AuctionID = c.Long(nullable: false),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Keys", "KeyManagerModel_Id", "dbo.KeyManagerModels");
            DropIndex("dbo.Keys", new[] { "KeyManagerModel_Id" });
            DropTable("dbo.KeyManagerModels");
            DropTable("dbo.Keys");
        }
    }
}
