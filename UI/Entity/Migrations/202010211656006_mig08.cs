namespace Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig08 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LessonCategories",
                c => new
                    {
                        Lesson_ID = c.Int(nullable: false),
                        Category_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Lesson_ID, t.Category_ID })
                .ForeignKey("dbo.Lessons", t => t.Lesson_ID, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.Category_ID, cascadeDelete: true)
                .Index(t => t.Lesson_ID)
                .Index(t => t.Category_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LessonCategories", "Category_ID", "dbo.Categories");
            DropForeignKey("dbo.LessonCategories", "Lesson_ID", "dbo.Lessons");
            DropIndex("dbo.LessonCategories", new[] { "Category_ID" });
            DropIndex("dbo.LessonCategories", new[] { "Lesson_ID" });
            DropTable("dbo.LessonCategories");
        }
    }
}
