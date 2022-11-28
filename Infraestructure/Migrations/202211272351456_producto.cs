namespace Infraestructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class producto : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Productoes",
                c => new
                    {
                        ProductoID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Descripcion = c.String(),
                        PrecioVenta = c.Int(nullable: false),
                        IsEnable = c.Boolean(nullable: false),
                        FechaCreacion = c.DateTime(nullable: false),
                        FechaVencimiento = c.DateTime(nullable: false),
                        IGV = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductoID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Productoes");
        }
    }
}
