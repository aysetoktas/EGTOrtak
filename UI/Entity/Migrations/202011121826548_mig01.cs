namespace Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig01 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.LessonEducations", "Lesson_ID", "dbo.Lessons");
            DropForeignKey("dbo.LessonEducations", "Education_ID", "dbo.Educations");
            DropIndex("dbo.LessonEducations", new[] { "Lesson_ID" });
            DropIndex("dbo.LessonEducations", new[] { "Education_ID" });
            AddColumn("dbo.Lessons", "EducationID", c => c.Int(nullable: false));
            CreateIndex("dbo.Lessons", "EducationID");
            AddForeignKey("dbo.Lessons", "EducationID", "dbo.Educations", "ID", cascadeDelete: true);
            DropTable("dbo.LessonEducations");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.LessonEducations",
                c => new
                    {
                        Lesson_ID = c.Int(nullable: false),
                        Education_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Lesson_ID, t.Education_ID });
            
            DropForeignKey("dbo.Lessons", "EducationID", "dbo.Educations");
            DropIndex("dbo.Lessons", new[] { "EducationID" });
            DropColumn("dbo.Lessons", "EducationID");
            CreateIndex("dbo.LessonEducations", "Education_ID");
            CreateIndex("dbo.LessonEducations", "Lesson_ID");
            AddForeignKey("dbo.LessonEducations", "Education_ID", "dbo.Educations", "ID", cascadeDelete: true);
            AddForeignKey("dbo.LessonEducations", "Lesson_ID", "dbo.Lessons", "ID", cascadeDelete: true);
        }
    }
}
