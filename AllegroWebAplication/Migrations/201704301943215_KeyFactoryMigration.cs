namespace AllegroWebAplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class KeyFactoryMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Keys",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                        Used = c.Boolean(nullable: false),
                        KeyStruct_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.KeyStructs", t => t.KeyStruct_Id)
                .Index(t => t.KeyStruct_Id);
            
            CreateTable(
                "dbo.KeyStructs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Auctions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AuctionNumber = c.Long(nullable: false),
                        KeyStruct_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.KeyStructs", t => t.KeyStruct_Id)
                .Index(t => t.KeyStruct_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Keys", "KeyStruct_Id", "dbo.KeyStructs");
            DropForeignKey("dbo.Auctions", "KeyStruct_Id", "dbo.KeyStructs");
            DropIndex("dbo.Auctions", new[] { "KeyStruct_Id" });
            DropIndex("dbo.Keys", new[] { "KeyStruct_Id" });
            DropTable("dbo.Auctions");
            DropTable("dbo.KeyStructs");
            DropTable("dbo.Keys");
        }
    }
}
