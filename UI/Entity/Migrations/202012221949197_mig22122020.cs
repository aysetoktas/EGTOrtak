namespace Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig22122020 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Lessons", "ExamLink", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Lessons", "ExamLink");
        }
    }
}
