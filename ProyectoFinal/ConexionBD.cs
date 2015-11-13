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
        
    }
}
