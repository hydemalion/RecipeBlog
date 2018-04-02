namespace RecipeBlog.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Collections.Generic;
    using System.Web.Mvc;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity.Infrastructure;


    public class RecipeModels : DbContext
    {
        // Your context has been configured to use a 'RecipeModels' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'RecipeBlog.Models.RecipeModels' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'RecipeModels' 
        // connection string in the application configuration file.
        public RecipeModels()
            : base("name=RecipeModels")
        {
        }

        public System.Data.Entity.DbSet<RecipeBlog.Models.Recipe> Recipes { get; set; }
        public System.Data.Entity.DbSet<RecipeBlog.Models.Category> Categories { get; set; }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }

            //this is not necessary, but it lets you specify the ID and Table names
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Recipe>()
                        .HasMany<Category>(s => s.SelectedCategories)
                        .WithMany(c => c.Recipes)
                        .Map(cs =>
                        {
                            cs.MapLeftKey("RecipeID");
                            cs.MapRightKey("CategoryID");
                            cs.ToTable("RecipeCategory");
                        });

        }
    }

    public class Recipe
    {
        public Recipe()
        {
            this.SelectedCategories = new HashSet<Category>();
        }


        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Blurb { get; set; }
        [DisplayName("Preparation Time")]
        [Required]
        public string PrepTime { get; set; }
        [Required]
        public string Ingredients { get; set; }
        [DisplayName("Quick Instructions")]
        public string QuickInstructions { get; set; }
        [DisplayName("Full Instructions")]
        [Required]
        public string FullInstructions { get; set; }
        [DisplayName("Image Name")]
        public string ImageName { get; set; }
        public bool Published { get; set; }
        public DateTime CreatedOn { get; set; }
        [DisplayName("Publish Date")]
        [Required]
        public DateTime PublishDate { get; set; }

        public virtual ICollection<Category> SelectedCategories { get; set; }


    }

    public class Category
    {
        public Category()
        {
            this.Recipes = new HashSet<Recipe>();
        }
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Blurb { get; set; }
        [DisplayName("Image Name")]
        public string ImageName { get; set; }
        [DisplayName("Display Order")]
        [Required]
        public int DisplayOrder { get; set; }

        public virtual ICollection<Recipe> Recipes { get; set; }


    }

}