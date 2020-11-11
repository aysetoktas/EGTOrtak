namespace Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig05 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Educations", "CategoryID", "dbo.Categories");
            DropIndex("dbo.Educations", new[] { "CategoryID" });
            RenameColumn(table: "dbo.Educations", name: "CategoryID", newName: "Category_ID1");
            AddColumn("dbo.Educations", "Category_ID", c => c.Int());
            AddColumn("dbo.Categories", "Education_ID", c => c.Int());
            AddColumn("dbo.Categories", "Education_ID1", c => c.Int());
            AlterColumn("dbo.Educations", "Category_ID1", c => c.Int());
            CreateIndex("dbo.Educations", "Category_ID");
            CreateIndex("dbo.Educations", "Category_ID1");
            CreateIndex("dbo.Categories", "Education_ID");
            CreateIndex("dbo.Categories", "Education_ID1");
            AddForeignKey("dbo.Categories", "Education_ID", "dbo.Educations", "ID");
            AddForeignKey("dbo.Educations", "Category_ID", "dbo.Categories", "ID");
            AddForeignKey("dbo.Categories", "Education_ID1", "dbo.Educations", "ID");
            AddForeignKey("dbo.Educations", "Category_ID1", "dbo.Categories", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Educations", "Category_ID1", "dbo.Categories");
            DropForeignKey("dbo.Categories", "Education_ID1", "dbo.Educations");
            DropForeignKey("dbo.Educations", "Category_ID", "dbo.Categories");
            DropForeignKey("dbo.Categories", "Education_ID", "dbo.Educations");
            DropIndex("dbo.Categories", new[] { "Education_ID1" });
            DropIndex("dbo.Categories", new[] { "Education_ID" });
            DropIndex("dbo.Educations", new[] { "Category_ID1" });
            DropIndex("dbo.Educations", new[] { "Category_ID" });
            AlterColumn("dbo.Educations", "Category_ID1", c => c.Int(nullable: false));
            DropColumn("dbo.Categories", "Education_ID1");
            DropColumn("dbo.Categories", "Education_ID");
            DropColumn("dbo.Educations", "Category_ID");
            RenameColumn(table: "dbo.Educations", name: "Category_ID1", newName: "CategoryID");
            CreateIndex("dbo.Educations", "CategoryID");
            AddForeignKey("dbo.Educations", "CategoryID", "dbo.Categories", "ID", cascadeDelete: true);
        }
    }
}
