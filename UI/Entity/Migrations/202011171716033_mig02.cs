namespace Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig02 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.LessonCategories", "Lesson_ID", "dbo.Lessons");
            DropForeignKey("dbo.LessonCategories", "Category_ID", "dbo.Categories");
            DropIndex("dbo.LessonCategories", new[] { "Lesson_ID" });
            DropIndex("dbo.LessonCategories", new[] { "Category_ID" });
            AddColumn("dbo.Lessons", "Category_ID", c => c.Int());
            CreateIndex("dbo.Lessons", "Category_ID");
            AddForeignKey("dbo.Lessons", "Category_ID", "dbo.Categories", "ID");
            DropTable("dbo.LessonCategories");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.LessonCategories",
                c => new
                    {
                        Lesson_ID = c.Int(nullable: false),
                        Category_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Lesson_ID, t.Category_ID });
            
            DropForeignKey("dbo.Lessons", "Category_ID", "dbo.Categories");
            DropIndex("dbo.Lessons", new[] { "Category_ID" });
            DropColumn("dbo.Lessons", "Category_ID");
            CreateIndex("dbo.LessonCategories", "Category_ID");
            CreateIndex("dbo.LessonCategories", "Lesson_ID");
            AddForeignKey("dbo.LessonCategories", "Category_ID", "dbo.Categories", "ID", cascadeDelete: true);
            AddForeignKey("dbo.LessonCategories", "Lesson_ID", "dbo.Lessons", "ID", cascadeDelete: true);
        }
    }
}
