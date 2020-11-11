namespace Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig01 : DbMigration
    {
        public override void Up()
        {
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
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Lessons", t => t.LessonID)
                .Index(t => t.LessonID);
            
            CreateTable(
                "dbo.Inspections",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IsCome = c.Boolean(nullable: false),
                        StudentID = c.Int(nullable: false),
                        AchievementID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Achievements", t => t.AchievementID, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentID, cascadeDelete: true)
                .Index(t => t.StudentID)
                .Index(t => t.AchievementID);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        PhoneNumber = c.String(),
                        School = c.String(),
                        Grade = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        StudentID = c.Int(nullable: false),
                        PhoneNumber = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Students", t => t.StudentID, cascadeDelete: true)
                .Index(t => t.StudentID);
            
            CreateTable(
                "dbo.Contracts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        EduPrice = c.String(),
                        EducationID = c.Int(),
                        PricePerMonth = c.String(),
                        EndDate = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Educations", t => t.EducationID)
                .Index(t => t.EducationID);
            
            CreateTable(
                "dbo.Educations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Note = c.String(),
                        ImagePath = c.String(),
                        Hour = c.Int(nullable: false),
                        StartDate = c.Int(nullable: false),
                        EndDate = c.Int(nullable: false),
                        Certificate = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Syllabus",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Date = c.Int(nullable: false),
                        StarTime = c.Int(nullable: false),
                        EndTime = c.Int(nullable: false),
                        Education_ID = c.Int(),
                        Lesson_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Educations", t => t.Education_ID)
                .ForeignKey("dbo.Lessons", t => t.Lesson_ID)
                .Index(t => t.Education_ID)
                .Index(t => t.Lesson_ID);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        Phone = c.String(),
                        Address = c.String(),
                        Detail = c.String(),
                        Note = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Branches",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.String(),
                        Role = c.Int(nullable: false),
                        Address = c.String(),
                        PhoneNumber = c.String(),
                        ImagePath = c.String(),
                        Name = c.String(),
                        LastName = c.String(),
                        BirthDate = c.Int(nullable: false),
                        Email = c.String(),
                        TeacherID = c.Int(nullable: false),
                        StudentID = c.Int(nullable: false),
                        AdminID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Admins", t => t.AdminID, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentID, cascadeDelete: true)
                .ForeignKey("dbo.Teachers", t => t.TeacherID, cascadeDelete: true)
                .Index(t => t.TeacherID)
                .Index(t => t.StudentID)
                .Index(t => t.AdminID);
            
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        EducationPay = c.String(),
                        Note = c.String(),
                        Contract_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Contracts", t => t.Contract_ID)
                .Index(t => t.Contract_ID);
            
            CreateTable(
                "dbo.Lessons",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        TeacherID = c.Int(nullable: false),
                        EducationID = c.Int(nullable: false),
                        StartDate = c.Int(nullable: false),
                        EndDate = c.Int(nullable: false),
                        Content = c.String(),
                        Logo = c.String(),
                        Path = c.String(),
                        ProjectLink = c.String(),
                        DocumentLink = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Educations", t => t.EducationID, cascadeDelete: true)
                .ForeignKey("dbo.Teachers", t => t.TeacherID, cascadeDelete: true)
                .Index(t => t.TeacherID)
                .Index(t => t.EducationID);
            
            CreateTable(
                "dbo.ContractCustomers",
                c => new
                    {
                        Contract_ID = c.Int(nullable: false),
                        Customer_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Contract_ID, t.Customer_ID })
                .ForeignKey("dbo.Contracts", t => t.Contract_ID, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.Customer_ID, cascadeDelete: true)
                .Index(t => t.Contract_ID)
                .Index(t => t.Customer_ID);
            
            CreateTable(
                "dbo.EducationStudents",
                c => new
                    {
                        Education_ID = c.Int(nullable: false),
                        Student_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Education_ID, t.Student_ID })
                .ForeignKey("dbo.Educations", t => t.Education_ID, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.Student_ID, cascadeDelete: true)
                .Index(t => t.Education_ID)
                .Index(t => t.Student_ID);
            
            CreateTable(
                "dbo.BranchTeachers",
                c => new
                    {
                        Branch_ID = c.Int(nullable: false),
                        Teacher_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Branch_ID, t.Teacher_ID })
                .ForeignKey("dbo.Branches", t => t.Branch_ID, cascadeDelete: true)
                .ForeignKey("dbo.Teachers", t => t.Teacher_ID, cascadeDelete: true)
                .Index(t => t.Branch_ID)
                .Index(t => t.Teacher_ID);
            
            CreateTable(
                "dbo.TeacherEducations",
                c => new
                    {
                        Teacher_ID = c.Int(nullable: false),
                        Education_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Teacher_ID, t.Education_ID })
                .ForeignKey("dbo.Teachers", t => t.Teacher_ID, cascadeDelete: true)
                .ForeignKey("dbo.Educations", t => t.Education_ID, cascadeDelete: true)
                .Index(t => t.Teacher_ID)
                .Index(t => t.Education_ID);
            
            CreateTable(
                "dbo.LessonStudents",
                c => new
                    {
                        Lesson_ID = c.Int(nullable: false),
                        Student_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Lesson_ID, t.Student_ID })
                .ForeignKey("dbo.Lessons", t => t.Lesson_ID, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.Student_ID, cascadeDelete: true)
                .Index(t => t.Lesson_ID)
                .Index(t => t.Student_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Lessons", "TeacherID", "dbo.Teachers");
            DropForeignKey("dbo.Syllabus", "Lesson_ID", "dbo.Lessons");
            DropForeignKey("dbo.LessonStudents", "Student_ID", "dbo.Students");
            DropForeignKey("dbo.LessonStudents", "Lesson_ID", "dbo.Lessons");
            DropForeignKey("dbo.Lessons", "EducationID", "dbo.Educations");
            DropForeignKey("dbo.Achievements", "LessonID", "dbo.Lessons");
            DropForeignKey("dbo.Inspections", "StudentID", "dbo.Students");
            DropForeignKey("dbo.Customers", "StudentID", "dbo.Students");
            DropForeignKey("dbo.Payments", "Contract_ID", "dbo.Contracts");
            DropForeignKey("dbo.Contracts", "EducationID", "dbo.Educations");
            DropForeignKey("dbo.Users", "TeacherID", "dbo.Teachers");
            DropForeignKey("dbo.Users", "StudentID", "dbo.Students");
            DropForeignKey("dbo.Users", "AdminID", "dbo.Admins");
            DropForeignKey("dbo.TeacherEducations", "Education_ID", "dbo.Educations");
            DropForeignKey("dbo.TeacherEducations", "Teacher_ID", "dbo.Teachers");
            DropForeignKey("dbo.BranchTeachers", "Teacher_ID", "dbo.Teachers");
            DropForeignKey("dbo.BranchTeachers", "Branch_ID", "dbo.Branches");
            DropForeignKey("dbo.Syllabus", "Education_ID", "dbo.Educations");
            DropForeignKey("dbo.EducationStudents", "Student_ID", "dbo.Students");
            DropForeignKey("dbo.EducationStudents", "Education_ID", "dbo.Educations");
            DropForeignKey("dbo.ContractCustomers", "Customer_ID", "dbo.Customers");
            DropForeignKey("dbo.ContractCustomers", "Contract_ID", "dbo.Contracts");
            DropForeignKey("dbo.Inspections", "AchievementID", "dbo.Achievements");
            DropIndex("dbo.LessonStudents", new[] { "Student_ID" });
            DropIndex("dbo.LessonStudents", new[] { "Lesson_ID" });
            DropIndex("dbo.TeacherEducations", new[] { "Education_ID" });
            DropIndex("dbo.TeacherEducations", new[] { "Teacher_ID" });
            DropIndex("dbo.BranchTeachers", new[] { "Teacher_ID" });
            DropIndex("dbo.BranchTeachers", new[] { "Branch_ID" });
            DropIndex("dbo.EducationStudents", new[] { "Student_ID" });
            DropIndex("dbo.EducationStudents", new[] { "Education_ID" });
            DropIndex("dbo.ContractCustomers", new[] { "Customer_ID" });
            DropIndex("dbo.ContractCustomers", new[] { "Contract_ID" });
            DropIndex("dbo.Lessons", new[] { "EducationID" });
            DropIndex("dbo.Lessons", new[] { "TeacherID" });
            DropIndex("dbo.Payments", new[] { "Contract_ID" });
            DropIndex("dbo.Users", new[] { "AdminID" });
            DropIndex("dbo.Users", new[] { "StudentID" });
            DropIndex("dbo.Users", new[] { "TeacherID" });
            DropIndex("dbo.Syllabus", new[] { "Lesson_ID" });
            DropIndex("dbo.Syllabus", new[] { "Education_ID" });
            DropIndex("dbo.Contracts", new[] { "EducationID" });
            DropIndex("dbo.Customers", new[] { "StudentID" });
            DropIndex("dbo.Inspections", new[] { "AchievementID" });
            DropIndex("dbo.Inspections", new[] { "StudentID" });
            DropIndex("dbo.Achievements", new[] { "LessonID" });
            DropTable("dbo.LessonStudents");
            DropTable("dbo.TeacherEducations");
            DropTable("dbo.BranchTeachers");
            DropTable("dbo.EducationStudents");
            DropTable("dbo.ContractCustomers");
            DropTable("dbo.Lessons");
            DropTable("dbo.Payments");
            DropTable("dbo.Admins");
            DropTable("dbo.Users");
            DropTable("dbo.Branches");
            DropTable("dbo.Teachers");
            DropTable("dbo.Syllabus");
            DropTable("dbo.Educations");
            DropTable("dbo.Contracts");
            DropTable("dbo.Customers");
            DropTable("dbo.Students");
            DropTable("dbo.Inspections");
            DropTable("dbo.Achievements");
        }
    }
}
