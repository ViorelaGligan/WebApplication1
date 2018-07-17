namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBankAccount : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BankAccounts",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        IBAN = c.String(nullable: false, maxLength: 24),
                        Curency = c.String(nullable: false),
                        Alias = c.String(nullable: false, maxLength: 100),
                        PersoanaJuridica = c.Boolean(nullable: false),
                        CIF = c.String(maxLength: 12),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BankAccounts");
        }
    }
}
