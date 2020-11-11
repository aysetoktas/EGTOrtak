namespace Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig09 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "StudentID", "dbo.Students");
            DropForeignKey("dbo.Users", "TeacherID", "dbo.Teachers");
            DropForeignKey("dbo.Users", "AdminID", "dbo.Admins");
            DropIndex("dbo.Users", new[] { "TeacherID" });
            DropIndex("dbo.Users", new[] { "StudentID" });
            DropIndex("dbo.Users", new[] { "AdminID" });
            RenameColumn(table: "dbo.Users", name: "StudentID", newName: "Student_ID");
            RenameColumn(table: "dbo.Users", name: "TeacherID", newName: "Teacher_ID");
            RenameColumn(table: "dbo.Users", name: "AdminID", newName: "Admin_ID");
            AlterColumn("dbo.Users", "Teacher_ID", c => c.Int());
            AlterColumn("dbo.Users", "Student_ID", c => c.Int());
            AlterColumn("dbo.Users", "Admin_ID", c => c.Int());
            CreateIndex("dbo.Users", "Admin_ID");
            CreateIndex("dbo.Users", "Student_ID");
            CreateIndex("dbo.Users", "Teacher_ID");
            AddForeignKey("dbo.Users", "Student_ID", "dbo.Students", "ID");
            AddForeignKey("dbo.Users", "Teacher_ID", "dbo.Teachers", "ID");
            AddForeignKey("dbo.Users", "Admin_ID", "dbo.Admins", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "Admin_ID", "dbo.Admins");
            DropForeignKey("dbo.Users", "Teacher_ID", "dbo.Teachers");
            DropForeignKey("dbo.Users", "Student_ID", "dbo.Students");
            DropIndex("dbo.Users", new[] { "Teacher_ID" });
            DropIndex("dbo.Users", new[] { "Student_ID" });
            DropIndex("dbo.Users", new[] { "Admin_ID" });
            AlterColumn("dbo.Users", "Admin_ID", c => c.Int(nullable: false));
            AlterColumn("dbo.Users", "Student_ID", c => c.Int(nullable: false));
            AlterColumn("dbo.Users", "Teacher_ID", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Users", name: "Admin_ID", newName: "AdminID");
            RenameColumn(table: "dbo.Users", name: "Teacher_ID", newName: "TeacherID");
            RenameColumn(table: "dbo.Users", name: "Student_ID", newName: "StudentID");
            CreateIndex("dbo.Users", "AdminID");
            CreateIndex("dbo.Users", "StudentID");
            CreateIndex("dbo.Users", "TeacherID");
            AddForeignKey("dbo.Users", "AdminID", "dbo.Admins", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Users", "TeacherID", "dbo.Teachers", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Users", "StudentID", "dbo.Students", "ID", cascadeDelete: true);
        }
    }
}
