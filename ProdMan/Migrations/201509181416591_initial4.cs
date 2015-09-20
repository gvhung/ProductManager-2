namespace ProdMan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "LeveranciersCode", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "LeveranciersCode", c => c.String(nullable: false));
        }
    }
}
