namespace RecipeBlog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ManyToMany : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RecipeCategory",
                c => new
                    {
                        RecipeID = c.Int(nullable: false),
                        CategoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.RecipeID, t.CategoryID })
                .ForeignKey("dbo.Recipes", t => t.RecipeID, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .Index(t => t.RecipeID)
                .Index(t => t.CategoryID);
            
            AddColumn("dbo.Recipes", "ResourceTypeId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RecipeCategory", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.RecipeCategory", "RecipeID", "dbo.Recipes");
            DropIndex("dbo.RecipeCategory", new[] { "CategoryID" });
            DropIndex("dbo.RecipeCategory", new[] { "RecipeID" });
            DropColumn("dbo.Recipes", "ResourceTypeId");
            DropTable("dbo.RecipeCategory");
        }
    }
}
