namespace Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig07 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Educations", "Certificate", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Educations", "Certificate", c => c.Boolean(nullable: false));
        }
    }
}
