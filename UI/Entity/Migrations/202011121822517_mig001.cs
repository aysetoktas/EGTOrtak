namespace Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig001 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Lessons", "EducationID", "dbo.Educations");
            DropForeignKey("dbo.Educations", "Lesson_ID", "dbo.Lessons");
            DropForeignKey("dbo.Lessons", "Education_ID", "dbo.Educations");
            DropIndex("dbo.Educations", new[] { "Lesson_ID" });
            DropIndex("dbo.Lessons", new[] { "EducationID" });
            DropIndex("dbo.Lessons", new[] { "Education_ID" });
            CreateTable(
                "dbo.LessonEducations",
                c => new
                    {
                        Lesson_ID = c.Int(nullable: false),
                        Education_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Lesson_ID, t.Education_ID })
                .ForeignKey("dbo.Lessons", t => t.Lesson_ID, cascadeDelete: true)
                .ForeignKey("dbo.Educations", t => t.Education_ID, cascadeDelete: true)
                .Index(t => t.Lesson_ID)
                .Index(t => t.Education_ID);
            
            DropColumn("dbo.Educations", "Lesson_ID");
            DropColumn("dbo.Lessons", "EducationID");
            DropColumn("dbo.Lessons", "Education_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Lessons", "Education_ID", c => c.Int());
            AddColumn("dbo.Lessons", "EducationID", c => c.Int(nullable: false));
            AddColumn("dbo.Educations", "Lesson_ID", c => c.Int());
            DropForeignKey("dbo.LessonEducations", "Education_ID", "dbo.Educations");
            DropForeignKey("dbo.LessonEducations", "Lesson_ID", "dbo.Lessons");
            DropIndex("dbo.LessonEducations", new[] { "Education_ID" });
            DropIndex("dbo.LessonEducations", new[] { "Lesson_ID" });
            DropTable("dbo.LessonEducations");
            CreateIndex("dbo.Lessons", "Education_ID");
            CreateIndex("dbo.Lessons", "EducationID");
            CreateIndex("dbo.Educations", "Lesson_ID");
            AddForeignKey("dbo.Lessons", "Education_ID", "dbo.Educations", "ID");
            AddForeignKey("dbo.Educations", "Lesson_ID", "dbo.Lessons", "ID");
            AddForeignKey("dbo.Lessons", "EducationID", "dbo.Educations", "ID", cascadeDelete: true);
        }
    }
}
