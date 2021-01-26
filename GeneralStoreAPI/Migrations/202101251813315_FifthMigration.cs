namespace GeneralStoreAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FifthMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        SKU = c.String(maxLength: 128),
                        ItemCount = c.Int(nullable: false),
                        DateOfTransaction = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.SKU)
                .Index(t => t.CustomerId)
                .Index(t => t.SKU);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "SKU", "dbo.Products");
            DropForeignKey("dbo.Transactions", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Transactions", new[] { "SKU" });
            DropIndex("dbo.Transactions", new[] { "CustomerId" });
            DropTable("dbo.Transactions");
        }
    }
}
