namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateRegister : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "Curency", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "Curency", c => c.String());
        }
    }
}
