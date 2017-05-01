namespace AllegroWebAplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedNameofKeyFactoryclass : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.KeyStructs", newName: "KeyFactoryModels");
            RenameColumn(table: "dbo.Auctions", name: "KeyStruct_Id", newName: "KeyFactoryModel_Id");
            RenameColumn(table: "dbo.Keys", name: "KeyStruct_Id", newName: "KeyFactoryModel_Id");
            RenameIndex(table: "dbo.Keys", name: "IX_KeyStruct_Id", newName: "IX_KeyFactoryModel_Id");
            RenameIndex(table: "dbo.Auctions", name: "IX_KeyStruct_Id", newName: "IX_KeyFactoryModel_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Auctions", name: "IX_KeyFactoryModel_Id", newName: "IX_KeyStruct_Id");
            RenameIndex(table: "dbo.Keys", name: "IX_KeyFactoryModel_Id", newName: "IX_KeyStruct_Id");
            RenameColumn(table: "dbo.Keys", name: "KeyFactoryModel_Id", newName: "KeyStruct_Id");
            RenameColumn(table: "dbo.Auctions", name: "KeyFactoryModel_Id", newName: "KeyStruct_Id");
            RenameTable(name: "dbo.KeyFactoryModels", newName: "KeyStructs");
        }
    }
}
