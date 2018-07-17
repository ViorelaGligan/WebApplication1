namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCurency : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BankAccounts", "Curency", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.BankAccounts", "Curency", c => c.String(nullable: false));
        }
    }
}
