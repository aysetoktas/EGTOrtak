namespace Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig03 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Categories", "Education_ID", "dbo.Educations");
            DropIndex("dbo.Categories", new[] { "Education_ID" });
            DropTable("dbo.Categories");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Hour = c.Int(nullable: false),
                        Education_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateIndex("dbo.Categories", "Education_ID");
            AddForeignKey("dbo.Categories", "Education_ID", "dbo.Educations", "ID");
        }
    }
}
