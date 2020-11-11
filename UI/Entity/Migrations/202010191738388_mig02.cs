namespace Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig02 : DbMigration
    {
        public override void Up()
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
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Educations", t => t.Education_ID)
                .Index(t => t.Education_ID);
            
            AddColumn("dbo.Educations", "CategoryID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Categories", "Education_ID", "dbo.Educations");
            DropIndex("dbo.Categories", new[] { "Education_ID" });
            DropColumn("dbo.Educations", "CategoryID");
            DropTable("dbo.Categories");
        }
    }
}
