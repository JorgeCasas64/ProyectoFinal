namespace ProyectoFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ultimados : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Facturas");
            AddColumn("dbo.Facturas", "ServicioIdServicio", c => c.Int(nullable: false));
            AlterColumn("dbo.Facturas", "IdFactura", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Facturas", "IdFactura");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Facturas");
            AlterColumn("dbo.Facturas", "IdFactura", c => c.Int(nullable: false));
            DropColumn("dbo.Facturas", "ServicioIdServicio");
            AddPrimaryKey("dbo.Facturas", "Fecha");
        }
    }
}
