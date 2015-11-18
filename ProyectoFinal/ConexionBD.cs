using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace ProyectoFinal
{
    public class ConexionBD : DbContext
    {
        public DbSet<ejemplo> Ejemplos { get; set; }
        public DbSet<Factura> Factura { get; set; }
        public DbSet<CuentaProveedor> CuentaProveedor { get; set; }
        public DbSet<Asistente> Asistente { get; set; }
        public DbSet<Servicio> servicio { get; set; }
        public DbSet<Proveedor> Proveedor { get; set; }

        
    }
}
