namespace ProdMan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Btws",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BtwNaam = c.String(nullable: false),
                        BtwValue = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductEigenschappens",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naam = c.String(nullable: false),
                        Nummer = c.Int(nullable: false),
                        PrijsFactor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Toeslag = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naam = c.String(nullable: false),
                        Nummer = c.Int(nullable: false),
                        Prijs = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BtwId = c.Int(nullable: false),
                        LeveranciersCode = c.String(nullable: false),
                        LeveranciersId = c.Int(nullable: false),
                        ProductgroepId = c.Int(nullable: false),
                        Zoekcode = c.String(),
                        AanmaakDatum = c.DateTime(nullable: false),
                        WijziginsDatum = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Nummer, unique: true);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Products", new[] { "Nummer" });
            DropTable("dbo.Products");
            DropTable("dbo.ProductEigenschappens");
            DropTable("dbo.Btws");
        }
    }
}
