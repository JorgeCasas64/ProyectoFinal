namespace ProyectoFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class facturaproveedor : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Facturas", name: "Proveedor_IdProveedor", newName: "ProveedorId_IdProveedor");
            RenameIndex(table: "dbo.Facturas", name: "IX_Proveedor_IdProveedor", newName: "IX_ProveedorId_IdProveedor");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Facturas", name: "IX_ProveedorId_IdProveedor", newName: "IX_Proveedor_IdProveedor");
            RenameColumn(table: "dbo.Facturas", name: "ProveedorId_IdProveedor", newName: "Proveedor_IdProveedor");
        }
    }
}
