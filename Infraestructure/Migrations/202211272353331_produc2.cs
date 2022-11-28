namespace Infraestructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class produc2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Productoes", "PrecioVenta", c => c.Double(nullable: false));
            AlterColumn("dbo.Productoes", "IGV", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Productoes", "IGV", c => c.Int(nullable: false));
            AlterColumn("dbo.Productoes", "PrecioVenta", c => c.Int(nullable: false));
        }
    }
}
