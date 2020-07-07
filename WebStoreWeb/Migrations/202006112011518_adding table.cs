namespace WebStoreWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingtable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        UserID = c.String(),
                        UserAddress = c.String(),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.ProductBlobs",
                c => new
                    {
                        ProductBlobId = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        ImageName = c.String(),
                        ImagePath = c.String(),
                        ImageBinray = c.Binary(),
                    })
                .PrimaryKey(t => t.ProductBlobId)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        ReviewId = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        UserId = c.String(),
                    })
                .PrimaryKey(t => t.ReviewId)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reviews", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductBlobs", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Orders", "ProductId", "dbo.Products");
            DropIndex("dbo.Reviews", new[] { "ProductId" });
            DropIndex("dbo.ProductBlobs", new[] { "ProductId" });
            DropIndex("dbo.Orders", new[] { "ProductId" });
            DropTable("dbo.Reviews");
            DropTable("dbo.ProductBlobs");
            DropTable("dbo.Orders");
        }
    }
}
