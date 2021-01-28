namespace Bank.Business.Portifolio.InfraStructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BankTest : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bank",
                c => new
                    {
                        IdBank = c.Int(nullable: false, identity: true),
                        NameBank = c.Int(nullable: false),
                        DateRegister = c.DateTime(nullable: false),
                        DateUpdate = c.DateTime(),
                    })
                .PrimaryKey(t => t.IdBank);
            
            CreateTable(
                "dbo.Business",
                c => new
                    {
                        IdBusiness = c.Int(nullable: false, identity: true),
                        IdPortifolio = c.Int(nullable: false),
                        IdCategoryBusiness = c.Int(nullable: false),
                        IdClient = c.Int(nullable: false),
                        TypeBusiness = c.String(maxLength: 100, unicode: false),
                        ValueBusiness = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DateRegister = c.DateTime(nullable: false),
                        DateUpdate = c.DateTime(),
                        Portifolio_IdPortifolio = c.Int(),
                    })
                .PrimaryKey(t => t.IdBusiness)
                .ForeignKey("dbo.CategoryBusiness", t => t.IdCategoryBusiness)
                .ForeignKey("dbo.Client", t => t.IdClient)
                .ForeignKey("dbo.Portifolio", t => t.Portifolio_IdPortifolio)
                .ForeignKey("dbo.Portifolio", t => t.IdPortifolio)
                .Index(t => t.IdPortifolio)
                .Index(t => t.IdCategoryBusiness)
                .Index(t => t.IdClient)
                .Index(t => t.Portifolio_IdPortifolio);
            
            CreateTable(
                "dbo.CategoryBusiness",
                c => new
                    {
                        IdCategoryBusiness = c.Int(nullable: false, identity: true),
                        NameCategory = c.String(nullable: false, maxLength: 150, unicode: false),
                        ReferenceDate = c.DateTime(nullable: false),
                        DateRegister = c.DateTime(nullable: false),
                        DateUpdate = c.DateTime(),
                    })
                .PrimaryKey(t => t.IdCategoryBusiness);
            
            CreateTable(
                "dbo.Client",
                c => new
                    {
                        IdClient = c.Int(nullable: false, identity: true),
                        IdBank = c.Int(nullable: false),
                        NameClient = c.String(nullable: false, maxLength: 150, unicode: false),
                        SectorClient = c.String(nullable: false, maxLength: 50, unicode: false),
                        DateRegister = c.DateTime(nullable: false),
                        DateUpdate = c.DateTime(),
                    })
                .PrimaryKey(t => t.IdClient)
                .ForeignKey("dbo.Bank", t => t.IdBank)
                .Index(t => t.IdBank);
            
            CreateTable(
                "dbo.Portifolio",
                c => new
                    {
                        IdPortifolio = c.Int(nullable: false, identity: true),
                        IdBank = c.Int(nullable: false),
                        NameProtifolio = c.String(nullable: false, maxLength: 150, unicode: false),
                        DateRegister = c.DateTime(nullable: false),
                        DateUpdate = c.DateTime(),
                    })
                .PrimaryKey(t => t.IdPortifolio)
                .ForeignKey("dbo.Bank", t => t.IdBank)
                .Index(t => t.IdBank);
            
            CreateTable(
                "dbo.Payment",
                c => new
                    {
                        IdPayment = c.Int(nullable: false, identity: true),
                        IdBusiness = c.Int(nullable: false),
                        DateTimeNextPayment = c.DateTime(nullable: false),
                        paid = c.Boolean(nullable: false),
                        DateRegister = c.DateTime(nullable: false),
                        DateUpdate = c.DateTime(),
                    })
                .PrimaryKey(t => t.IdPayment)
                .ForeignKey("dbo.Business", t => t.IdBusiness)
                .Index(t => t.IdBusiness);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Payment", "IdBusiness", "dbo.Business");
            DropForeignKey("dbo.Business", "IdPortifolio", "dbo.Portifolio");
            DropForeignKey("dbo.Business", "Portifolio_IdPortifolio", "dbo.Portifolio");
            DropForeignKey("dbo.Portifolio", "IdBank", "dbo.Bank");
            DropForeignKey("dbo.Business", "IdClient", "dbo.Client");
            DropForeignKey("dbo.Client", "IdBank", "dbo.Bank");
            DropForeignKey("dbo.Business", "IdCategoryBusiness", "dbo.CategoryBusiness");
            DropIndex("dbo.Payment", new[] { "IdBusiness" });
            DropIndex("dbo.Portifolio", new[] { "IdBank" });
            DropIndex("dbo.Client", new[] { "IdBank" });
            DropIndex("dbo.Business", new[] { "Portifolio_IdPortifolio" });
            DropIndex("dbo.Business", new[] { "IdClient" });
            DropIndex("dbo.Business", new[] { "IdCategoryBusiness" });
            DropIndex("dbo.Business", new[] { "IdPortifolio" });
            DropTable("dbo.Payment");
            DropTable("dbo.Portifolio");
            DropTable("dbo.Client");
            DropTable("dbo.CategoryBusiness");
            DropTable("dbo.Business");
            DropTable("dbo.Bank");
        }
    }
}
