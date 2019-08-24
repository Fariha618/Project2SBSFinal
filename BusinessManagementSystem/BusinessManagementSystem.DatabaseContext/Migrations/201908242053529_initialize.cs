namespace BusinessManagementSystem.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialize : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.SalesDetails", name: "ProductId", newName: "ProductsId");
            RenameIndex(table: "dbo.SalesDetails", name: "IX_ProductId", newName: "IX_ProductsId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.SalesDetails", name: "IX_ProductsId", newName: "IX_ProductId");
            RenameColumn(table: "dbo.SalesDetails", name: "ProductsId", newName: "ProductId");
        }
    }
}
