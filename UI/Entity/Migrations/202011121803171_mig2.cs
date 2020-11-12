namespace Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Educations", "Lesson_ID", c => c.Int());
            AddColumn("dbo.Lessons", "Education_ID", c => c.Int());
            CreateIndex("dbo.Educations", "Lesson_ID");
            CreateIndex("dbo.Lessons", "Education_ID");
            AddForeignKey("dbo.Educations", "Lesson_ID", "dbo.Lessons", "ID");
            AddForeignKey("dbo.Lessons", "Education_ID", "dbo.Educations", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Lessons", "Education_ID", "dbo.Educations");
            DropForeignKey("dbo.Educations", "Lesson_ID", "dbo.Lessons");
            DropIndex("dbo.Lessons", new[] { "Education_ID" });
            DropIndex("dbo.Educations", new[] { "Lesson_ID" });
            DropColumn("dbo.Lessons", "Education_ID");
            DropColumn("dbo.Educations", "Lesson_ID");
        }
    }
}
