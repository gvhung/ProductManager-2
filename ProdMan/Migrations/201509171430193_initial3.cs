namespace ProdMan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Leveranciers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nummer = c.Int(nullable: false),
                        Naam = c.String(nullable: false),
                        Adres = c.String(nullable: false),
                        Postcode = c.String(nullable: false),
                        Plaats = c.String(nullable: false),
                        Telefoon1 = c.String(),
                        Telefoon2 = c.String(),
                        Fax = c.String(),
                        Email = c.String(nullable: false),
                        Website = c.String(nullable: false),
                        ContactPersoon = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductEigenschappenKoppelings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductEigenschappenId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        AanmaakDatum = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductGroeps",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nummer = c.Int(nullable: false),
                        Naam = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ProductGroeps");
            DropTable("dbo.ProductEigenschappenKoppelings");
            DropTable("dbo.Leveranciers");
        }
    }
}
