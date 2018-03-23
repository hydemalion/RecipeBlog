namespace RecipeBlog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataAttr : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Categories", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Categories", "Blurb", c => c.String(nullable: false));
            AlterColumn("dbo.Recipes", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.Recipes", "Blurb", c => c.String(nullable: false));
            AlterColumn("dbo.Recipes", "PrepTime", c => c.String(nullable: false));
            AlterColumn("dbo.Recipes", "Ingredients", c => c.String(nullable: false));
            AlterColumn("dbo.Recipes", "FullInstructions", c => c.String(nullable: false));
            DropColumn("dbo.Recipes", "ResourceTypeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Recipes", "ResourceTypeId", c => c.Int(nullable: false));
            AlterColumn("dbo.Recipes", "FullInstructions", c => c.String());
            AlterColumn("dbo.Recipes", "Ingredients", c => c.String());
            AlterColumn("dbo.Recipes", "PrepTime", c => c.String());
            AlterColumn("dbo.Recipes", "Blurb", c => c.String());
            AlterColumn("dbo.Recipes", "Title", c => c.String());
            AlterColumn("dbo.Categories", "Blurb", c => c.String());
            AlterColumn("dbo.Categories", "Name", c => c.String());
        }
    }
}
