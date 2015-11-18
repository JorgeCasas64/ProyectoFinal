namespace ProyectoFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Correxion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Facturas", "Proveedor_IdProveedor", c => c.Int());
            AddColumn("dbo.Servicios", "ProveedorIdProveedor", c => c.Int(nullable: false));
            CreateIndex("dbo.Facturas", "IdServicio");
            CreateIndex("dbo.Facturas", "Proveedor_IdProveedor");
            CreateIndex("dbo.Servicios", "ProveedorIdProveedor");
            AddForeignKey("dbo.Facturas", "Proveedor_IdProveedor", "dbo.Proveedors", "IdProveedor");
            AddForeignKey("dbo.Facturas", "IdServicio", "dbo.Servicios", "IdServicio", cascadeDelete: true);
            AddForeignKey("dbo.Servicios", "ProveedorIdProveedor", "dbo.Proveedors", "IdProveedor", cascadeDelete: true);
            DropColumn("dbo.Facturas", "IdProvedor");
            DropColumn("dbo.Facturas", "Precion");
            DropColumn("dbo.Servicios", "IdProveedor");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Servicios", "IdProveedor", c => c.Int(nullable: false));
            AddColumn("dbo.Facturas", "Precion", c => c.Single(nullable: false));
            AddColumn("dbo.Facturas", "IdProvedor", c => c.Int(nullable: false));
            DropForeignKey("dbo.Servicios", "ProveedorIdProveedor", "dbo.Proveedors");
            DropForeignKey("dbo.Facturas", "IdServicio", "dbo.Servicios");
            DropForeignKey("dbo.Facturas", "Proveedor_IdProveedor", "dbo.Proveedors");
            DropIndex("dbo.Servicios", new[] { "ProveedorIdProveedor" });
            DropIndex("dbo.Facturas", new[] { "Proveedor_IdProveedor" });
            DropIndex("dbo.Facturas", new[] { "IdServicio" });
            DropColumn("dbo.Servicios", "ProveedorIdProveedor");
            DropColumn("dbo.Facturas", "Proveedor_IdProveedor");
        }
    }
}
