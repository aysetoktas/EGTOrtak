namespace Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig08 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.LiveLessonStudents", "LiveLesson_ID", "dbo.LiveLessons");
            DropForeignKey("dbo.LiveLessonStudents", "Student_ID", "dbo.Students");
            DropIndex("dbo.LiveLessonStudents", new[] { "LiveLesson_ID" });
            DropIndex("dbo.LiveLessonStudents", new[] { "Student_ID" });
            AddColumn("dbo.Lessons", "IsLive", c => c.Boolean());
            DropColumn("dbo.Lessons", "ProjectLink");
            DropTable("dbo.LiveLessons");
            DropTable("dbo.LiveLessonStudents");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.LiveLessonStudents",
                c => new
                    {
                        LiveLesson_ID = c.Int(nullable: false),
                        Student_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.LiveLesson_ID, t.Student_ID });
            
            CreateTable(
                "dbo.LiveLessons",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Lessons", "ProjectLink", c => c.String());
            DropColumn("dbo.Lessons", "IsLive");
            CreateIndex("dbo.LiveLessonStudents", "Student_ID");
            CreateIndex("dbo.LiveLessonStudents", "LiveLesson_ID");
            AddForeignKey("dbo.LiveLessonStudents", "Student_ID", "dbo.Students", "ID", cascadeDelete: true);
            AddForeignKey("dbo.LiveLessonStudents", "LiveLesson_ID", "dbo.LiveLessons", "ID", cascadeDelete: true);
        }
    }
}
