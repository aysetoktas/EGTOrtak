namespace Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig11 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "Teacher_ID", "dbo.Teachers");
            DropForeignKey("dbo.Users", "Student_ID", "dbo.Students");
            DropForeignKey("dbo.Users", "Admin_ID", "dbo.Admins");
            DropIndex("dbo.Users", new[] { "Teacher_ID" });
            DropIndex("dbo.Users", new[] { "Student_ID" });
            DropIndex("dbo.Users", new[] { "Admin_ID" });
            DropColumn("dbo.Users", "Teacher_ID");
            DropColumn("dbo.Users", "Student_ID");
            DropColumn("dbo.Users", "Admin_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Admin_ID", c => c.Int());
            AddColumn("dbo.Users", "Student_ID", c => c.Int());
            AddColumn("dbo.Users", "Teacher_ID", c => c.Int());
            CreateIndex("dbo.Users", "Admin_ID");
            CreateIndex("dbo.Users", "Student_ID");
            CreateIndex("dbo.Users", "Teacher_ID");
            AddForeignKey("dbo.Users", "Admin_ID", "dbo.Admins", "ID");
            AddForeignKey("dbo.Users", "Student_ID", "dbo.Students", "ID");
            AddForeignKey("dbo.Users", "Teacher_ID", "dbo.Teachers", "ID");
        }
    }
}
