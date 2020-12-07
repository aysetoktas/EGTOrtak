namespace Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migDateTime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "BirthDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Educations", "StartDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Educations", "EndDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Lessons", "StartDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Lessons", "EndDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Lessons", "EndDate", c => c.Int(nullable: false));
            AlterColumn("dbo.Lessons", "StartDate", c => c.Int(nullable: false));
            AlterColumn("dbo.Educations", "EndDate", c => c.Int(nullable: false));
            AlterColumn("dbo.Educations", "StartDate", c => c.Int(nullable: false));
            AlterColumn("dbo.Users", "BirthDate", c => c.Int(nullable: false));
        }
    }
}
