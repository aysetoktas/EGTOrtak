namespace Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig07 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.CategoryEducations", newName: "EducationCategories");
            DropForeignKey("dbo.Inspections", "AchievementID", "dbo.Achievements");
            DropForeignKey("dbo.Achievements", "LessonID", "dbo.Lessons");
            DropForeignKey("dbo.Syllabus", "Lesson_ID", "dbo.Lessons");
            DropForeignKey("dbo.Syllabus", "Education_ID", "dbo.Educations");
            DropForeignKey("dbo.Inspections", "StudentID", "dbo.Students");
            DropIndex("dbo.Achievements", new[] { "LessonID" });
            DropIndex("dbo.Inspections", new[] { "StudentID" });
            DropIndex("dbo.Inspections", new[] { "AchievementID" });
            DropIndex("dbo.Syllabus", new[] { "Lesson_ID" });
            DropIndex("dbo.Syllabus", new[] { "Education_ID" });
            DropPrimaryKey("dbo.EducationCategories");
            CreateTable(
                "dbo.Units",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        EducationID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Educations", t => t.EducationID, cascadeDelete: true)
                .Index(t => t.EducationID);
            
            CreateTable(
                "dbo.LiveLessons",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.CategoryStudents",
                c => new
                    {
                        Category_ID = c.Int(nullable: false),
                        Student_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Category_ID, t.Student_ID })
                .ForeignKey("dbo.Categories", t => t.Category_ID, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.Student_ID, cascadeDelete: true)
                .Index(t => t.Category_ID)
                .Index(t => t.Student_ID);
            
            CreateTable(
                "dbo.LiveLessonStudents",
                c => new
                    {
                        LiveLesson_ID = c.Int(nullable: false),
                        Student_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.LiveLesson_ID, t.Student_ID })
                .ForeignKey("dbo.LiveLessons", t => t.LiveLesson_ID, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.Student_ID, cascadeDelete: true)
                .Index(t => t.LiveLesson_ID)
                .Index(t => t.Student_ID);
            
            AddColumn("dbo.Lessons", "UnitID", c => c.Int());
            AddPrimaryKey("dbo.EducationCategories", new[] { "Education_ID", "Category_ID" });
            CreateIndex("dbo.Lessons", "UnitID");
            AddForeignKey("dbo.Lessons", "UnitID", "dbo.Units", "ID");
            DropTable("dbo.Achievements");
            DropTable("dbo.Inspections");
            DropTable("dbo.Syllabus");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Syllabus",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Date = c.Int(nullable: false),
                        StarTime = c.Int(nullable: false),
                        EndTime = c.Int(nullable: false),
                        Lesson_ID = c.Int(),
                        Education_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Inspections",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IsCome = c.Boolean(nullable: false),
                        StudentID = c.Int(nullable: false),
                        AchievementID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Achievements",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Date = c.Int(nullable: false),
                        LessonID = c.Int(),
                        IsCompleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            DropForeignKey("dbo.LiveLessonStudents", "Student_ID", "dbo.Students");
            DropForeignKey("dbo.LiveLessonStudents", "LiveLesson_ID", "dbo.LiveLessons");
            DropForeignKey("dbo.CategoryStudents", "Student_ID", "dbo.Students");
            DropForeignKey("dbo.CategoryStudents", "Category_ID", "dbo.Categories");
            DropForeignKey("dbo.Lessons", "UnitID", "dbo.Units");
            DropForeignKey("dbo.Units", "EducationID", "dbo.Educations");
            DropIndex("dbo.LiveLessonStudents", new[] { "Student_ID" });
            DropIndex("dbo.LiveLessonStudents", new[] { "LiveLesson_ID" });
            DropIndex("dbo.CategoryStudents", new[] { "Student_ID" });
            DropIndex("dbo.CategoryStudents", new[] { "Category_ID" });
            DropIndex("dbo.Units", new[] { "EducationID" });
            DropIndex("dbo.Lessons", new[] { "UnitID" });
            DropPrimaryKey("dbo.EducationCategories");
            DropColumn("dbo.Lessons", "UnitID");
            DropTable("dbo.LiveLessonStudents");
            DropTable("dbo.CategoryStudents");
            DropTable("dbo.LiveLessons");
            DropTable("dbo.Units");
            AddPrimaryKey("dbo.EducationCategories", new[] { "Category_ID", "Education_ID" });
            CreateIndex("dbo.Syllabus", "Education_ID");
            CreateIndex("dbo.Syllabus", "Lesson_ID");
            CreateIndex("dbo.Inspections", "AchievementID");
            CreateIndex("dbo.Inspections", "StudentID");
            CreateIndex("dbo.Achievements", "LessonID");
            AddForeignKey("dbo.Inspections", "StudentID", "dbo.Students", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Syllabus", "Education_ID", "dbo.Educations", "ID");
            AddForeignKey("dbo.Syllabus", "Lesson_ID", "dbo.Lessons", "ID");
            AddForeignKey("dbo.Achievements", "LessonID", "dbo.Lessons", "ID");
            AddForeignKey("dbo.Inspections", "AchievementID", "dbo.Achievements", "ID", cascadeDelete: true);
            RenameTable(name: "dbo.EducationCategories", newName: "CategoryEducations");
        }
    }
}
