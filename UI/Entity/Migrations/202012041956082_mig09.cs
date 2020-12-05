namespace Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig09 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Documents",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        LessonID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Lessons", t => t.LessonID, cascadeDelete: true)
                .Index(t => t.LessonID);
            
            DropColumn("dbo.Lessons", "DocumentLink");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Lessons", "DocumentLink", c => c.String());
            DropForeignKey("dbo.Documents", "LessonID", "dbo.Lessons");
            DropIndex("dbo.Documents", new[] { "LessonID" });
            DropTable("dbo.Documents");
        }
    }
}
