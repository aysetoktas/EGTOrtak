namespace Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig03 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Lessons", "Category_ID", "dbo.Categories");
            DropIndex("dbo.Lessons", new[] { "Category_ID" });
            AddColumn("dbo.Categories", "Lesson_ID", c => c.Int());
            CreateIndex("dbo.Categories", "Lesson_ID");
            AddForeignKey("dbo.Categories", "Lesson_ID", "dbo.Lessons", "ID");
            DropColumn("dbo.Lessons", "Category_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Lessons", "Category_ID", c => c.Int());
            DropForeignKey("dbo.Categories", "Lesson_ID", "dbo.Lessons");
            DropIndex("dbo.Categories", new[] { "Lesson_ID" });
            DropColumn("dbo.Categories", "Lesson_ID");
            CreateIndex("dbo.Lessons", "Category_ID");
            AddForeignKey("dbo.Lessons", "Category_ID", "dbo.Categories", "ID");
        }
    }
}
