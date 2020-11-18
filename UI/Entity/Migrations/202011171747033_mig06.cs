namespace Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig06 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Lessons", "CategoryID", c => c.Int());
            CreateIndex("dbo.Lessons", "CategoryID");
            AddForeignKey("dbo.Lessons", "CategoryID", "dbo.Categories", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Lessons", "CategoryID", "dbo.Categories");
            DropIndex("dbo.Lessons", new[] { "CategoryID" });
            DropColumn("dbo.Lessons", "CategoryID");
        }
    }
}
