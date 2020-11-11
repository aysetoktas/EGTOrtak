namespace Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig06 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Categories", "Education_ID", "dbo.Educations");
            DropForeignKey("dbo.Educations", "Category_ID", "dbo.Categories");
            DropForeignKey("dbo.Categories", "Education_ID1", "dbo.Educations");
            DropForeignKey("dbo.Educations", "Category_ID1", "dbo.Categories");
            DropIndex("dbo.Educations", new[] { "Category_ID" });
            DropIndex("dbo.Educations", new[] { "Category_ID1" });
            DropIndex("dbo.Categories", new[] { "Education_ID" });
            DropIndex("dbo.Categories", new[] { "Education_ID1" });
            CreateTable(
                "dbo.CategoryEducations",
                c => new
                    {
                        Category_ID = c.Int(nullable: false),
                        Education_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Category_ID, t.Education_ID })
                .ForeignKey("dbo.Categories", t => t.Category_ID, cascadeDelete: true)
                .ForeignKey("dbo.Educations", t => t.Education_ID, cascadeDelete: true)
                .Index(t => t.Category_ID)
                .Index(t => t.Education_ID);
            
            DropColumn("dbo.Educations", "Category_ID");
            DropColumn("dbo.Educations", "Category_ID1");
            DropColumn("dbo.Categories", "Education_ID");
            DropColumn("dbo.Categories", "Education_ID1");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Categories", "Education_ID1", c => c.Int());
            AddColumn("dbo.Categories", "Education_ID", c => c.Int());
            AddColumn("dbo.Educations", "Category_ID1", c => c.Int());
            AddColumn("dbo.Educations", "Category_ID", c => c.Int());
            DropForeignKey("dbo.CategoryEducations", "Education_ID", "dbo.Educations");
            DropForeignKey("dbo.CategoryEducations", "Category_ID", "dbo.Categories");
            DropIndex("dbo.CategoryEducations", new[] { "Education_ID" });
            DropIndex("dbo.CategoryEducations", new[] { "Category_ID" });
            DropTable("dbo.CategoryEducations");
            CreateIndex("dbo.Categories", "Education_ID1");
            CreateIndex("dbo.Categories", "Education_ID");
            CreateIndex("dbo.Educations", "Category_ID1");
            CreateIndex("dbo.Educations", "Category_ID");
            AddForeignKey("dbo.Educations", "Category_ID1", "dbo.Categories", "ID");
            AddForeignKey("dbo.Categories", "Education_ID1", "dbo.Educations", "ID");
            AddForeignKey("dbo.Educations", "Category_ID", "dbo.Categories", "ID");
            AddForeignKey("dbo.Categories", "Education_ID", "dbo.Educations", "ID");
        }
    }
}
