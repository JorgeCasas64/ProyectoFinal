namespace ProyectoFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ultima : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Facturas");
            AddColumn("dbo.Facturas", "Fecha", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Facturas", "IdFactura", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Facturas", "Fecha");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Facturas");
            AlterColumn("dbo.Facturas", "IdFactura", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Facturas", "Fecha");
            AddPrimaryKey("dbo.Facturas", "IdFactura");
        }
    }
}
