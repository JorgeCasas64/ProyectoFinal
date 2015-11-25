namespace ProyectoFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class facturaproveedorDos : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Facturas", "AsistenteId_IdAsistente", c => c.Int());
            CreateIndex("dbo.Facturas", "AsistenteId_IdAsistente");
            AddForeignKey("dbo.Facturas", "AsistenteId_IdAsistente", "dbo.Asistentes", "IdAsistente");
            DropColumn("dbo.Facturas", "IdAsistente");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Facturas", "IdAsistente", c => c.Int(nullable: false));
            DropForeignKey("dbo.Facturas", "AsistenteId_IdAsistente", "dbo.Asistentes");
            DropIndex("dbo.Facturas", new[] { "AsistenteId_IdAsistente" });
            DropColumn("dbo.Facturas", "AsistenteId_IdAsistente");
        }
    }
}
