namespace Web_Store.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Product : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Carts");
            AddColumn("dbo.Carts", "UserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Carts", "CartId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Carts", "CartId");
            CreateIndex("dbo.Carts", "UserId");
            AddForeignKey("dbo.Carts", "UserId", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.Carts", "ItemId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Carts", "ItemId", c => c.String(nullable: false, maxLength: 128));
            DropForeignKey("dbo.Carts", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Carts", new[] { "UserId" });
            DropPrimaryKey("dbo.Carts");
            AlterColumn("dbo.Carts", "CartId", c => c.String());
            DropColumn("dbo.Carts", "UserId");
            AddPrimaryKey("dbo.Carts", "ItemId");
        }
    }
}
