namespace Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig04 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Categories", "Lesson_ID", "dbo.Lessons");
            DropIndex("dbo.Categories", new[] { "Lesson_ID" });
            DropColumn("dbo.Categories", "Lesson_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Categories", "Lesson_ID", c => c.Int());
            CreateIndex("dbo.Categories", "Lesson_ID");
            AddForeignKey("dbo.Categories", "Lesson_ID", "dbo.Lessons", "ID");
        }
    }
}
