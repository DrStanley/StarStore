namespace Web_Store.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CategoryUserID1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        ItemId = c.String(nullable: false, maxLength: 128),
                        CartId = c.String(),
                        Quantity = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ItemId)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            AddColumn("dbo.Products", "Quantity", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Carts", "ProductId", "dbo.Products");
            DropIndex("dbo.Carts", new[] { "ProductId" });
            DropColumn("dbo.Products", "Quantity");
            DropTable("dbo.Carts");
        }
    }
}
