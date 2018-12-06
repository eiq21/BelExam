namespace Data.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Marca",
                c => new
                    {
                        MarcaID = c.Short(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.MarcaID);
            
            CreateTable(
                "dbo.Producto",
                c => new
                    {
                        AnioCampania = c.Int(nullable: false),
                        Cuv = c.String(nullable: false, maxLength: 128),
                        MarcaID = c.Short(nullable: false),
                        Precio = c.Decimal(nullable: false, precision: 12, scale: 2),
                        Descripcion = c.String(nullable: false, maxLength: 500),
                        CodigoTipoOferta = c.String(nullable: false, maxLength: 6, fixedLength: true, unicode: false),
                        CodigoSAP = c.String(nullable: false, maxLength: 12),
                        EstadoActivo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.AnioCampania, t.Cuv })
                .ForeignKey("dbo.Marca", t => t.MarcaID, cascadeDelete: true)
                .Index(t => t.MarcaID);
            
            CreateTable(
                "dbo.Pedido",
                c => new
                    {
                        PedidoID = c.Int(nullable: false, identity: true),
                        Usuario = c.String(nullable: false, maxLength: 50),
                        AnioCampania = c.Int(nullable: false),
                        Cuv = c.String(nullable: false, maxLength: 128),
                        Cantidad = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PedidoID)
                .ForeignKey("dbo.Producto", t => new { t.AnioCampania, t.Cuv }, cascadeDelete: true)
                .Index(t => new { t.AnioCampania, t.Cuv });
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pedido", new[] { "AnioCampania", "Cuv" }, "dbo.Producto");
            DropForeignKey("dbo.Producto", "MarcaID", "dbo.Marca");
            DropIndex("dbo.Pedido", new[] { "AnioCampania", "Cuv" });
            DropIndex("dbo.Producto", new[] { "MarcaID" });
            DropTable("dbo.Pedido");
            DropTable("dbo.Producto");
            DropTable("dbo.Marca");
        }
    }
}
