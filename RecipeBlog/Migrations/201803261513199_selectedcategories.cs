namespace RecipeBlog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class selectedcategories : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "Recipe_Id", c => c.Int());
            CreateIndex("dbo.Categories", "Recipe_Id");
            AddForeignKey("dbo.Categories", "Recipe_Id", "dbo.Recipes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Categories", "Recipe_Id", "dbo.Recipes");
            DropIndex("dbo.Categories", new[] { "Recipe_Id" });
            DropColumn("dbo.Categories", "Recipe_Id");
        }
    }
}
