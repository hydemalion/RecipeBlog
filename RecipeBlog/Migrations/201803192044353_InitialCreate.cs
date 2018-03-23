namespace RecipeBlog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Recipes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Blurb = c.String(),
                        PrepTime = c.String(),
                        Ingredients = c.String(),
                        QuickInstructions = c.String(),
                        FullInstructions = c.String(),
                        ImageName = c.String(),
                        Published = c.Boolean(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        PublishDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Recipes");
        }
    }
}
