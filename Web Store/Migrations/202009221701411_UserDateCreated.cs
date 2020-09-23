namespace Web_Store.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserDateCreated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "DateCreated", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "DateCreated");
        }
    }
}
