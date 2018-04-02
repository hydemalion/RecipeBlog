namespace RecipeBlog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class selectedcategoriesfix : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Categories", "Recipe_Id", "dbo.Recipes");
            DropIndex("dbo.Categories", new[] { "Recipe_Id" });
            DropColumn("dbo.Categories", "Recipe_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Categories", "Recipe_Id", c => c.Int());
            CreateIndex("dbo.Categories", "Recipe_Id");
            AddForeignKey("dbo.Categories", "Recipe_Id", "dbo.Recipes", "Id");
        }
    }
}
